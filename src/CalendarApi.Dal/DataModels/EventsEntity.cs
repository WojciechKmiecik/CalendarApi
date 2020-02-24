using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarApi.Dal.DataModels
{
    internal class EventsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public LocationsEntity Location { get; set; }
        public PeopleEntity Organizer { get; set; }
        public List<EventMembersEntity> EventsMembers { get; set; }
        // next properties

    }
}
