using Katio.Business.Interfaces;
using Katio.Data.Models;
using Katio.Data.Dto;
using Katio_net.Data;
using System.Net;

namespace Katio.Business.Services;

public class BookService : IBookService
{
    
    private readonly KatioContext _context;

    public BookService(KatioContext context)
    {
        _context = context;
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
            DeweyIndex = book.DeweyIndex
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
    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        return _context.Books.ToList();
    }

    public async Task<IEnumerable<Book>> GetById(int id)
    {
        if(id <= 0)
        {
            return new List<Book>();
        }
        // Lista de libros
        var list = Utilities.Utilities.CreateABooksList();

        // LINQ
        var samir = list.Where(x => x.Id == id);


        return samir;
    }

    public async Task<IEnumerable<Book>> GetByName(string name)
    {
        var heidy =  Utilities.Utilities.CreateABooksList()
            .Where(X => X.Title.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        return heidy;
    }

    public async Task<IEnumerable<Book>> Update(Book book)
    {
        var sara = Utilities.Utilities.CreateABooksList();
        var updatedBook = sara.Where(x => x.Id == book.Id).FirstOrDefault();
        sara.RemoveAt(book.Id);
        //sara.Remove(updatedBook);
        updatedBook.Published = book.Published;        
        sara.Add(updatedBook);
        return sara;
    }
    
    
}