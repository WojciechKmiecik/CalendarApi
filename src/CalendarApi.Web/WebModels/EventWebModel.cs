using System;
using System.Collections.Generic;
using J = System.Text.Json.Serialization.JsonPropertyNameAttribute;

namespace CalendarApi.Web.WebModels
{
    public class EventWebModel
    {
        [J("id")]
        public long Id { get; set; }
        [J("name")]
        public string Name { get; set; }
        [J("time")]
        public UInt64 Time { get; set; }
        [J("location")]
        public string Location { get; set; }
        [J("members")]
        public List<string> Members { get; set; }
        [J("eventOrganizer")]
        public string EventOrganizer { get; set; }
    }
}
