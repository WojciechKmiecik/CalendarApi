using CalendarApi.Dal.DataModels;
using CalendarApi.Dal.Mappings;
using CalendarApi.Definition.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApi.Definition.DataServices;

namespace CalendarApi.Dal.DataServices
{

    internal class LocationsDataService : ILocationsDataService
    {
        private readonly CalendarContext _context;

        public LocationsDataService(CalendarContext context)
        {
            _context = context;
        }
        // add exception handling
        public async Task<LocationModel> Get(string name)
        {
            var item = await _context.Locations.FirstOrDefaultAsync(x => x.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            return item.Map();
        }
        public async Task<LocationModel> Add(string name)
        {
            var entity = new LocationsEntity() { Name = name };
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await this.Get(name);
        }

    }
}
