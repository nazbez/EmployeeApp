using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Backend.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TestsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello!");
    }
}