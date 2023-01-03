using API_Login.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Login.Services
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> usuarioIdentity, string role)
        {
            Claim[] direitosUsuario = new Claim[]
            {
                new Claim(ClaimTypes.Name, usuarioIdentity.UserName),
                new Claim("id", usuarioIdentity.Id.ToString()),
                new Claim(ClaimTypes.Role, "manager")
            };

            var chave = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("hello world hello world hello world"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(direitosUsuario),
                SigningCredentials = credenciais,
                Expires = DateTime.UtcNow.AddHours(2)

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new Token(tokenString);
    }
}
}
