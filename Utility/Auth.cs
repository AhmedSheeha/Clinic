using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clinic.Utility
{
    public class Auth
    {
       
        
        public static async Task<string?> GenerateJwtToken(ApplicationUser user, IEnumerable<string> Roles, IConfiguration configuration)
        {
            var claims = new List<Claim>() {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (var role in Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var Key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            var creds = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Issuer"],
            claims: claims,
            expires: expiration,
            signingCredentials: creds
     );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public async Task<string?> GenerateJwtToken(string userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    var Roles = await _userManager.GetRolesAsync(user);
        //    var claims = new List<Claim>() {
        //    new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    };
        //    var TokenHandler = new JwtSecurityTokenHandler();
        //    var Key = Encoding.ASCII.GetBytes("afsdkjasjflxswafsdklk434orqiwup3457u-34oewir4irroqwiffv48mfs");
        //    var TokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim("Id", userId) }),
        //        Expires = DateTime.UtcNow.AddMinutes(60),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
        //        SecurityAlgorithms.HmacSha256Signature),
        //    };

        //    var Token = TokenHandler.CreateToken(TokenDescriptor);
        //    return TokenHandler.WriteToken(Token);
        //}
    }
}
