namespace CalendarApi.Dal.DataModels
{
    internal class EventMembersEntity
    {
        public long EventId { get; set; }
        public EventsEntity Event { get; set; }
        public long PeopleId { get; set; }
        public PeopleEntity People { get; set; }
    }
}
