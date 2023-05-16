using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthorService
    {
        Task<Author> Create(Author author);
        Task<Author> Edit(Author author);
        Task<Author> Delete(Guid Id);
        Task<IEnumerable<Author>> GetAllAuthors();
    }
}
