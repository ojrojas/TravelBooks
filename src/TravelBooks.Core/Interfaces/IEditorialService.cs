using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEditorialService
    {
        Task<Editorial> Create(Editorial editorial);
        Task<Editorial> Edit(Editorial editorial);
        Task<Editorial> Delete(Guid Id);
        Task<IEnumerable<Editorial>> GetAllEditorials();
    }
}
