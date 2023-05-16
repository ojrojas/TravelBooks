namespace TravelBooks.Infraestructure.Interfaces;

public interface IAsyncRepository<T> where T : class, IAggregateRoot
{
    Task<int> CountAsync(CancellationToken cancellationToken);
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken);
    Task<T> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken);
    Task<IEnumerable<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
}
