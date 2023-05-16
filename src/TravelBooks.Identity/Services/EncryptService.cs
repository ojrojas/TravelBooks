namespace TravelBooks.Identity.Services;

public class EncryptService : IEncryptService
{
    private readonly ILogger<EncryptService> _logger;
    private readonly OptionEncrypt _options;

    public EncryptService(IOptions<OptionEncrypt> options, ILogger<EncryptService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _options = options.Value ?? throw new InvalidCastException(nameof(options));
    }

    public async Task<string> Encrypt(string password, bool useHashing = true)
    {
        try
        {
            _logger.LogInformation($"Encrypt password options encryptation options");
            var encrypted = KeyDerivation.Pbkdf2(password,
                                                 Encoding.UTF8.GetBytes(_options.Salt),
                                                 KeyDerivationPrf.HMACSHA512,
                                                 _options.Iterations,
                                                 _options.SizeKey);

            await Task.Yield();

            return Encoding.UTF8.GetString(encrypted);
        }
        catch (Exception ex)
        {
            await Task.Yield();
            _logger.LogError("Encrypt fail password result null", ex.Message);
            return null;
        }
    }
}

