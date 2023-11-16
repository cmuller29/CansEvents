using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Application.Features;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CansInnov.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(
                    AppDomain.CurrentDomain.GetAssemblies()
                );
                configuration.Lifetime = ServiceLifetime.Scoped;
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic));

            services.AddSingleton(typeof(ValidatorHelper<,>));

            return services;
        }
    }
}