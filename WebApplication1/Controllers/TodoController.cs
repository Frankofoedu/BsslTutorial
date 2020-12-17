using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/Todo
        [HttpGet("GetMyTodos")]
        public async Task<ActionResult> GetTodoItems()
        {
            try
            {
                var items = await _todoService.GetTodoItems();

                if (items.Count() > 0)
                {
                    return Ok(items);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
               return BadRequest("An error occured: " + ex.Message);
            }
           
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Todo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        // POST: api/Todo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTodoItem(TodoVm todoItem)
        {
            var item = await _todoService.AddTodoItem(todoItem);

            return CreatedAtAction("PostTodoItem", new { id = item.Id }, item);
           // return Ok(item);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            throw new NotImplementedException();
        }
    }
}
