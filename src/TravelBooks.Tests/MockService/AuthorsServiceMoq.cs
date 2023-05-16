using Core.Entities;
using Core.Interfaces;
using Core.Services.Authors;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Test.MockRepository;
using Xunit;

namespace Test.MockService
{
    public class AuthorsServiceMoq
    {
        private static IAuthorService _authorService;
        private readonly IAsyncRepository<Author> _asyncRepository;
        public AuthorsServiceMoq()
        {
            Mock<IAuthorService> _authorRepository = new AuthorsRepositoryMoq()._authorRepository;
            _authorService = new AuthorService(_asyncRepository);
        }

        [Fact]
        public async Task TestMethoEditAsync()
        {
            var result = await _authorService.Edit(new Author
            {
                Id = Guid.NewGuid(),
                ModifiedBy= Guid.NewGuid(),
                ModifiedOn=  DateTime.Now,
                LastName="asdfasdf",
                Name = "dafdsf",
                State= true
            });

            result.Should().Be(default(Author));
        }


        [Fact]
        public async Task TestMethoCreateAsync()
        {
            var result = await _authorService.Create(new Author
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                LastName = "asdfasdf",
                Name = "dafdsf",
                State = true
            });

            result.Should().Be(default(Author));
        }

        [Fact]
        public async Task TestMethoDeleteAsync()
        {
            var result = await _authorService.Delete(Guid.NewGuid());

            result.Should().Be(default(Author));
        }



    }
}
