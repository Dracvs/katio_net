using Microsoft.AspNetCore.Mvc;
using Katio.Data.Models;
using Katio.Business.Interfaces;
using System.Net;

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
        return response.TotalElements > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, response);
    }

    [HttpGet]
    [Route("GetByid")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _bookService.GetById(id);
        return response.TotalElements > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No se lo conseguí");
    }

    [HttpGet]
    [Route("GetByName")]
    public async Task<IActionResult> GetByName(string name)
    {
        var response = await _bookService.GetByName(name);
        return response.Count() > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No se lo conseguí");
    }

    [HttpPost]
    [Route("GetByAuthorsName")]
    public async Task<IActionResult> GetByAuthorsName(string name)
    {
        var response = await _bookService.GetByAuthor(name);
        return response.TotalElements > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No se lo conseguí");
    }

    [HttpGet]
    [Route("GetAllMixedIn")]
    public async Task<IActionResult> GetAllMixed(string name)
    {
        var response = await _bookService.GetAllBooksByAuthorName(name);
        return response.TotalElements > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No se lo conseguí");
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update(Book book)
    {
        var response = await _bookService.Update(book);
        return response.Count() > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No se lo conseguí");
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(Book book)
    {
        var response = await _bookService.CreateBook(book);
        return response.StatusCode == System.Net.HttpStatusCode.OK ? Ok(response) : 
            StatusCode((int)response.StatusCode, response);
    }
}