using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace tributrek.Utilidades
{
    public class JwtHelper
    {
        public static string GenerarToken(string nombreUsuario, string secretKey, int expiracionEnMinutos)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, nombreUsuario),
                // Puedes agregar más claims, como el rol
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "tributrek",
                audience: "tributrek",
                claims: claims,
                expires: DateTime.Now.AddMinutes(expiracionEnMinutos),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
