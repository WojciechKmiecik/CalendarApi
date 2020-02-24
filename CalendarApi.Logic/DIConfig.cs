using CalendarApi.Dal;
using CalendarApi.Definition.Services;
using CalendarApi.Logic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalendarApi.Logic
{
    public static class DIConfig
    {
        public static void ConfigureLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDalServices(configuration);
            services.AddScoped<ICalendarService, CalendarService>();
        }
    }
}
