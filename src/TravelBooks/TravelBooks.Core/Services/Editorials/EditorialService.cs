using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Editorials
{
    public class EditorialService: IEditorialService
    {
        private readonly IAsyncRepository<Editorial> asyncRepository;

        public EditorialService(IAsyncRepository<Editorial> asyncRepository)
        {
            this.asyncRepository = asyncRepository;
        }

        public async Task<Editorial> Create(Editorial editorial)
        {
            return await this.asyncRepository.CreateAsync(editorial);
        }

        public async Task<Editorial> Delete(Guid Id)
        {
            var editorial = await this.asyncRepository.GetByIdAsync(Id);
            return await this.asyncRepository.DeleteAsync(editorial, editorial.Id);
        }

        public async Task<Editorial> Edit(Editorial editorial)
        {
            return await this.asyncRepository.UpdateAsync(editorial);
        }

        public async Task<IEnumerable<Editorial>> GetAllEditorials()
        {
            return await this.asyncRepository.GetAllAsync();
        }
    }
}
