using LojaVirtual.Domain.Abstractions;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infrastructure.Context;
using LojaVirtual.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LojaVirtualDbContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });

            //services.AddIdentity<User, IdentityRole<Guid>>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = false;
            //    options.User.RequireUniqueEmail = true;
            //})
            //    .AddEntityFrameworkStores<LojaVirtualDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddScoped(typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartProductRepository, CartProductRepository>();

            return services;
        }
    }
}
