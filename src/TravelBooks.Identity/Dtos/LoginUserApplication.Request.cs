using System.ComponentModel.DataAnnotations;

namespace TravelBooks.Identity.Dtos;

public record LoginUserApplicationRequest : BaseRequest
{
    [DataType(DataType.Password)]
    [MinLength(10, ErrorMessage = "The password should be longer than 10 characters.")]
    public string UserName { get; set; }
    public string Password { get; set; }
}

