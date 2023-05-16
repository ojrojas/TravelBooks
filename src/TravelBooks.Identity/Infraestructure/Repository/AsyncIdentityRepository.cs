using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.AppContext;
using Microsoft.EntityFrameworkCore;

namespace TravelBooks.Identity.Infraestructure;
public class AsyncIdentityRepository : IAsyncIdentityRepository, IAggregateRoot
{
    /// <summary>
    /// Database context App
    /// </summary>
    private readonly AppDbContext _context;

    /// <summary>
    /// Constructor 
    /// </summary>
    /// <param name="context"></param>
    public AsyncIdentityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApplicationUser> CreateApplicationUser(ApplicationUser entity)
    {
        entity.DecryptedPassword = entity.Password;
        var newEntity = _context.ApplicationUsers.Add(entity).Entity;
        await _context.SaveChangesAsync();
        return newEntity;
    }

    public async Task<ApplicationUser> DeleteApplicationUser(ApplicationUser entity)
    {
        _context.ApplicationUsers.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ApplicationUser> FindApplicationUser(ISpecification<ApplicationUser> spec)
    {
        var evaluator = new SpecificationEvaluator<ApplicationUser>();
        var specification = evaluator.GetQuery(_context.ApplicationUsers, spec);
        return await specification.FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<ApplicationUser>> GetAllAsync()
    {
        return await _context.ApplicationUsers.ToListAsync();
    }

    public async Task<ApplicationUser> LoginAppUser(ApplicationUser entity)
    {
        var result = await _context.ApplicationUsers.ToListAsync();
        entity.DecryptedPassword = entity.Password;
        return result.Find(x => x.UserName == entity.UserName && x.Password == entity.Password);
    }

    public async Task<ApplicationUser> UpdateApplicationUser(ApplicationUser entity)
    {
        entity.DecryptedPassword = entity.Password;
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
}
