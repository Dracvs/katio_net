using System.Net;
using Katio.Business.Interfaces;
using Katio.Data;
using Katio.Data.Dto;
using Katio.Data.Models;
using Katio_net.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Katio.Business.Services;

public class AuthorService : IAuthorService
{
    public readonly KatioContext _context;
    public readonly IUnitOfWork _unitOfWork;
    
    // public AuthorService(KatioContext context)
    // {
    //     _context = context;
    // }

    public AuthorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
        var result = await _unitOfWork.AuthorRepository.GetAllAsync();
        return result.Any() ? Utilities.Utilities.BuildResponse<Author>(HttpStatusCode.OK, BaseMessageStatus.OK_200, result.ToList()) :
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Author>());

    }

    public async Task<BaseMessage<Author>> GetAllAuthorsVariants(Author auhtor)
    {
        var result = await _unitOfWork.AuthorRepository.GetAllAsync();

        return result.Any() ? Utilities.Utilities.BuildResponse<Author>(HttpStatusCode.OK, BaseMessageStatus.OK_200, result.ToList()) :
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Author>());
    }

    public async Task<BaseMessage<Author>> CreateAFelipe(Author author)
    {
        // if(ValidateAuthor(author))
        // {
        //     return Utilities.Utilities.BuildResponse<Author>(HttpStatusCode.Conflict, $"{BaseMessageStatus.BAD_REQUEST_400} | El autor ya está registrado en el sistema.");
        // }
        
        var existingAuthor = await _unitOfWork.AuthorRepository.GetAllAsync(a => a.Name == author.Name && a.LastName == author.LastName);
        
        if (existingAuthor.Any())
        {
            return Utilities.Utilities.BuildResponse<Author>(HttpStatusCode.Conflict, $"{BaseMessageStatus.BAD_REQUEST_400} | El autor ya está registrado en el sistema.");
        }

        var newAuthor = new Author()
        {
            Name = author.Name,
            LastName = author.LastName,
            Country = author.Country,
            BirthDate = author.BirthDate
        };

        try
        {
            await _unitOfWork.AuthorRepository.AddAsync(newAuthor);
        } 
        catch (Exception ex)
        {
            return Utilities.Utilities.BuildResponse<Author>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_ERROR_500} | {ex.Message}");
        }

        return Utilities.Utilities.BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Author> { newAuthor });
    }


    private bool ValidateAuthor(Author author)
    {
        var isValid = true;
        if(String.IsNullOrEmpty(author.Name))
        {
            isValid = false;
        }
        if(string.IsNullOrEmpty(author.LastName))
        {
            isValid = false;
        }
        if(string.IsNullOrEmpty(author.Country)){
            isValid = false;
        }
        if(author.BirthDate.Year < 1800)
        {
            isValid = false;
        }
        return isValid;
        
    }

    public async Task<BaseMessage<Author>> Update(Author author)
    {
        try
        {
            await _unitOfWork.AuthorRepository.Update(author);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            return Utilities.Utilities.BuildResponse<Author>(HttpStatusCode.InternalServerError, $"{BaseMessageStatus.INTERNAL_SERVER_ERROR_500} | {ex.Message}");
        }

        return Utilities.Utilities.BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Author> { author });
    }
}
    