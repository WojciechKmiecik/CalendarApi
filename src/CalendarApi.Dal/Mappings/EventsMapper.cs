using CalendarApi.Dal.DataModels;
using CalendarApi.Definition.Models;

namespace CalendarApi.Dal.Mappings
{
    internal static class EventssMapper
    {
        public static EventsEntity Map(this EventsModel model)
        {
            var entity = new EventsEntity();
            if (model != null)
            {
                //entity.Id = model.Id; 
                entity.Name = model.Name;
                entity.ScheduledDateTime = model.ScheduledDateTime;
                entity.Organizer = new PeopleEntity() { Id = model.OrganizerId, Name = model.OrganizerName };
                
                //TODO : extend it
            }
            return entity;
        }
        public static EventsModel Map(this EventsEntity entity, EventsModel incomingModel = null)
        {
            var model = incomingModel ?? new EventsModel();
            if (entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.ScheduledDateTime = entity.ScheduledDateTime;
                model.CreatedDateTime = entity.CreatedDateTime;
                model.LocationId = entity.Location?.Id ?? 0;
                model.LocationName = entity.Location?.Name;
                //model.EventMembers  <- map many to many relation
                //TODO : extend it
            }
            return model;
        }
    }
}
