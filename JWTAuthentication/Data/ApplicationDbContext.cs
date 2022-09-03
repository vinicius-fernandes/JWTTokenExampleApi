using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JWTAuthentication.Models;
namespace JWTAuthentication.Data
{
    public abstract class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions options,IConfiguration configuration) : base(options)
        {
            _configuration= configuration;
        }
    }
}