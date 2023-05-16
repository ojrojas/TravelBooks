using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IAsyncRepository<Book> asyncRepository;

        public BookService(IAsyncRepository<Book> asyncRepository)
        {
            this.asyncRepository = asyncRepository;
        }

        public async Task<Book> Create(Book book)
        {
            return await this.asyncRepository.CreateAsync(book);
        }

        public async Task<Book> Delete(Guid Id)
        {
            var book = await this.asyncRepository.GetByIdAsync(Id);
            return await this.asyncRepository.DeleteAsync(book, book.Id);
        }

        public async Task<Book> Edit(Book book)
        {
            return await this.asyncRepository.UpdateAsync(book);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await this.asyncRepository.GetAllAsync();
        }
    }
}
