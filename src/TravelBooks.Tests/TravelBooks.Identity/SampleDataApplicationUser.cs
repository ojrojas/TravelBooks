namespace TravelBooks.Tests.TravelBooks.Identity;
internal static class SampleDataApplicationUser
{

    public static IEnumerable<ApplicationUser> GetUsersApplications() =>
        new List<ApplicationUser>
        {
           new ApplicationUser {
        Name = "Fernando",
        LastName = "Fernandez",
        UserName = "fernando@test.com",
        Password = "Abc123456#",
                Email = "fernando@test.com",
        MiddleName = string.Empty,
        CreatedBy = Guid.NewGuid(),
        CreatedOn = DateTime.UtcNow,
        State = true
    },
           new ApplicationUser  {
        Name = "Pedro",
        LastName = "Perez",
        UserName = "pedro@test.com",
        Password = "Abc123456#",
        Email = "pedro@test.com",
        MiddleName = string.Empty,
        CreatedBy = Guid.NewGuid(),
        CreatedOn = DateTime.UtcNow,
        State = true
    },
           new ApplicationUser  {
        Name = "Maria",
        LastName = "Mendez",
        UserName = "maria@test.com",
        Password = "Abc123456#",
        Email = "maria@test.com",
        MiddleName = string.Empty,
        CreatedBy = Guid.NewGuid(),
        CreatedOn = DateTime.UtcNow,
        State = true
        } };

}
