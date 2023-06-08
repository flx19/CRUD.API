using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using one.hr.api.Models;
using One.HR.DataAccess.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace one.hr.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel registermodel)
        {
            var foundUsr = await _userManager.FindByNameAsync(registermodel.Username);
            if (foundUsr != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "error", Message = "user already exisist"});
            }
            var User = new AppUser
            {
                Email= registermodel.Email,
                UserName = registermodel.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var result = await _userManager.CreateAsync(User,registermodel.Password);
            if (!result.Succeeded)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "error", Message = "user creation failed"});
            }
            return Ok(new ResponseModel { Status = "success",Message= "OK"});
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel loginmodel)
        {
            var foundUsr = await _userManager.FindByNameAsync(loginmodel.Username);
            if(foundUsr != null && await _userManager.CheckPasswordAsync(foundUsr, loginmodel.Password))
            {
                var roles = await _userManager.GetRolesAsync(foundUsr);
                List<Claim> claims = new List<Claim>();
                Claim claim1 = new Claim(ClaimTypes.Name, foundUsr.UserName);
                Claim claim2 = new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString());
                claims.Add(claim1);
                claims.Add(claim2);
                foreach(var claim in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, claim));
                }

                var syymetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(_configuration["JWT:ValidIssuer"], _configuration["JWT:ValidAudience"], claims
                    , expires: DateTime.UtcNow.AddHours(1), signingCredentials: new SigningCredentials(syymetricKey, SecurityAlgorithms.HmacSha256));

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
    }
}
