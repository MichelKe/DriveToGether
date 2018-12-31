using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DriveToGether.Controllers;
using Microsoft.AspNet.Identity;

namespace DriveToGether
{
    public partial class EventDetails : Page
    {
		//Explizite Eventseite wird geladen
        protected void Page_Load(object sender, EventArgs e)
        {
			//ID wird konvertiert
            int id = Convert.ToInt16(Request.QueryString["id"]);
			//Neue Listeninstanz wird erstellt
            HtmlGenericControl autoliste = new HtmlGenericControl("ul");
			//Funktion um Autos zu laden wird ausgeführt, danach der Tabelle hinzugefügt
            autoliste = LoadCars(id, autoliste);
			//Event wird ausgeführt
            event_details_container.Controls.Add(EventController.GetEvent(id, autoliste));
        }

        protected HtmlGenericControl LoadCars(int id, HtmlGenericControl ul)
        {
            HtmlGenericControl ulelem = ul;
			//Jedes Objekt im CarController wird ausgelesen und zurüclgegeben
            foreach (HtmlGenericControl hgc in CarController.GetCarList(id))
            { 
                ulelem.Controls.Add(hgc);
            }
            return ulelem;
        }

		//Funktion um sich einem Auto zuzuordnen
        protected void AddToCar_Click()
        {
			//ID wird konvertiert
            int id = Convert.ToInt16(Request.QueryString["id"]);
			//Userid wird ausgelesen und in Variable geschrieben
            string user_id_s = User.Identity.GetUserId();
			//ID wird kovertiert
            int user_id = Convert.ToInt16(user_id_s);

			//User wird mit einer Controllerfunktion dem zugewiesen
            CarController.AddUserToCar(id, user_id);

			//Eventseite wird aufgerufen
            Response.Redirect("/Views/Event/EventDetails.aspx?id=" + id);
        }
    }
}