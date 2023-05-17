using System;
namespace TravelBooks.Identity.Dtos;

public record GetApplicationUserByIdRequest: BaseRequest
{
    public Guid Id { get; set; }
}

