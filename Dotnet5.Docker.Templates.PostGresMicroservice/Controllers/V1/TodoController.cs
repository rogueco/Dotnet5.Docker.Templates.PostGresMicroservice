using Microsoft.AspNetCore.Mvc;

namespace Dotnet5.Docker.Templates.PostGresMicroservice.Controllers.V1
{
    public class TodoController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}