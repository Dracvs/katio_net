using Katio.Business.Interfaces;
using Katio.Data.Models;
using Katio.Data.Dto;
using Katio_net.Data;
using Katio.Business.Utilities;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Globalization;
using Katio.Data;
using System.Security.Cryptography.X509Certificates;

namespace Katio.Business.Services;

public class BookService : IBookService
{
    
    private readonly KatioContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public BookService(KatioContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<BaseMessage<Book>> CreateBook(Book book)
    {
        var newBook = new Book()
        {
            Title =  book.Title,
            ISBN10 = book.ISBN10,
            ISBN13 = book.ISBN13,
            Published = book.Published,
            Edition = book.Edition,
            DeweyIndex = book.DeweyIndex,
            AuthorId = book.AuthorId
        };

        try
        {
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Utilities.Utilities.BuildResponse<Book>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_ERROR_500} | {ex.Message}");
        }

        return Utilities.Utilities.BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Book>{newBook});
    }

    /// <summary>
    /// Busca todos los libros en la Base de datos.
    /// </summary>
    /// <returns>Lista de string.</returns>
    public async Task<BaseMessage<Book>> GetAllBooks()
    {
        //var result = await _context.Books.Include(a => a.Author).ToListAsync();
        var result = await _unitOfWork.BookRepository.GetAllAsync();
        return result.Any() ? Utilities.Utilities.BuildResponse<Book>(HttpStatusCode.OK, BaseMessageStatus.OK_200, result.ToList()) :
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());
    }

    public async Task<BaseMessage<Book>> GetAllBooksByAuthorName(string Name)
    {
        var result = await _unitOfWork.BookRepository.GetAllAsync(
            x => x.Author.Name.ToLower().Contains(Name));
            
        return result.Any() ? Utilities.Utilities.BuildResponse<Book>(HttpStatusCode.OK, BaseMessageStatus.OK_200, result.ToList()) :
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());
    }

    public async Task<BaseMessage<Book>> GetById(int id)
    {

        // Lista de libros
        //var book = await _context.Books.FindAsync(id);
        var book = await _unitOfWork.BookRepository.FindAsync(id);
        return book != null ? Utilities.Utilities.BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Book>(){book}) :
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());
    }

    public async Task<IEnumerable<Book>> GetByName(string name)
    {
       //var list = await _context.Books.Where(x => x.Title.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToListAsync();
       var list = await _unitOfWork.BookRepository.GetAllAsync(x => x.Title.Contains(name, StringComparison.InvariantCultureIgnoreCase));
       return list;
    }

    public async Task<BaseMessage<Book>> GetByAuthor(int AuthorId)
    {
        var bookList = await _context.Books.Where(x => x.AuthorId == AuthorId).ToListAsync();
        return bookList.Any() ? Utilities.Utilities.BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, bookList) :
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());;
    }

    public async Task<BaseMessage<Book>> GetByAuthor(string name)
    {        
        var bookList = await _context.Books
        .Where(x => x.Author.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase))
        .ToListAsync();
        return bookList.Any() ? Utilities.Utilities.BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, bookList) :
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Book>());;
    }

    public async Task<IEnumerable<Book>> Update(Book book)
    {
        
        throw new NotImplementedException();
    }

}
