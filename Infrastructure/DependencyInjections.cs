using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjections
    {


        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            if (configuration.GetValue<bool>("UserInMemoryDb"))
            {

                services.AddDbContext<ApplicationDbContext>(ops =>
                {
                    ops.UseInMemoryDatabase("BankAppDb");
                });
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(ops =>
                {
                    ops.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"), ops =>
                    {

                        ops.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    });
                });

            }

            services.AddScoped<IDbContext, ApplicationDbContext>();
            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped<IDomainEventService, DomainEventService>();
            return services;

        }
    }
}
