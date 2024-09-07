using Microsoft.AspNetCore.Mvc;
using Katio.Data.Models;
using Katio.Business.Interfaces;
using System.Net;
using Katio_net.Data;
using Microsoft.EntityFrameworkCore;

namespace Katio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly KatioContext _context;
    public AuthorController(IAuthorService authorService, KatioContext context)
    {
        _authorService = authorService;
        _context = context;
    }
    
    [HttpGet]
    [Route("GetAllAuthors")]
    public async Task<IActionResult> Index() // Se llama index por convención genérica.
    {
        var response = await _authorService.GetAllAuthors();
        //var response = await _context.Authors.ToListAsync();
        //return await _bookService.GetAllBooks();
        return response.TotalElements > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, response);
    }
}