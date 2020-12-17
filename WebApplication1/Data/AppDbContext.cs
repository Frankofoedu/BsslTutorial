using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public partial class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var appUser = new AppUser { Email = "frankofoedu@yahoo.com", EmailConfirmed = true, UserName = "frankofoedu@yahoo.com" };

            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "holygrail0612");


            builder.Entity<AppUser>().HasData(appUser);
        }
    }

}
