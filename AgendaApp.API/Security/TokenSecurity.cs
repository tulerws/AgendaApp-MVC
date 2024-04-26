using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AgendaApp.API.Security
{
    public class TokenSecurity
    {
        #region Atributos

        public static string? SecurityKey => "5d977582-3d35-4314-865a-e5da36700d2e";
        public static int? ExpirationInHours => 1;

        #endregion

        /// <summary>
        /// Método para gerar o token jwt da API
        /// </summary>
        public static string GenerateToken(Guid usuarioId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecurityKey);

            //criando o token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //gravando no token a identificação do usuário (email)
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, usuarioId.ToString()) }),

                //data de expiração do token
                Expires = DateTime.UtcNow.AddHours(ExpirationInHours.Value),

                //assinatura antifalsificação do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            };

            //retornando o token
            var accessToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(accessToken);
        }
    }
}



