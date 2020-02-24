using CalendarApi.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApi.Definition.Services
{
    public interface ICalendarService
    {
        Task AddEvent(EventsModel model);
        Task<bool> DeleteEvent(long id);
        Task<List<EventsModel>> GetAll(bool sortedByDescTime = false);
        Task<List<EventsModel>> GetQuery(string eventOrganizer, long? id, string location, string name);
        Task<EventsModel> UpdateEvent(long Id, EventsModel model);
    }
}
