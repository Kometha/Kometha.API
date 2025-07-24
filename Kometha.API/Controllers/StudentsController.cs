using Microsoft.AspNetCore.Mvc;

namespace Kometha.API.Controllers
{
    // https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET;
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "Keneth", "Milton", "David", "Jorge" };

            return Ok(studentNames);
        }
    }
}
