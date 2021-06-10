// -----------------------------------------------------------------------
// <copyright company="N/A." file="TodoController.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

#region Usings
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Data;
using Dotnet5.Docker.Templates.PostGresMicroservice.Repositories;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable RouteTemplates.RouteParameterConstraintNotResolved
// ReSharper disable RouteTemplates.ControllerRouteParameterIsNotPassedToMethods
#endregion

namespace Dotnet5.Docker.Templates.PostGresMicroservice.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        /// <summary>
        /// Simple GET to return a List of Todos
        /// </summary>
        /// <returns>List of TodoItem</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAllTodos()
        {
            IEnumerable<TodoItem> allTodos = await _todoRepository.GetAllTodos();
            return Ok(allTodos);
        }
 
        /// <summary>
        /// Simple GET to return a single TodoItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single TodoItem</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoById(Guid id)
        {
            TodoItem todoItem = await _todoRepository.GetTodoById(id);
            return Ok(todoItem);
        }
        //TODO: Implement Create REST Endpoint
        //TODO: Implement Update By {id} REST Endpoint
        //TODO: Implement Delete By {id} REST Endpoint
    }
}