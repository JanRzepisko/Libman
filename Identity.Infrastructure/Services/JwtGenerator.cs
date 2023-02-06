using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Identity.Application.Services;
using Identity.Domain.Entities;
using Identity.Domain.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.BaseModels.Jwt;

namespace Identity.Infrastructure.Services;

public class JwtGenerator : IJwtGenerator
{
    private readonly JwtLogin _jwtLogin;
    
    public JwtGenerator(JwtLogin jwtLogin)
    {
        _jwtLogin = jwtLogin;
    }

    public Task<JwtResult> GenerateJwt(User user)
    {
        byte[] key = Encoding.ASCII.GetBytes(_jwtLogin.Key);

        //tu add claims
        //TODO GET CONFIGURATION FORM APPSETTINGS    
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.Name!),
                new Claim("Surname", user.Surname!),
                new Claim("Email", user.Email!),
                new Claim("Role", "User")
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Audience = _jwtLogin.Audience,
            Issuer = _jwtLogin.Issuer,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(new JwtResult(tokenHandler.WriteToken(token)));
    }
}