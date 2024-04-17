using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace senac.projetoIntegrador.Authentication
{
    public class ConfigureJwt
    {
        public JwtSettings _jwtSettings { get; set; }

        public ConfigureJwt(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;    
        }

        public void ConfigureJwtMethod(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";

            })
            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = 
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                    ValidateIssuer = true,
                    ValidIssuer = _jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = _jwtSettings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(_jwtSettings.MinutesToExpiration)
                };
            });

            services.AddAuthorization();
        }

        public string BuildJwtToken(string login)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Key));

            List<Claim> jwtClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
            };

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                jwtClaims,
                DateTime.Now,
                DateTime.Now.AddMinutes(_jwtSettings.MinutesToExpiration),
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
