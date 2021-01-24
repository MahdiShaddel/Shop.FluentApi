using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shop.Host.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Host.Security
{
    public class TokenGenerator
    {
        public static string GenerateEncodedToken(IdentityUser user)
        {
            var claims = new[]
            {
                new Claim("IsMahdi", user.UserName.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Warning"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "www.mft.com",
                audience: "www.mft.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(2000),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
