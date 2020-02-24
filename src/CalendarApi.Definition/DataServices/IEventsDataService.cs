using CalendarApi.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApi.Definition.DataServices
{
    public interface IEventsDataService
    {
        Task<bool> DeleteEvent(long Id);
        Task<List<EventsModel>> GetAll(bool sortedByDescTime = false);
        Task<EventsModel> GetById(long Id);
        Task<List<EventsModel>> GetByLocation(string locationName);
        Task<EventsModel> GetByName(string name);
        Task<List<EventsModel>> GetByOrganizer(string organizerName);
        Task<EventsModel> AddEvent(EventsModel model);
        Task<EventsModel> UpdateEvent(long Id, EventsModel model);
    }
}
