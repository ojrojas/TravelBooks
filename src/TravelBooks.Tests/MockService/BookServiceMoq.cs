using Core.Entities;
using Core.Interfaces;
using Core.Services.Books;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Test.MockRepository;
using Xunit;

namespace Test.MockService
{
    public class BookServiceMoq
    {
        private static IBookService _bookService;
        private readonly IAsyncRepository<Book> _asyncRepository;
        public BookServiceMoq()
        {
            Mock<IBookService> _authorRepository = new BooksRepositoryMoq()._bookRepository;
            _bookService = new BookService(_asyncRepository);
        }

        [Fact]
        public async Task TestMethoEditAsync()
        {
            var result = await _bookService.Edit(new Book
            {
                Id = Guid.NewGuid(),
                ModifiedBy = Guid.NewGuid(),
                ModifiedOn = DateTime.Now,
                Pages = 320,
                EditorialId= Guid.NewGuid(),
                State = true,
                Sipnosis="sdfasdfa",
                Titulo="asdfasdf"
            });

            result.Should().Be(default(Book));
        }


        [Fact]
        public async Task TestMethoCreateAsync()
        {
            var result = await _bookService.Create(new Book
            {
                Id = Guid.NewGuid(),
                ModifiedBy = Guid.NewGuid(),
                ModifiedOn = DateTime.Now,
                Pages = 320,
                EditorialId = Guid.NewGuid(),
                State = true,
                Sipnosis = "sdfasdfa",
                Titulo = "asdfasdf"
            });

            result.Should().Be(default(Book));
        }

        [Fact]
        public async Task TestMethoDeleteAsync()
        {
            var result = await _bookService.Delete(Guid.NewGuid());

            result.Should().Be(default(Book));
        }

    }
}
