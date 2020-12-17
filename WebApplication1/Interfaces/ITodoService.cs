using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.ViewModels;

namespace WebApplication1.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoVm>> GetTodoItems();
        Task<TodoItem> GetTodoItem(int id);

        Task<bool> UpdateTodoItem(int id, TodoVm todoItem);

        Task<TodoItem> AddTodoItem(TodoVm todoItem);
    }
}
