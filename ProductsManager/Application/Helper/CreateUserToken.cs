using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProductsManager.Application.Interface;
using ProductsManager.Application.Model;

namespace ProductsManager.Application.Helper;

public class CreateUserToken : ICreateUserToken
{
    private readonly IConfiguration _config;

    public CreateUserToken(IConfiguration config)
    {
        _config = config;
    }

    public string Execute(Login login)
    {
        var jwtConfig = _config.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtConfig["Key"]!);
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new[]
        {
            new Claim("id", $"{login.Id}"),
            new Claim("user", login.User),
            new Claim(ClaimTypes.Role, login.Role)
        };

        var identity = new ClaimsIdentity(claims);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ),
            Issuer = jwtConfig["Issuer"],
            Audience = jwtConfig["Audience"]
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
