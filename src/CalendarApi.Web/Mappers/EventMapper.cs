using CalendarApi.Definition.Models;
using CalendarApi.Web.WebModels;
using CalendarApi.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApi.Web.Mappers
{
    public static class EventMapper
    {
        public static EventWebModel Map(this EventsModel model)
        {
            var webModel = new EventWebModel();
            if (model != null)
            {
                webModel.Id = model.Id; 
                webModel.Name = model.Name;
                webModel.Time = model.ScheduledDateTime.ToUnixTime();
                webModel.Members = model.EventMembers.Select(x => x.Name).ToList() ?? new List<string>();
                webModel.Location = model.LocationName;
                webModel.EventOrganizer = model.OrganizerName;
                //TODO : extend it
            }
            return webModel;
        }
        public static EventsModel Map(this EventWebModel webModel, EventsModel incomingModel = null)
        {
            var model = incomingModel ?? new EventsModel();
            if (webModel != null)
            {
                model.Id = webModel.Id;
                model.Name = webModel.Name;
                model.ScheduledDateTime = webModel.Time.FromUnixTime();
                model.LocationName = webModel.Location;
                model.EventMembersStr = webModel.Members;
                model.OrganizerName = webModel.EventOrganizer;
                
                //TODO : extend it
            }
            return model;
        }
    }
}
