using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pruebaED01.Model.RequestResponse;
using pruebaED01.Negocio;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pruebaED01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {

        AuthNegocio authNegocio = new AuthNegocio();

        #region seccion apis
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {

            //ataque de fuerza masiva ==> 
            //usuario no existe 
            //password incorrecto ==> "ADMINISTRADOR"
            if (!authNegocio.login(request))
            {
                return StatusCode(401, "Usuario y/o password invalido");
            }

            LoginResponse response = new LoginResponse();
            response.Token = CreateToken();
            response.RefreshToken = "";


            return Ok(response);
        }

        #endregion seccion apis


        #region otros metodos

        private static string CreateToken()
        {

            //create claims details based on the user information
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();
            // Leemos el archivo de configuración.
            int TimpoVidaToken = int.Parse(configurationFile["Jwt:TimeJWTMin"]);

            //PERÚ UTC-5 UTC-0
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, configurationFile["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", "1"),
                        new Claim("DisplayName", "FRANKLIN HUAMAN ARAUJO"),
                        new Claim("UserName", "FHUAMAN"),
                        new Claim(ClaimTypes.Role, "Administrador"),
                        new Claim("Email", "fhuaman@continental.edu.pe")
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationFile["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configurationFile["Jwt:Issuer"],
                configurationFile["Jwt:Audience"],
                claims,
                //expires: DateTime.UtcNow.AddMinutes(TimpoVidaToken),
                expires: DateTime.UtcNow.AddMinutes(TimpoVidaToken),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion


    }
}
