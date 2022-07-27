using Microsoft.AspNetCore.Identity;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using JWTAuthentication.Services;
using Microsoft.AspNetCore.Authorization;
namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;


        public UsersController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            ITokenService tokenService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(){
            return Ok(_userManager.Users);
        }


        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model){
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return _tokenService.BuildToken(model);
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email,userInfo.Password,isPersistent:false,lockoutOnFailure:true);
            if(result.Succeeded){
                return _tokenService.BuildToken(userInfo);
            }
            else{
                return BadRequest("Usuário ou senha inválidos");
            }
        }

        }
}