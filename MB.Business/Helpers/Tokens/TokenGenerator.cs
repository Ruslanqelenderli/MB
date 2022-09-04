using MB.Business.Concrete.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Helpers.Tokens
{
    public class TokenGenerator
    {
        
        public static string GenerateJwtToken(AppUserDto dto)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                
                var key = Encoding.UTF8.GetBytes("My Security Key....");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.NameIdentifier,dto.Id.ToString()),
                    new Claim(ClaimTypes.Name,dto.Email)
                }),
                    Expires = DateTime.UtcNow.AddHours(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
    }
}
