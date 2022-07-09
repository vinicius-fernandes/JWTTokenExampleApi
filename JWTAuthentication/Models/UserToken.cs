using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JWTAuthentication.Models
{
    public class UserToken
    {
        public string? Token{get;set;}
        public DateTime Expiration {get;set;}

    }
}