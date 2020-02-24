using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalendarApi.Dal
{
    public static class DIConfig
    {
        public static void ConfigureDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CalendarContext>(c =>
            {
                c.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });
        }
    }
}
