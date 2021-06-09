#region Usings
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAllTodos()
        {
            IEnumerable<TodoItem> allTodos = await _todoRepository.GetAllTodos();
            return Ok(allTodos);
        }
    }
}