using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WS_SistemaVenta.Models;
using WS_SistemaVenta.Models.Common;
using WS_SistemaVenta.Models.Request;
using WS_SistemaVenta.Models.Response;
using WS_SistemaVenta.Tools;

namespace WS_SistemaVenta.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest model)
        {
            using (var db = new SistemaVentasContext())
            {
                string sPasswordHash = Encrypt.GetSHA256(model.PasswordHash);

                var user = db.Users.Where(d => d.Email == model.Email &&
                    d.PasswordHash == sPasswordHash).FirstOrDefault();

                if(user == null) return null;

                UserResponse userResponse = new UserResponse();
                
                userResponse.Email = user.Email;
                userResponse.Token = GetToken(user);

                return userResponse;
            }
        }

        private string GetToken(User User)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Codename);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),
                        new Claim(ClaimTypes.Email, User.Email)
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
