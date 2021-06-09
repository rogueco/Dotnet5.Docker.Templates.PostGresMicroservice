// File Created By Thomas Fletcher

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Data;

namespace Dotnet5.Docker.Templates.PostGresMicroservice.Repositories
{
    public interface ITodoRepository
    {
        /// <summary>
        /// Simple call to return all Todo items
        /// </summary>
        /// <returns>An IEnumerable of TodoItem</returns>
        Task<IEnumerable<TodoItem>> GetAllTodos();
        
        
        
    }
}