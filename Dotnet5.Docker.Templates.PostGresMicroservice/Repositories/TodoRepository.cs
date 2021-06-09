// File Created By Thomas Fletcher

using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}