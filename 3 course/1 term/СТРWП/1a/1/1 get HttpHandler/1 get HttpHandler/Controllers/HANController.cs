using Microsoft.AspNetCore.Mvc;

namespace _1_get_HttpHandler.Controllers
{
    [Route("api/PAV")]
    [ApiController]
    public class HanController : ControllerBase
    {

        [HttpGet]  // 1 task  поулчить
        public IActionResult GetHandler(string ParmA, string ParmB)
        {
            string response = $"GET-Http-PAV:ParmA = {ParmA},ParmB = {ParmB}";
            return Content(response, "text/plain");
        }

        [HttpPost]  // 2 task создать
        public IActionResult PostHandler(string ParmA, string ParmB)
        {
            string response = $"POST-Http-PAV:ParmA = {ParmA},ParmB = {ParmB}";
            return Content(response, "text/plain");
        }

        [HttpPut]  // 3 task обновить
        public IActionResult PUTHandler(string ParmA, string ParmB)
        {
            string response = $"PUT-Http-PAV:ParmA = {ParmA},ParmB = {ParmB}";
            return Content(response, "text/plain");
        }

    }
}

// localhost:5000/api/PAV?ParmA=aaa&ParmB=bbb