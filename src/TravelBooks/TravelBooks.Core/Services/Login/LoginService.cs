using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IAsyncIdentityRepository _asyncIdentityRepository;
        private readonly ITokenClaims _tokenClaims;

        public LoginService(IAsyncIdentityRepository asyncIdentityRepository, ITokenClaims tokenClaims)
        {
            _asyncIdentityRepository = asyncIdentityRepository;
            _tokenClaims = tokenClaims;
        }

        public async Task<string> Login(ApplicationUser user)
        {
            user.DecryptedPassword = user.Password;
           return await _tokenClaims.GetTokenAsync(user.UserName, user.Password);
        }
    }
}