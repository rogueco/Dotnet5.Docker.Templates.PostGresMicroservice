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
        [HttpGet("getAll", Name = "GetAll")]
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
        [HttpGet("{id:guid}", Name = "GetById")]
        [ProducesResponseType(typeof(TodoItem), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoById(Guid id)
        {
            TodoItem todoItem = await _todoRepository.GetTodoById(id);
            return todoItem != null ? Ok(todoItem) : BadRequest("Todo item does not exist");
        }


        /// <summary>
        /// Simple create POST endpoint
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>Ok response if successful, or BadRequest if unsuccessful</returns>
        [HttpPost("create", Name = "Create")]
        public async Task<ActionResult<TodoItem>> CreateTodo(TodoItem todoItem)
        {
            bool result = await _todoRepository.CreateTodo(todoItem);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Simple update PUT endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todoItem"></param>
        /// <returns>Ok response if successful, or BadRequest if unsuccessful</returns>
        [HttpPut("updateTodo/{id:guid}",Name = "UpdateTodo")]
        public async Task<ActionResult> UpdateTodoItem(Guid id, TodoItem todoItem)
        {
            bool result = await _todoRepository.UpdateTodo(id, todoItem);
            return result ? Ok() : BadRequest("Something went wrong, please check your model");
        }

        /// <summary>
        /// Simple DELETE endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok response if successful, or BadRequest if unsuccessful</returns>
        [HttpDelete("{id:guid}", Name = "DeleteTodo")]
        public async Task<ActionResult> DeleteTodo(Guid id)
        {
            bool result = await _todoRepository.DeleteTodo(id);
            return result ? Ok() : BadRequest("Something went wrong, please check your model");
        }
    }
}