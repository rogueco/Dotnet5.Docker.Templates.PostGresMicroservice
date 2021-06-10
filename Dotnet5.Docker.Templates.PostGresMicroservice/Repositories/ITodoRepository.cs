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


        //TODO: Implement GET by {id} Endpoint
        //TODO: Implement Update By {id} Endpoint
        //TODO: Implement Delete By {id} Endpoint
    }
}