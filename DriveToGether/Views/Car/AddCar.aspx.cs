using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DriveToGether.Models;
using DriveToGether.Controllers;

namespace DriveToGether.Account
{
    public partial class addCar : Page
    {
		//Funktion beim Klicken de hinzufügen Buttons
        protected void AddCar_Click(object sender, EventArgs e)
        {
            //Routerparam wird zu zwei seperaten Strings konvertiert
            string identifier = (Request.QueryString["id"]).ToString();
            string[] identifiers = identifier.Split('_');
            string eventName = identifiers.First();
            string eventDate = identifiers.Last();

            //Eventdatum String zu DateTime konvertieren
            DateTime event_date = Convert.ToDateTime(eventDate);

            //Auto wird in Liste in CarController hinzugefügt
            CarController.addCar( Autonummer.Text, Fahrzeugname.Text, Convert.ToInt16(Plaetze.Text), CarDetails.Text, FahrerVorname.Text, FahrerNachname.Text, eventName, event_date);

			//Seite des entsprechenden Events wird aufgerufen
			Response.Redirect("/Views/Event/EventDetails.aspx?id="+ identifier);
        }
		//Beim Abbrechen wird diese Funktion aufgerufen
        protected void RedirectBack_Click(object sender, EventArgs e)
        {
            //ID wird konvertiert
            string identifier = (Request.QueryString["id"]).ToString();
            //Seite des entsprechenden Events wird aufgerufen
            Response.Redirect("/Views/Event/EventDetails.aspx?id=" + identifier);
        }
    }
}