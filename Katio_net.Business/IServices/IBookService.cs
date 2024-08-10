
namespace Katio.Business.Interfaces;
public interface IBookService
{
    /// <summary>
    /// Busca todos los libros en la Base de datos.
    /// </summary>
    /// <returns>Lista de string.</returns>
    Task<IEnumerable<string>> GetAllBooks();
}