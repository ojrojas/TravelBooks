namespace TravelBooks.Infraestructure.Data;

public abstract class BaseEntity
{
    public virtual Guid Id { get; set; }
    public virtual bool State { get; set; }
    public virtual DateTime CreatedOn { get; set; }
    public virtual DateTime ModifiedOn { get; set; }
    public virtual Guid CreatedBy { get; set; }
    public virtual Guid ModifiedBy { get; set; }
}

