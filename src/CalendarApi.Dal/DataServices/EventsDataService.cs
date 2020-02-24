using CalendarApi.Dal.DataModels;
using CalendarApi.Dal.Mappings;
using CalendarApi.Definition.DataServices;
using CalendarApi.Definition.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApi.Dal.DataServices
{

    internal class EventsDataService : IEventsDataService
    {
        private readonly CalendarContext _context;

        public EventsDataService(CalendarContext context)
        {
            _context = context;
        }
        // add exception handling
        public async Task<List<EventsModel>> GetAll(bool sortedByDescTime = false)
        {
            var e = (await _context.Events.ToListAsync()).Select(x => x.Map()).ToList();
            if (sortedByDescTime)
            {
                e = e.OrderByDescending(x => x.ScheduledDateTime).ToList();
            }
            return e;
        }
        public async Task<EventsModel> GetById(long Id)
        {
            var e = (await _context.Events.FirstOrDefaultAsync(x => x.Id == Id)).Map();
            return e;
        }
        public async Task<EventsModel> GetByName(string name)
        {
            var e = (await _context.Events.FirstOrDefaultAsync(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase))).Map();
            return e;
        }
        public async Task<List<EventsModel>> GetByOrganizer(string organizerName)
        {
            var e = (await _context.Events.Include(x => x.Organizer).Where(x => x.Organizer.Name.Equals(organizerName, StringComparison.OrdinalIgnoreCase)).Select(x => x.Map(null)).ToListAsync());
            return e;
        }
        public async Task<List<EventsModel>> GetByLocation(string locationName)
        {
            var e = (await _context.Events.Include(x => x.Location).Where(x => x.Location.Name.Equals(locationName, StringComparison.OrdinalIgnoreCase)).Select(x => x.Map(null)).ToListAsync());
            return e;
        }
        public async Task<EventsModel> AddEvent(EventsModel model)
        {
            await _context.AddAsync(model);
            var id = await _context.SaveChangesAsync();
            return await this.GetById(id);
        }
        public async Task<EventsModel> UpdateEvent(long Id, EventsModel model)
        {
            var e = (await _context.Events.FirstOrDefaultAsync(x => x.Id == Id));
            if (e == null)
            {
                await Task.CompletedTask;
                return null;
            }
            e = e.Map(model).Map();
            _context.Update(e);
            await _context.SaveChangesAsync();
            return await this.GetById(Id);
        }
        public async Task<bool> DeleteEvent(long Id)
        {
            var e = (await _context.Events.FirstOrDefaultAsync(x => x.Id == Id));
            if (e == null)
            {
                return false;
            }
            _context.Remove(e);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
