using HotelListing.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
 using System.Runtime.CompilerServices;
using System.Text;

namespace HotelListing
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<DatabaseConext>().AddDefaultTokenProviders();

        }

        //public static void ConfigureJWT(this IServiceCollection services,IConfiguration Configuration )
        //{
        //    var jwtSettigs = Configuration.GetSection("Jwt");
        //    var key = Environment.GetEnvironmentVariable("KEY");

        //    services.AddAuthentication(o =>
        //    {
        //        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


        //    })
        //      .AddJwtBearer(o =>
        //      {
        //          o.TokenValidationParameters = new TokenValidationParameters
        //          {
        //              ValidateIssuer = true,
        //              ValidateLifetime = true,
        //              ValidateIssuerSigningKey = true,
        //             ValidIssuer = jwtSettigs.GetSection("Issuer").Value,
                      

        //              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),

        //          };
        //      });

         


        }
    }
 
 
