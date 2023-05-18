namespace TravelBooks.Tests.TravelBooks.Identity;

public class ApplicationUserShould
{
    private IApplicationUserService _service;

    [Fact]
    public async Task ApplicationUserShould_Login()
    {
        //Arr
        await GetApplicationUserService();
        LoginUserApplicationResponse response;
        try
        {
            //Ave
            response = await _service.LoginAsync(new LoginUserApplicationRequest()
            {
                UserName = "maria@test.com",
                Password = "Abc123456#"
            }, CancellationToken.None);
        }

        catch (SqliteException ex)
        {
            throw new Exception(ex.Message);
        }

        Assert.NotNull(response);
        Assert.False(string.IsNullOrEmpty(response.Token));
    }

    [Fact]
    public async Task ApplicationUserShould_ListApplicationUsers()
    {
        //Arr
        await GetApplicationUserService();
        ListApplicationUserResponse response;
        response = await _service.GetAllUserApplicationsAsync(new ListApplicationUserRequest(), CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.ApplicationUsers.Any());
    }

    [Fact]
    public async Task ApplicationUserShould_CreateUserApplication()
    {
        var userName = "test";
        var password = "testtest12345";
        //Arr
        await GetApplicationUserService();
        CreateApplicationResponse response;
        LoginUserApplicationResponse responseLogin;
        var user = new CreateApplicationRequest
        {
            ApplicationUser = new ApplicationUser
            {
                LastName = "Test",
                Name = "Test",
                UserName = userName,
                Password = password,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = Guid.NewGuid(),
                Email = "Test@test.com",
                MiddleName = string.Empty
            }
        };

        var loging = new LoginUserApplicationRequest()
        {
            UserName = userName,
            Password = password
        };

        response = await _service.CreateUserApplicationAsync(user, CancellationToken.None);
        responseLogin = await _service.LoginAsync(loging, CancellationToken.None);

        Assert.NotNull(response);
        Assert.False(string.IsNullOrEmpty(responseLogin.Token));
    }

    [Fact]
    public async Task ApplicationUserShould_UpdateUserApplication()
    {
        var name = "Sandra";
        var lastName = "Sanchez";
        // Arr
        await GetApplicationUserService();
        var listUserApplications = await _service.GetAllUserApplicationsAsync(new ListApplicationUserRequest(), CancellationToken.None);

        var userToUpdate = listUserApplications.ApplicationUsers.LastOrDefault();
        userToUpdate.Name = name;
        userToUpdate.LastName = lastName;

        UpdateApplicationUserRequest request = new UpdateApplicationUserRequest
        {
            ApplicationUser = userToUpdate
        };

        //Ave
        UpdateApplicationUserResponse response = await _service.UpdateUserApplicationAsync(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.ApplicationUserUpdated.Name.Equals(name));
        Assert.True(response.ApplicationUserUpdated.LastName.Equals(lastName));
    }

    [Fact]
    public async Task ApplicationUserShould_RemoveUserApplication()
    {
        var name = "Sandra";
        var lastName = "Sanchez";
        // Arr
        await GetApplicationUserService();
        var listUserApplications = await _service.GetAllUserApplicationsAsync(new ListApplicationUserRequest(), CancellationToken.None);

        var userToUpdate = listUserApplications.ApplicationUsers.LastOrDefault();
        userToUpdate.Name = name;
        userToUpdate.LastName = lastName;

        DeleteApplicationUserRequest request = new DeleteApplicationUserRequest
        {
            Id = userToUpdate.Id
        };

        //Ave
        DeleteApplicationUserResponse response = await _service.DeleteUserApplicationAsync(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.ApplicationUserDeleted.Name.Equals(name));
        Assert.True(response.ApplicationUserDeleted.LastName.Equals(lastName));
    }

    [Fact]
    public async Task ApplicationUserShould_GetByIdUserApplication()
    {
        // Arr
        await GetApplicationUserService();
        var listUserApplications = await _service.GetAllUserApplicationsAsync(new ListApplicationUserRequest(), CancellationToken.None);
        var userToFound = listUserApplications.ApplicationUsers.FirstOrDefault();
        GetApplicationUserByIdRequest request = new GetApplicationUserByIdRequest
        {
            Id = userToFound.Id
        };

        GetApplicationUserByIdResponse response = await _service.GetApplicationUserByIdAsync(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.ApplicationUserFound.Name.Length > default(int));
        Assert.True(response.ApplicationUserFound.LastName.Length > default(int));
    }


    private async Task GetApplicationUserService()
    {
        var keepAliveConnection = new SqliteConnection("DataSource=:memory:");
        keepAliveConnection.Open();
        var options = new DbContextOptionsBuilder<TravelBooksIdentityContext>().UseSqlite(keepAliveConnection).Options;
        var context = new TravelBooksIdentityContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var usersApplications = SampleDataApplicationUser.GetUsersApplications().ToList();

        ILoggerFactory _loggerFactory = LoggerFactory.Create(factory => factory.AddConsole());
        IdentityRepository _repository = new IdentityRepository(_loggerFactory.CreateLogger<IdentityRepository>(),
            context);
        var optionEncrypt = Options.Create(new OptionEncrypt
        {
            Iterations = 1000,
            PassPhrase = "TESTESTESTEST",
            Salt = Guid.NewGuid().ToString(),
            SizeKey = 64
        });

        var tokenOption = Options.Create(new OptionToken
        {
            SecretPhrase = "TR#!$%@V31B@@UIDOSDFKAuthKeyOfDoomThatMustBeAMinimumNumberOfBytes"
        });

        var encryptService = new EncryptService(optionEncrypt, _loggerFactory.CreateLogger<EncryptService>());
        usersApplications.ForEach(async x => x.Password = await encryptService.Encrypt(x.Password));
        await context.ApplicationUsers.AddRangeAsync(usersApplications);
        context.SaveChangesAsync(CancellationToken.None);
        var users = context.ApplicationUsers;
        _service = new ApplicationUserService(
            _repository,
            encryptService,
            _loggerFactory.CreateLogger<ApplicationUserService>(),
            new TokenService<ApplicationUser>(_loggerFactory.CreateLogger<TokenService<ApplicationUser>>(), tokenOption));
    }
}