// -----------------------------------------------------------------------
// <copyright company="N/A." file="TodoRepository.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

#region usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Data;
using Microsoft.EntityFrameworkCore;
#endregion

namespace Dotnet5.Docker.Templates.PostGresMicroservice.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;

        public TodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodos() => await _dataContext.TodoItems.ToListAsync();

        public async Task<TodoItem> GetTodoById(Guid id) => await _dataContext.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> CreateTodo(TodoItem todoItem)
        {
            if (todoItem.Name.Length > 0)
            {
                await _dataContext.TodoItems.AddAsync(todoItem);
                return await _dataContext.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> UpdateTodo(Guid id, TodoItem todoItem)
        {
            TodoItem todoItemToUpdate = await _dataContext.TodoItems.Where(s => s.Id == id).FirstOrDefaultAsync();

            // TODO: Would be nice to implement Automapper, so you can map these automatically using `.Map(todoItem, todoItemToUpdate);`
            if (todoItemToUpdate != null)
            {
                todoItemToUpdate.Name = todoItem.Name;
                todoItemToUpdate.IsCompleted = todoItem.IsCompleted;

                // Why this, if we are able to successfully save the changes - we will return true.
                bool result = await _dataContext.SaveChangesAsync() > 0;
                return result;
            }

            return false;
        }

        public async Task<bool> DeleteTodo(Guid id)
        {
            var todoItem = await _dataContext.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return false;
            }

            _dataContext.Remove(todoItem);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}