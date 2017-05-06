using System;

namespace GambitApi.Models.Entities
{
    public class Note
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int NotatkaId { get; set; }

        public int WydarzenieId { get; set; }

        public int Id { get; set; }
    }
}