using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBookService
    {
        Task<Book> Create(Book book);
        Task<Book> Edit(Book book);
        Task<Book> Delete(Guid Id);
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
