using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AppStatus.Api.Framework;
using AppStatus.Api.Framework.Constants;
using AppStatus.Api.Framework.Shared;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AppStatus.Api.Shared
{
    public class JwtManager : IJwtManager
    {
        private readonly IOptions<ApplicationOptions> _options;

        public JwtManager(IOptions<ApplicationOptions> options)
        {
            _options = options;
        }

        public string GenerateToken(string sessionId, string accountId, string name, string family, DateTime expirationDate)
        {
            var mySecret = _options.Value.JwtSecret;
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Sid, sessionId), new Claim(ClaimTypes.NameIdentifier, accountId), new Claim(ClaimTypes.Name, $"{name} {family}")
                }),
                Claims = new Dictionary<string, object>()
                {
                    {
                        CustomClaims.AccountId, accountId
                    }
                },

                Expires = expirationDate,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
