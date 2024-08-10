using System;
using Katio.Business.Interfaces;
namespace Katio.Business.Services;

public class BookService : IBookService
{
    /// <summary>
    /// Busca todos los libros en la Base de datos.
    /// </summary>
    /// <returns>Lista de string.</returns>
    public Task<IEnumerable<string>> GetAllBooks()
    {
        
        Books book = new Books();
        
        // Texto
        String tipo_string = "Cadena de Carácteres, que en realidad es un Array de Char.";
        char tipo_char = 'H';

        // Digitos - Números
        sbyte tipo_sbyte = 127; // -128 -> 127
        byte tipo_byte = 255; // 0 -> 255

        short tipo_short = 32767; // -32768 -> 32767
        ushort tipo_ushort = 65535; // 0 -> 65535

        int tipo_int = 2147483647; // -2147483648 -> 2147483647
        uint tipo_uint = 0; // 0 -> 4294967295

        long tipo_long = 9223372036854775807; // -9223372036854775808 -> 9223372036854775809
        ulong tipo_ulong = 18446744073709551615; // 18446744073709551615

        // Get All books -> List<String> 10 títulos.
        // Van a declarar una lista de string, y luego van a buscar si en esa lista está lo que pide el controlador.
        // Buscar algo que no sea conseguible.
        // Update del libro #4. Y devolver el registor modificado.
        // Van a declarar todas las acciones del Libro que tienen en java aquí y dejarlas sin implementar.

        
        throw new NotImplementedException();
    }
}