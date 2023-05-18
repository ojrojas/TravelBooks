namespace TravelBooks.Identity.Specifications;

public class ApplicationUserSpecification : Specification<ApplicationUser>
{
    public ApplicationUserSpecification(string UserName)
    {
        Query.Where(i => i.UserName == UserName);
    }

    public ApplicationUserSpecification(string UserName, string Password)
    {
        Query.Where(i => i.UserName == UserName && i.Password == Password);
    }

    public ApplicationUserSpecification(Guid Id)
    {
        Query.Where(i => i.Id == Id);
    }
}