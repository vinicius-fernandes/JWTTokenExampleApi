using JWTAuthentication.Models;

namespace JWTAuthentication.Services
{
    public interface ITokenService
    {
        UserToken BuildToken(UserInfo user);
    }
}