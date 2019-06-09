using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DriveToGether.Controllers;
using DriveToGether.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DriveToGether
{
    public partial class EventDetails : Page
    {
		//Explizite Eventseite wird geladen
        protected void Page_Load(object sender, EventArgs e)
        {
			//Routerparameter wird in zwei sparate Strings konvertiert
            string identifier = (Request.QueryString["routeparam"]).ToString();
            string[] identifiers = identifier.Split('_');
            string eventName = identifiers.First();
            string eventDate = identifiers.Last();
			
            //Neue UL-Listeninstanz wird erstellt
            HtmlGenericControl autoListe = new HtmlGenericControl("ul");
            
            //Funktion um Autos zu laden wird ausgeführt, danach der Tabelle hinzugefügt
            autoListe = LoadCars(eventName, eventDate, autoListe);

            //Eventdatum String zu DateTime konvertieren
            DateTime event_date = Convert.ToDateTime(eventDate);

			//Event wird ausgeführt
            event_details_container.Controls.Add(EventController.GetEvent(eventName, event_date, autoListe));
        }


        protected HtmlGenericControl LoadCars(string eventName, string eventDate , HtmlGenericControl ul)
        {
            //Jedes Objekt im CarController wird ausgelesen und zurückgegeben
            List<HtmlGenericControl> carList = CarController.getHtmlCarList(eventName, eventDate);

            HtmlGenericControl ulElement = ul;
			
            foreach (HtmlGenericControl hgc in carList)
            {
                ulElement.Controls.Add(hgc);
            }
            return ulElement;
        }

		//Funktion um sich einem Auto zuzuordnen
        protected void AddToCar_Click()
        {
            //Routingparameter wird erzeugt
            string identifier = (Request.QueryString["routeparam"]).ToString();
            string[] identifiers = identifier.Split('_');
            string eventName = identifiers.First();
            string eventDate = identifiers.Last();

            //Userid wird ausgelesen und in Variable geschrieben
            string user_id_s = User.Identity.GetUserId();
            
            
            //User.Identity. -- we neeeddddd the userrrr
			//ID wird kovertiert
            int user_id = Convert.ToInt16(user_id_s);

            //string username = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(ID).;

            //string vorname, string nachname, DateTime geburtsdatum, string autonummer, string eventname, DateTime eventdatum      
            CarMitglied newPass = new CarMitglied("", "", DateTime.Now, "", "", DateTime.Now);

			//User wird mit einer Controllerfunktion dem zugewiesen
            CarController.addPassangerToCar(newPass);

			//Eventseite wird aufgerufen
            Response.Redirect("/Views/Event/EventDetails.aspx?id=" + identifier);
        }
    }
}