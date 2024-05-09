using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace UMS.GROUP.Airport.Booking.Web.Infrastructure;

public static class JwtExtention
{
    public static void AddJwtExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwt =>
        {
            jwt.SaveToken = true;
            jwt.RequireHttpsMetadata = false;
            jwt.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Secret").Value ?? "")),
                ValidAudience = configuration.GetSection("AppSettings:Id").Value,
                ValidIssuer = configuration.GetSection("AppSettings:Id").Value,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                ValidateAudience = true,
                ValidateIssuer = true
            };
        });
    }
}
