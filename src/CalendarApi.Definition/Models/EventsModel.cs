using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApi.Definition.Models
{
    public class EventsModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public long OrganizerId { get; set; }
        public string OrganizerName { get; set; }
        public List<PeopleModel> EventMembers { get; set; }
        public List<string> EventMembersStr { get; set; }
    }
}
