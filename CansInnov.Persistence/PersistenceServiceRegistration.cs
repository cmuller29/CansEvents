using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Application.Contracts.Persistence;
using CansInnov.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CansInnov.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration["Environment"] == "Local")
            {
                services.AddDbContext<CansEventsDbContext>(options =>
                       options.UseSqlite(configuration.GetConnectionString("EventsConnectionString"))
                   ); 
            }
            else
            {
                services.AddDbContext<CansEventsDbContext>(options =>
                       options.UseSqlServer(configuration.GetConnectionString("EventsConnectionString"))
                   );
            }

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}