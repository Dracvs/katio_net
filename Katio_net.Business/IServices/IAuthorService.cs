
using Katio.Data.Models;
using Katio.Data.Dto;

namespace Katio.Business.Interfaces;
public interface IAuthorService
{
    Task<BaseMessage<Author>> CreateAuthor(Author author);
    Task<BaseMessage<Author>> GetAllAuthors();
}
