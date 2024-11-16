
using Katio.Data.Models;
using Katio.Data.Dto;

namespace Katio.Business.Interfaces;
public interface IAuthorService
{
    Task<BaseMessage<Author>> CreateAuthor(Author author);
    Task<BaseMessage<Author>> GetAllAuthors();
    Task<BaseMessage<Author>>CreateAFelipe(Author author);
    Task<BaseMessage<Author>> Update(Author author);
    Task<BaseMessage<Author>> SearchBar(Author author);
}
