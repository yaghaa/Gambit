using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gambit.Models;

namespace Gambit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Calendar()
        {
            

            return View();
        }
        public void UpdateEvent(int id, string NewEventStart, string NewEventEnd)
        {
            CalendarEvent.UpdateCalendarEvent(id, NewEventStart, NewEventEnd);
        }

        public bool SaveEvent(string Title, string NewEventDate, string NewEventTime, string NewEventDuration)
        {
            return CalendarEvent.CreateNewEvent(Title, NewEventDate, NewEventTime, NewEventDuration);

        }

        public JsonResult GetCalendarEvents(double start, double end)
        {
            var ApptListForDate = CalendarEvent.loadAllInDateRange(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                calId = e.ID,
                                title = e.Title,
                                start = e.StartDateString,
                                end = e.EndDateString,
                                className = e.ClassName,
                                color = e.StatusColor,
                                fkID = e.FKID,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

    }
}