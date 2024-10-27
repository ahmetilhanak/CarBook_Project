using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Context
{
    public static class DbDependencies
    {
        public static IServiceCollection CarBookDbConnectionString(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<CarBookContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CarBookDatabase"));

            });

            return services;
        }
    }
}
