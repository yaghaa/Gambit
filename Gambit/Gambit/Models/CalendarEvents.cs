using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Gambit.Models
{
    public class CalendarEvent
    {
        public int ID;
        public string Title;
        public string FKID;
        public string StartDateString;
        public string EndDateString;
        public string StatusString;
        public string StatusColor;
        public string ClassName;

        public static List<CalendarEvent> loadAllInDateRange(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);
            using (GambitEntities ent = new GambitEntities())
            {
                var rs = ent.Wydarzenie.Where(s => s.dataGodzinaWydarzenia >= fromDate && System.Data.Objects.EntityFunctions.AddMinutes(s.dataGodzinaWydarzenia, s.dlugoscWydarzenia) <= toDate);
                List<CalendarEvent> result = new List<CalendarEvent>();
                foreach(var item in rs)
                {
                    CalendarEvent rec = new CalendarEvent();
                    rec.ID = item.wydarzenieId;
                    rec.FKID = item.Id;
                    rec.StartDateString = item.dataGodzinaWydarzenia.ToString("s");
                    rec.EndDateString = item.dataGodzinaWydarzenia.AddMinutes(item.dlugoscWydarzenia).ToString("s");
                    rec.Title = item.nazwa + " - " + item.dlugoscWydarzenia.ToString() + " min";
                    rec.StatusString = Enums.GetName<EventStatus>((EventStatus)item.rodzaj);
                    rec.StatusColor = Enums.GetEnumDescription<EventStatus>(rec.StatusString);
                    string ColorCode = rec.StatusColor.Substring(rec.StatusColor.IndexOf(":"));
                    rec.ClassName = rec.StatusColor.Substring(rec.StatusColor.IndexOf(":") + 1, rec.StatusColor.Length - ColorCode.Length + 1);
                    rec.StatusColor = ColorCode;
                    result.Add(rec);


                }
                return result;
            }
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        public static void UpdateCalendarEvent(int id, string NewEventStart, string NewEventEnd)
        {
            using (GambitEntities ent = new GambitEntities())
            {
                var rec = ent.Wydarzenie.FirstOrDefault(s => s.wydarzenieId == id);
                if(rec!=null)
                {
                    DateTime DateTimeStart = DateTime.Parse(NewEventStart, null, DateTimeStyles.RoundtripKind).ToLocalTime();
                    rec.dataGodzinaWydarzenia = DateTimeStart;
                    if(!String.IsNullOrEmpty(NewEventEnd))
                    {
                        TimeSpan span = DateTime.Parse(NewEventEnd, null, DateTimeStyles.RoundtripKind).ToLocalTime() - DateTimeStart;
                        rec.dlugoscWydarzenia = Convert.ToInt32(span.TotalMinutes);
                    }
                    ent.SaveChanges();
                }
            }
        }

        public static bool CreateNewEvent(string Title, string NewEventDate, string NewEventTime, string NewEventDuration)
        {
            try
            {
                GambitEntities ent = new GambitEntities();
                Wydarzenie rec = new Wydarzenie();
                rec.nazwa = Title;
                rec.dataGodzinaWydarzenia = DateTime.ParseExact(NewEventDate + " " + NewEventTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                rec.dlugoscWydarzenia = Int32.Parse(NewEventDuration);
                ent.Wydarzenie.Add(rec);
                ent.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


    }
}