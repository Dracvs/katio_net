using Microsoft.AspNetCore.Mvc;
using Katio.Data.Models;
using Katio.Business.Interfaces;

namespace Katio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet]
    [Route("GetAllBooks")]
    public async Task<IActionResult> Index() // Se llama index por convención genérica.
    {
        var response = await _bookService.GetAllBooks();
        //return await _bookService.GetAllBooks();
        return response.Count() > 0 ? Ok(response) : StatusCode(StatusCodes.Status204NoContent, "Aqui no hay es na'");
    }

    [HttpGet]
    [Route("GetByid")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _bookService.GetById(id);
        return response.Count() > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No se lo conseguí");
    }

    [HttpGet]
    [Route("GetByName")]
    public async Task<IActionResult> GetByName(string name)
    {
        var response = await _bookService.GetByName(name);
        return response.Count() > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No se lo conseguí");
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update(Books book)
    {
        var response = await _bookService.Update(book);
        return response.Count() > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No se lo conseguí");
    }
}