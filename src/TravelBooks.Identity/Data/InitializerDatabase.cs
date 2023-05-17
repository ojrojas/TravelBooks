namespace TravelBooks.Identity.Data;

public class InitializerDatabase
{
    private readonly TravelBooksIdentityContext _context;
    private readonly ILogger<InitializerDatabase> _logger;
    private readonly IEncryptService _encryptService;

    public InitializerDatabase(TravelBooksIdentityContext context, ILogger<InitializerDatabase> logger, IEncryptService encryptService)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _encryptService = encryptService ?? throw new ArgumentNullException(nameof(encryptService));
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Delete exists database in development environment");
            await _context.Database.EnsureDeletedAsync();
            _logger.LogInformation("Create datebase in development environment");
            await _context.Database.EnsureCreatedAsync();
            _logger.LogInformation("Create data sample base applicationuser");
            await CreateSampleData(cancellationToken);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    private async ValueTask CreateSampleData(CancellationToken cancellationToken)
    {
        SampleIdentityData sampleIdentityData = new();
        var sampleIdentity = sampleIdentityData.GetUserApplication();
        sampleIdentity.Password = await _encryptService.Encrypt(sampleIdentity.Password);
        await _context.ApplicationUsers.AddAsync(sampleIdentity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        await Task.CompletedTask;
    }
}

