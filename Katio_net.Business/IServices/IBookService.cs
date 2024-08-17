
using Katio.Data.Models;

namespace Katio.Business.Interfaces;
public interface IBookService
{
    /// <summary>
    /// Busca todos los libros en la Base de datos.
    /// </summary>
    /// <returns>Lista de string.</returns>
    Task<IEnumerable<Books>> GetAllBooks();
    Task<IEnumerable<Books>> GetById(int id);

    Task<IEnumerable<Books>> GetByName(string name);

    Task<IEnumerable<Books>> Update(Books book);
}