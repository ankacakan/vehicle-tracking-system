using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Application.IServices;

namespace VehicleTracking.Persistence.Services;

public class AuthService(IAuthRepository repo, IConfiguration config) : IAuthService
{
    private readonly IAuthRepository _repo = repo;
    private readonly IConfiguration _config = config;

    public string GenerateToken()
    {
        var client = _repo.GetByUsernameAndToken();
        var jwtSettings = _config.GetSection("Jwt");
        var secret = jwtSettings["SecretKey"]!;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
            new Claim(ClaimTypes.Name,           client.Username)
        };

        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiresMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}
