using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DriveToGether.Models
{
    public class Mitglied
    {
        //Membervariaben
        public string Vorname;
        public string Nachname;
        public string Geburtstag;
        public string Mail;
        public string Anschrift;
        public string Ortsname;
        public string PLZ;
        public string Rollenname;

        //Mitglied Konstruktor
        public Mitglied(string vorname, string nachname, string geburtstag, string mail, string anschrift, string ortsname, string plz, string rollenname)
        {
            Vorname = vorname;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Mail = mail;
            Anschrift = anschrift;
            Ortsname = ortsname;
            PLZ = plz;
            Rollenname = rollenname;
        }


        //Daten des Mitglieds auslesen
        public static List<Mitglied> getMitglied(Mitglied Mitglied)
        {
            return DB.getUser(Mitglied);
        }

        public static List<Mitglied> getMitgliedViaEmail(string email)
        {
            return DB.getUserViaEmail(email);
        }

        //Mitglied hinzufügen
        public static List<Mitglied> addMitglied(Mitglied newMitglied)
        {
            return DB.addUser(newMitglied);
        }

        //Mitglied editieren
        public static List<Mitglied> updateMitglied(Mitglied newMitglied)
        {
            return DB.updateUser(newMitglied);
        }

        //public static getMitgliedIdentity()
        //{
        //    string user_id_s = User.Identity.GetUserId();
        //    return user_id_s;
        //}
    }
}