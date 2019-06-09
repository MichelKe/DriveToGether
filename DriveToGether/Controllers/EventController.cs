using DriveToGether.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace DriveToGether.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

		
        public static List<HtmlGenericControl> GetEventList()
        {
            List<Event> EventListe = Event.getEventList();
            List<HtmlGenericControl> EventHtml = new List<HtmlGenericControl>();
            
			//HTML element wird erstellt
            foreach (Event ev in EventListe)
            {
                DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
                string date = ev.Datum.ToString("d", fmt);
                string routingParam = ev.Name + "_" + date;
                string seltxt = "<div class='row'><div class='col-md-10'><h2>{0}</h2><p>{1}</p><p>{2}</p></div><div class='col-md-2'><a href='/Views/Event/EventDetails.aspx?id={3}' />Eventdetails anzeigen</a></div></div>";
                string htmltxt = string.Format(seltxt, ev.Name, ev.Details, date, routingParam);
                HtmlGenericControl htmlelem = new HtmlGenericControl("div");
                htmlelem.InnerHtml = htmltxt;
				//Element wird hinzugefügt
                EventHtml.Add(htmlelem);
            }
			//Seite wird zurückgegeben
            return EventHtml;
        }

        public static HtmlGenericControl GetEvent(string Name, DateTime Datum, HtmlGenericControl ul)
        {
			//HTML Element wird erstellt
            List<Event> rawEvent = Event.getEvent(Name, Datum);
            Event ev = rawEvent.ElementAt(0);
            HtmlGenericControl EventHtml = new HtmlGenericControl("div");
            DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            string date = ev.Datum.ToString("d", fmt);
            string routingParam = ev.Name + "_" + date;
            string seltxt = "<h3>{0}</h3><div class='row'><div class='col-md-6'><h2>Details</h2><p>{1}</p><p>{2}, {3}</p></div><div class='col-md-6'><div class='row'><h2>{4}</h2></div><div class='row'><h2>Autos</h2>";
            string seltxt2 = "<div><a runat='server' class='btn btn-default' href='/Views/Car/AddCar.aspx?id={0}'>auto hinzufügen &raquo;</a></div></div></div></div>";
            string htmltxt = string.Format(seltxt, ev.Name, ev.Details, ev.PLZ, ev.Ortsname, date);
            string htmltxt2 = string.Format(seltxt2, routingParam);
            EventHtml.InnerHtml = htmltxt + PrintUl(ul) + htmltxt2;
            
			//Element wird zurückgegeben
            return EventHtml;
        }

		//Tabelle wird mit Einträgen erstellt
        public static string PrintUl(HtmlGenericControl ul)
        {
            StringBuilder generatedHtml = new StringBuilder();
            using (var htmlStringWriter = new StringWriter(generatedHtml))
            {
                using (var htmlTextWriter = new HtmlTextWriter(htmlStringWriter))
                {
					//Zeile wird hinzugefügt
                    ul.RenderControl(htmlTextWriter);
					//Element wird ausgegeben
                    return generatedHtml.ToString();
                }
            }
        }
    }
}