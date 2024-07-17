using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

public class TokenService
{
    private readonly IConfiguration _configuration; 

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string Generate(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
				var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = credentials,
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
        };
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    public void Decode(string token2)
    {
        var tokenDecode = token2.Split(".");
        var result = Convert.FromBase64String(tokenDecode[1]);
        var dataJson= Encoding.UTF8.GetString(result);
        var data = JsonSerializer.Deserialize<Dictionary<string,object>>(dataJson);
        foreach(var d in data)
            Console.WriteLine(d.Key + " - "+ d.Value);
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var ci = new ClaimsIdentity();
        ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
        foreach (var role in user.Roles)
            ci.AddClaim(new Claim(ClaimTypes.Role, role));

        return ci;
    }
}