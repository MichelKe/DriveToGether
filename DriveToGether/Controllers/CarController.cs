using DriveToGether.Models;
using System;
using System.Collections.Generic;
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

		//Fügt Auto hinzu
        public static void AddCar(string Name, string Fahrer, string Details, int Plaetze, int EventID)
        {
			//Neuer DB Eintrag wird erstellt
            Car Auto = new Car(DB.GetCarID(), Name, Fahrer, Details, Plaetze, EventID);
			//Funktion um Auto in Tabelle hinzuzufügen wird erstellt
            Auto.AddCar();
        }

		//AutoListe wird zurpckgegeben 
        public static List<HtmlGenericControl> GetCarList(int id)
        {
			//Variable wird beschrieben
            List<Car> AutoListe = Car.GetCarList(id);
			//Neue Listinstanz wird erstellt
            List<HtmlGenericControl> AutoHTML = new List<HtmlGenericControl>();

			//Jedes Auto in der Liste wird durchlaufen
            foreach (Car auto in AutoListe)
            {
                List<int> mitfahrer = CarController.GetUsersForCar(auto.ID);
                string mitfahrerString = "";
				//Jeder Passagier wird durchlaufen
                foreach (int passagier in mitfahrer)
                {
                    mitfahrerString += passagier.ToString() + " ";
                }

				//HTML Element wird erstellt
                string htmltxt = "<a runat='server' class='btn btn-default' onServerClick='AddToCar_Click' href='/Views/Event/EventDetails.aspx?id="+id+"'>Einschreiben</a>";
                string htmltxt1 = "<br>";
                HtmlGenericControl htmlelem = new HtmlGenericControl("li");
                htmlelem.InnerHtml = string.Format("{0}, {1}, {2} {3} {4} {5}", auto.Name, auto.Fahrer, (auto.Plaetze - mitfahrer.Count) , htmltxt, htmltxt1, mitfahrerString);

				//Element wird hinzugefügt
                AutoHTML.Add(htmlelem);
            }
			//View wird hinzugefpgt
            return AutoHTML;
        }

		//Gibt Mitfahrer zurück
        public static List<int> GetUsersForCar(int car_id)
        {
            List<int> MitfahrerListe = Dist.GetUsersForCar(car_id);
            return MitfahrerListe; 
        }

		//Fügt User einem Auto hinzu
        public static void AddUserToCar(int car_id, int user_id)
        {
            Dist.AddUserToCar(car_id, user_id);
	    }
    }
}