using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.Interfaces.Notifications;
using LojaVirtual.Application.Services;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace LojaVirtual.Application;
public static class ConfigurationModule
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services,
                IConfiguration configuration)
    {

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<INotificationHandler, NotificationHandler>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddHttpClient();
        services.AddIdentity<User, IdentityRole<Guid>>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
        })
            .AddEntityFrameworkStores<LojaVirtualDbContext>()
            .AddDefaultTokenProviders();

        services.AddControllers();

        var info = new OpenApiInfo();
        info.Version = "V1";
        info.Title = "API LojaVirtual";

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", info);
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insira o token JWT desta maneira : Bearer {seu token}",
                Name = "Authorization",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"

            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                     {
                         new OpenApiSecurityScheme
                         {
                             Reference = new OpenApiReference
                             {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                             },
                             Scheme = "oauth2",
                             Name = "Bearer",
                             In= ParameterLocation.Header,

                         },
                         new List<string>()
                     }
                });
        });

        return services;
    }
}