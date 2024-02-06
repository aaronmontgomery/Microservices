using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Identity.Entities;
using Identity.Services;
using DavesList.Entities;
using DavesList.Repositories;
using DavesList.Services;

namespace DavesList.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddDbContext<IdentityContext>(x =>
            {
                x.UseSqlServer("Data Source=localhost;Initial Catalog=Identity;User ID=sa;Password=localadmin;TrustServerCertificate=True");
            });
            
            builder.Services.AddDbContext<DavesListContext>(x =>
            {
                x.UseSqlServer("Data Source=localhost;Initial Catalog=DavesList;User ID=sa;Password=localadmin;TrustServerCertificate=True");
            });

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
            
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Validate issuer, audience, and signing key
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    // Specify the issuer, audience, and signing key
                    ValidIssuer = "your-issuer",
                    ValidAudience = "your-audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hb23h872be_$da11fvh8b1@^&$%_dvdjf"))
                };
            });
            
            builder.Services.AddAuthorization();

            builder.Services.AddScoped<IRepository, Repository>();
            
            builder.Services.AddScoped<IIdentityAccountService, IdentityAccountService>();
            
            builder.Services.AddScoped<IAccountService, AccountService>();
            
            builder.Services.AddScoped<IPostService, PostService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();
            
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.MapControllers();

            app.Run();
        }
    }
}
