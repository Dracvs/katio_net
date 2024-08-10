using Microsoft.AspNetCore.Mvc;

namespace Katio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return  Ok("Mi nombre es Frailejon Ernesto Perez");
    }
}