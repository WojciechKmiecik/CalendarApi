using CalendarApi.Dal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalendarApi.Logic
{
    public static class DIConfig
    {
        public static void ConfigureLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDalServices(configuration);
        }
    }
}
