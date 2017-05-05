using System;

namespace GambitApi.Models.Entities
{
    public class Event
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public DateTime Hour { get; set; }

        public string Kind { get; set; }

        public int WydarzenieId { get; set; }

        public string Id { get; set; }
    }
}