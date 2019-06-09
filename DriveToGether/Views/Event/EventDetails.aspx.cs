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
        public void Page_Load(object sender, EventArgs e)
        {
			//Routerparameter wird in zwei sparate Strings konvertiert
            string identifier = (Request.QueryString["id"]).ToString();
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


        public HtmlGenericControl LoadCars(string eventName, string eventDate , HtmlGenericControl ul)
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
        public void AddToCar_Click(object sender, GridViewCommandEventArgs e)
        {
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');
            string param = arg[0];
            string[] splitparam = param.Split('_');
            string eventName = splitparam[0];
            string eventDate = splitparam[1];
            string carNr = arg[1];
            //Routingparameter wird erzeugt
            //string identifier = (Request.QueryString["id"]).ToString();
            //string[] identifiers = identifier.Split('_');
            //string eventName = identifiers.First();
            //string eventDate = identifiers.Last();
            DateTime event_date = Convert.ToDateTime(eventDate);

            //string carNr = (Request.QueryString["car"]).ToString();

            //Useremail wird ausgelesen und in Variable geschrieben
            string username = User.Identity.Name;

            List<Mitglied> user = MitgliedController.getMitgliedViaEmail(username);
            Mitglied mitglied = user.ElementAt(0);
            DateTime geburtstag = Convert.ToDateTime(mitglied.Geburtstag);

            List<Car> auto = CarController.selectCar(eventName, event_date, carNr);
            //string vorname, string nachname, DateTime geburtsdatum, string autonummer, string eventname, DateTime eventdatum      
            CarMitglied newPass = new CarMitglied(mitglied.Vorname, mitglied.Nachname, geburtstag, carNr, eventName, event_date);

			//User wird mit einer Controllerfunktion dem zugewiesen
            CarController.addPassangerToCar(newPass);

            //Neue UL-Listeninstanz wird erstellt
            HtmlGenericControl autoListe = new HtmlGenericControl("ul");

            //Funktion um Autos zu laden wird ausgeführt, danach der Tabelle hinzugefügt
            autoListe = LoadCars(eventName, eventDate, autoListe);

            event_details_container.Controls.Add(EventController.GetEvent(eventName, event_date, autoListe));


            //Eventseite wird aufgerufen
            Response.Redirect("/Views/Event/EventDetails.aspx?id=" + param);
        }
    }
}