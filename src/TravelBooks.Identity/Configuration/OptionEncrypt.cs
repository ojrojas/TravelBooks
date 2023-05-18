namespace TravelBooks.Identity.Configuration;

/// <summary>
/// Encrypt configuration
/// </summary>
public class OptionEncrypt
{
    public string Salt { get; set; }
    public string PassPhrase { get; set; }
    public int SizeKey { get; set; }
    public int Iterations { get; set; }
}

