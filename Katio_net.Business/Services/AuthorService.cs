using System.Net;
using Katio.Business.Interfaces;
using Katio.Data.Dto;
using Katio.Data.Models;
using Katio_net.Data;
using Microsoft.EntityFrameworkCore;

namespace Katio.Business.Services;

public class AuthorService : IAuthorService
{
    public readonly KatioContext _context;
    
    public AuthorService(KatioContext context)
    {
        _context = context;
    }
    
    public async Task<BaseMessage<Author>> CreateAuthor(Author author)
    {
       var newAuthor = new Author()
       {
        Name = author.Name,
        LastName = author.LastName,
        Country = author.Country,
        BirthDate = author.BirthDate
       };

       try
       {
            await _context.Authors.AddAsync(newAuthor);
            await _context.SaveChangesAsync();
       }
       catch (Exception ex)
       {
        return Utilities.Utilities.BuildResponse<Author>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_ERROR_500} | {ex.Message}");
       }
       return Utilities.Utilities.BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Author>{newAuthor});
    }

    public async Task<BaseMessage<Author>> GetAllAuthors()
    {
        var result = await _context.Authors.ToListAsync();
        return result.Any() ? Utilities.Utilities.BuildResponse<Author>(HttpStatusCode.OK, BaseMessageStatus.OK_200, result) :
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Author>());

    }
}
    