using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Authors
{
    public  class AuthorService : IAuthorService
    {
        private readonly IAsyncRepository<Author> _asyncRepository;

        public AuthorService(IAsyncRepository<Author> asyncRepository)
        {
            this._asyncRepository = asyncRepository;
        }

        public async Task<Author> Create(Author author)
        {
            return await this._asyncRepository.CreateAsync(author); 
        }

        public async Task<Author> Delete(Guid Id)
        {
            var author = await this._asyncRepository.GetByIdAsync(Id);
            return await this._asyncRepository.DeleteAsync(author, author.Id);
        }

        public async Task<Author> Edit(Author author)
        {
            return await this._asyncRepository.UpdateAsync(author);
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await this._asyncRepository.GetAllAsync();
        }
    }
}
