
using Katio.Data.Models;
using Katio.Data.Dto;

namespace Katio.Business.Interfaces;
public interface IBookService
{
    /// <summary>
    /// Busca todos los libros en la Base de datos.
    /// </summary>
    /// <returns>Lista de string.</returns>
    Task<BaseMessage<Book>> GetAllBooks();
    Task<BaseMessage<Book>> GetById(int id);

    Task<IEnumerable<Book>> GetByName(string name);

    Task<BaseMessage<Book>> GetByAuthor(int AuthorId);

    Task<BaseMessage<Book>> GetByAuthor(String name);

    Task<BaseMessage<Book>> CreateBook(Book books);

    Task<IEnumerable<Book>> Update(Book book);
}