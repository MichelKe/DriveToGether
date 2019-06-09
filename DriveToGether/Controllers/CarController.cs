using DriveToGether.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace DriveToGether.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

       
        //Farzeugliste laden
        public static List<Car> getCarList(string eventName, string eventDate)
        {
            DateTime event_date = Convert.ToDateTime(eventDate);
            return Car.getCarList(eventName, event_date);
        }
        
		//Auto hinzufügen
        public static void addCar(string autonummer, string name, int plaetze, string details, string vorname_fahrer, string nachname_fahrer, string event_name, DateTime event_datum)
        {
			//Neuer DB Eintrag wird erstellt
            Car newCar = new Car(autonummer, name, plaetze, details, vorname_fahrer, nachname_fahrer, event_name, event_datum);
            //Funktion um Auto in Tabelle hinzuzufügen wird erstellt
            Car.addCar(newCar);
        }

        //Auto auswählen
        public static List<Car> selectCar(string eventName, DateTime eventDate, string autonummer)
        {
            return Car.selectCar(eventName, eventDate, autonummer);
        }

        //Auto anpassen
        public static List<Car> modifyCar(string autonummer, string name, int plaetze, string details, string vorname_fahrer, string nachname_fahrer, string event_name, DateTime event_datum)
        {
            Car newCar = new Car(autonummer, name, plaetze, details, vorname_fahrer, nachname_fahrer, event_name, event_datum);
            return Car.modifyCar(newCar);
        }

        //Auto löschen
        public static List<Car> deleteCar(string eventName, DateTime eventDate, string autonummer)
        {
            return DB.deleteCar(eventName, eventDate, autonummer);
        }

        //Passagiere laden
        public static List<CarMitglied> getPassangersForCar(string eventName, DateTime eventDate, string autonummer)
        {
            return CarMitglied.getPassangers(eventName, eventDate, autonummer);
        }

        //Passagier hizufügen
        public static List<CarMitglied> addPassangerToCar(CarMitglied newPass)
        {
            return CarMitglied.addPassanger(newPass);
        }

        //Passagier entfernen
        public static List<CarMitglied> removePassangerFromCar(CarMitglied removePass)
        {
            return CarMitglied.removePassanger(removePass);
        }

        //Autoliste mit Passagieren wird zurückgegeben 
        public static List<HtmlGenericControl> getHtmlCarList(string eventName, string eventDate)
        {
            //Eventdatum String zu DateTime konvertieren
            DateTime event_date = Convert.ToDateTime(eventDate);

            //Gibt Mitfahrerliste zurück
            List<Car> AutoListe = Car.getCarList(eventName, event_date);

			//Neue Listinstanz wird erstellt
            List<HtmlGenericControl> AutoHTML = new List<HtmlGenericControl>();

			//Jedes Auto in der Liste wird durchlaufen
            foreach (Car auto in AutoListe)
            {

                List<CarMitglied> passangers = CarMitglied.getPassangers(eventName, event_date, auto.Autonummer);
                DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
                string date = event_date.ToString("d", fmt);
                string routingParam = eventName + "_" + date;
                string mitfahrerString = "";
                string carNr = auto.Autonummer;

				//Jeder Passagier wird durchlaufen
                foreach (CarMitglied passagier in passangers)
               {

                    mitfahrerString += passagier.ToString() + " ";
               }

				//HTML Element wird erstellt

                    string htmltxt = "<asp:LinkButton ID='addToCarBtn' runat='server'  class='btn btn-default' OnCommand='AddToCar_Click' CommandArgument='"+routingParam+";"+carNr+ "'>Einschreiben</a>";
                    //string htmltxt = "<a runat='server' class='btn btn-default' onServerClick='EventDetails.AddToCar_Click' href='/Views/Event/EventDetails.aspx?id="+routingParam+"&car="+carNr+"'>Einschreiben</a>";
                    string htmltxt1 = "<br>";
                    HtmlGenericControl htmlelem = new HtmlGenericControl("li");
                    htmlelem.InnerHtml = string.Format("{0}, {1}, {2}; Freie Plätze: {3} {4} {5} {6}", auto.Name, auto.Fahrer_Vorname, auto.Fahrer_Nachname, (auto.Plaetze - passangers.Count) , htmltxt, htmltxt1, mitfahrerString);

				    //Element wird hinzugefügt
                    AutoHTML.Add(htmlelem);
                
            }
			//View wird hinzugefpgt
            return AutoHTML;
        }
    }
}