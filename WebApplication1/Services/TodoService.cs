using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;


        public TodoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TodoItem> AddTodoItem(TodoVm todoVm)
        {
            var todo = new TodoItem {
                TodoTime = todoVm.TodoTime,
                IsDone = todoVm.IsDone,
                TodoDescription = todoVm.TodoDescription 
            };

            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        public async Task<TodoItem> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            return todoItem;
        }

        public async Task<IEnumerable<TodoVm>> GetTodoItems()
        {
            return await _context.TodoItems.Select(x => new TodoVm { 
                IsDone = x.IsDone,
                TodoDescription = x.TodoDescription,
                Id = x.Id, TodoTime = x.TodoTime
            }).ToListAsync();
        }

        public async Task<bool> UpdateTodoItem(int id, TodoVm todoItemVM)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return false;
            }

            try
            {
                todoItem.IsDone = todoItemVM.IsDone;
                todoItem.TodoDescription = todoItemVM.TodoDescription;
                todoItem.TodoTime = todoItem.TodoTime;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool TodoItemExists(int id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
