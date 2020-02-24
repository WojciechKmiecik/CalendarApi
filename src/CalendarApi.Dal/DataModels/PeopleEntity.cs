using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarApi.Dal.DataModels
{
    internal class PeopleEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public List<EventsEntity> Events { get; set; }
        public List<EventMembersEntity> EventMembers { get; set; }

        // next guys, like surname, ... 

    }
}
