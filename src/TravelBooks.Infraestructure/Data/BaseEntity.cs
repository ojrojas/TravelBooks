namespace TravelBooks.Infraestructure.Data;

/// <summary>
/// Base entity 
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Key primary all entities derivateds
    /// </summary>
    public virtual Guid Id { get; set; }
    public virtual bool State { get; set; }
    public virtual DateTime CreatedOn { get; set; }
    public virtual DateTime ModifiedOn { get; set; }
    public virtual Guid CreatedBy { get; set; }
    public virtual Guid ModifiedBy { get; set; }
}

