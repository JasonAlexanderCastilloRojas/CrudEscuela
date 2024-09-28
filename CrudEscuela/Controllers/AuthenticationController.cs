using CrudEscuela.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrudEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string keyToken;
        public AuthenticationController(IConfiguration configuration)
        {
            keyToken = configuration.GetSection("token").GetSection("KeyToken").ToString();
        }

        [HttpPost]
        public IActionResult Authentication([FromBody] UserDTO userDTO )
        {
            if (userDTO.Email == "PruebaToken@gmail.com" && userDTO.Password == "123456") 
            {
                var keyBytes = Encoding.ASCII.GetBytes(keyToken);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userDTO.Email));

                var tokenSecurity = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHand = new JwtSecurityTokenHandler();
                var tokenConfiguration = tokenHand.CreateToken(tokenSecurity);

                string tokenCreated = tokenHand.WriteToken(tokenConfiguration);
                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreated });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }
    }
}
