using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using EduRankCR.Domain.Common.Interfaces.Auth;
using EduRankCR.Domain.Common.Interfaces.Services;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Infrastructure.Configuration;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EduRankCR.Infrastructure.Auth;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;

        var settings = jwtOptions.Value;
        _jwtSettings = new JwtSettings
        {
            Secret = Environment.GetEnvironmentVariable("jwt-secret") ?? settings.Secret,
            Issuer = Environment.GetEnvironmentVariable("jwt-issuer") ?? settings.Issuer,
            Audience = Environment.GetEnvironmentVariable("jwt-audience") ?? settings.Audience,
            ExpiryMinutes = int.TryParse(Environment.GetEnvironmentVariable("jwt-expiry-minutes"), out var minutes)
                ? minutes
                : settings.ExpiryMinutes,
        };
    }

    public string GenerateToken(User user)
    {
        // print secret to console FOR DEBUGGING PURPOSES
        Console.WriteLine(_jwtSettings.Secret);
        Console.WriteLine(_jwtSettings.Issuer);
        Console.WriteLine(_jwtSettings.Audience);
        Console.WriteLine(_jwtSettings.ExpiryMinutes);
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.Name),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.Now.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}