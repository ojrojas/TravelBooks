using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using Core.Entities;

namespace TravelBooks.Identity.Interfaces
{
    /// <summary>
    /// IAsyncRepository App
    /// </summary>
    public interface IAsyncIdentityRepository :  IAggregateRoot
    {
       Task<ApplicationUser> FindApplicationUser(ISpecification<ApplicationUser> spec);
       Task<ApplicationUser> CreateApplicationUser(ApplicationUser entity);
       Task<ApplicationUser> UpdateApplicationUser(ApplicationUser entity);
       Task<ApplicationUser> DeleteApplicationUser(ApplicationUser entity);
       Task<ApplicationUser> LoginAppUser(ApplicationUser entity);
       Task<IReadOnlyList<ApplicationUser>> GetAllAsync();
    }
}