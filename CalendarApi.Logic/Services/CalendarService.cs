using CalendarApi.Dal.DataModels;
using CalendarApi.Definition.DataServices;
using CalendarApi.Definition.Models;
using CalendarApi.Definition.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApi.Logic.Services
{
    internal class CalendarService : ICalendarService
    {
        private readonly IPeopleDataService _people;
        private readonly ILocationsDataService _locations;
        private readonly IEventsDataService _events;

        public CalendarService(IPeopleDataService people, ILocationsDataService locations, IEventsDataService events)
        {
            _people = people;
            _locations = locations;
            _events = events;
        }
        public async Task AddEvent(EventsModel model)
        {
            try
            {
                // not paraler, because im using the same resource. 
                var people = await _people.AddNonExistingPeople(model.EventMembersStr);
                var organizer = await _people.AddNonExistingPeople(new List<string>() { model.OrganizerName });
                model.EventMembers = people;
                model.OrganizerId = organizer.FirstOrDefault()?.Id ?? 0;

                LocationModel location = await _locations.Get(model.LocationName);
                if (location == null)
                {
                    location = await _locations.Add(model.LocationName);
                }
                model.LocationId = location.Id;

                await _events.AddEvent(model);

            }
            catch (Exception e) // catch less general exception and log it with logger, or application insights
            {
                Debug.WriteLine(e.Message);
            }
        }
        public async Task<bool> DeleteEvent(long id)
        {
            try
            {
                var result = await _events.DeleteEvent(id);
                return result;
            }
            catch (Exception e) // catch less general exception and log it with logger, or application insights
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        public async Task<EventsModel> UpdateEvent(long Id, EventsModel model)
        {
            try
            {
                var result = await _events.UpdateEvent(Id, model);
                return result;
            }
            catch (Exception e) // catch less general exception and log it with logger, or application insights
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }
        public async Task<List<EventsModel>> GetAll(bool sortedByDescTime = false)
        {
            try
            {
                var result = await _events.GetAll(sortedByDescTime);
                return result;
            }
            catch (Exception e) // catch less general exception and log it with logger, or application insights
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }
        public async Task<List<EventsModel>> GetQuery(string eventOrganizer, long? id, string location, string name)
        {
            try
            {
                if (id.HasValue)
                {
                    var e = (await _events.GetById(id.Value));
                    return new List<EventsModel>() { e };
                }
                if (!string.IsNullOrWhiteSpace(name))
                {
                    var e = (await _events.GetByName(name));
                    return new List<EventsModel>() { e };
                }
                if (!string.IsNullOrWhiteSpace(eventOrganizer))
                {
                    var e = (await _events.GetByOrganizer(eventOrganizer));
                    return e;
                }
                if (!string.IsNullOrWhiteSpace(location))
                {
                    var e = (await _events.GetByLocation(location));
                    return e;
                }

                return new List<EventsModel>();
            }
            catch (Exception e) // catch less general exception and log it with logger, or application insights
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

    }
}
