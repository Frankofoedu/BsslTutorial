using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _Repository;

        public LoginController(IConfiguration configuration,
                               SignInManager<AppUser> signInManager,
                               AppDbContext Repository)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _Repository = Repository;
        }
        public class LoginModel
        {
            [Required(ErrorMessage = "The Email field is required.")]
            [EmailAddress()]
            public string Email { get; set; }

            [Required(ErrorMessage = "The Password field is required.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await _Repository.Users.FirstOrDefaultAsync(x=> x.Email == login.Email);

            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);

            if (!result.Succeeded)
            {
                if (result.IsNotAllowed) return BadRequest( "Please check your email for the confirmation link." );

                if (result.IsLockedOut) return BadRequest( "Locked Out" );

                return BadRequest("Login details are not valid.");

            }

            var roles = await _signInManager.UserManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Email),
                new Claim("UID", user.Id),
                //new Claim("CID", user.CompanyId.Value.ToString()),
                //new Claim("CName", user.Company.Name ),
                //new Claim("FirstName", user.FirstName ),
                //new Claim("LastName", user.LastName ),
                //new Claim("Email", user.Email ),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
