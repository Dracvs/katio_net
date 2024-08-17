using System;
using Katio.Business.Interfaces;
using Katio.Data.Models;
using Katio.Business.Utilities;
using System.Security.Cryptography.X509Certificates;

namespace Katio.Business.Services;

public class BookService : IBookService
{
    /// <summary>
    /// Busca todos los libros en la Base de datos.
    /// </summary>
    /// <returns>Lista de string.</returns>
    public async Task<IEnumerable<Books>> GetAllBooks()
    {
        return Utilities.Utilities.CreateABooksList();
    }

    public async Task<IEnumerable<Books>> GetById(int id)
    {
        if(id <= 0)
        {
            return new List<Books>();
        }
        // Lista de libros
        var list = Utilities.Utilities.CreateABooksList();
        
        // for(int i = 0; i < list.Count; i++)
        // {
        //     if(list[i].Id == id)
        //     {
        //         var listBooks = new List<Books>();
        //         listBooks.Add(list[i]);
        //         return listBooks;
        //     }
        // }

        // foreach (var item in list) // item le llamamos por convención.
        // {
        //     if(item.Id == id)
        //     {
        //         var listBooks = new List<Books>();
        //         listBooks.Add(item);
        //         return listBooks;
        //     }
        // }

        // LINQ
        var samir = list.Where(x => x.Id == id);


        return samir;
    }

    public async Task<IEnumerable<Books>> GetByName(string name)
    {
        var heidy =  Utilities.Utilities.CreateABooksList()
            .Where(X => X.Title.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        return heidy;
    }

    public async Task<IEnumerable<Books>> Update(Books book)
    {
        var sara = Utilities.Utilities.CreateABooksList();
        var updatedBook = sara.Where(x => x.Id == book.Id).FirstOrDefault();
        sara.RemoveAt(book.Id);
        //sara.Remove(updatedBook);
        updatedBook.Published = book.Published;        
        sara.Add(updatedBook);
        return sara;
    }
    
    
    // Crear una lista de libros
    // Crear una lista de Autores
    // Intentar que el método de update funcione con una lista.
}