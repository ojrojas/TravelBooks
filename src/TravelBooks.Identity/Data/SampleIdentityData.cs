namespace TravelBooks.Identity.Data;

public class SampleIdentityData
{
    public ApplicationUser GetUserApplication()
    => new()
    {
        Name = "Pepe",
        LastName = "Perez",
        UserName = "pepe@test.com",
        Password = "Abc123456#",
        Email = "pepe@test.com",
        MiddleName = string.Empty,
        CreatedBy = Guid.NewGuid(),
        CreatedOn = DateTime.UtcNow,
        State = true
    };
}

