using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Katio.Business.Interfaces;
using Katio.Business.Services;
using Katio.Data;
using Katio.Data.Models;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ExceptionExtensions;

namespace Katio.Tests;

[TestClass]
public class AuthorTests
{
    private readonly IRepository<int, Author> _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthorService _authorService;

    public AuthorTests()
    {
        _authorRepository = Substitute.For<IRepository<int, Author>>();
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _authorService = new AuthorService(_unitOfWork);
    }

    [TestMethod]
    public async Task GetAllAuthors()
    {
        //_authorRepository.GetAllAsync().ReturnsForAnyArgs(Task.FromResult<Author>>(new List<Author>()));
        //_unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.GetAllAuthors();

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task CreateAFelipe()
    {
        _authorRepository.GetAllAsync().ReturnsForAnyArgs(await Task.FromResult<List<Author>>(new List<Author>()));
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.CreateAFelipe(new Author(){Name= "Felipe", LastName="Ochoa", Country="Colombia", BirthDate=new DateOnly(2003, 02, 17)});
        Assert.AreEqual(200, (int)result.StatusCode);
    }

    [TestMethod]
    public async Task FailAFelipe()
    {
        var authors = new List<Author>();
        authors.Add(new Author());
        _authorRepository.GetAllAsync().ReturnsForAnyArgs(await Task.FromResult<List<Author>>(authors));
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.CreateAFelipe(new Author(){Name= "Felipe", LastName="Ochoa", Country="Colombia", BirthDate=new DateOnly(2003, 02, 17)});
        Assert.AreEqual(409, (int)result.StatusCode);
    }

    [TestMethod]
    public async Task ThrowAnExceptionOnFelipe()
    {        
        _authorRepository.GetAllAsync().ReturnsForAnyArgs(await Task.FromResult<List<Author>>(new List<Author>()));
        _authorRepository.AddAsync(new Author()).ThrowsAsyncForAnyArgs(new Exception()); // ThrowsAsync(new Exception());
        _unitOfWork.AuthorRepository.Returns(_authorRepository);
        var result = await _authorService.CreateAFelipe(new Author(){Name= "Felipe", LastName="Ochoa", Country="Colombia", BirthDate=new DateOnly(2003, 02, 17)});
        Assert.AreEqual(500, (int)result.StatusCode);
    }

    [TestMethod]
    public async Task UpdateFail()
    {
        _authorRepository.Update(Arg.Any<Author>()).ThrowsAsyncForAnyArgs(new Exception("Fallé viteh"));
        _unitOfWork.AuthorRepository.Returns(_authorRepository);

        var result = await _authorService.Update(new Author());

        Assert.AreEqual(HttpStatusCode.InternalServerError, result.StatusCode);
    }

    

    [TestMethod]
    public async Task PassingTest()
    {
        var nombre = new List<string>();
        Assert.IsNotNull(nombre);
    }
}
