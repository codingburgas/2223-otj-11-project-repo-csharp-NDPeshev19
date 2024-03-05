using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PC.WebHost.Controllers;

[Route("/test")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpPost]
    [Authorize]
    public Task<IActionResult> Test()
    {
        Console.WriteLine("Hitna");

        return Task.FromResult<IActionResult>(Ok("Ok"));
    }
}
