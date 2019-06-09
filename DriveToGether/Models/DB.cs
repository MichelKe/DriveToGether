using DriveToGether.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
	//Listklasse 
    public class DB
    {
        public static string m_dbconnectstring = "Data Source=(local); Integrated Security = true"; 
        public static SqlConnectionStringBuilder m_dbstringbuilder = new SqlConnectionStringBuilder(m_dbconnectstring);
        public static SqlConnection m_dbconn = new SqlConnection();

        public DB()
        {
            m_dbstringbuilder["Database"] = "DriveToGether";
            m_dbconn = new SqlConnection(m_dbstringbuilder.ConnectionString);
        }

        //Execute SQL Funktionen

        //Event SQL execution
        public static List<Event> executeEventSql(string sqlstring)
        {
            using (SqlConnection dbConn = new SqlConnection(m_dbstringbuilder.ConnectionString))
            {
                dbConn.Open();

                SqlCommand eventCmd = new SqlCommand(sqlstring);
                //m_dbconn.Open();
                eventCmd.Connection = dbConn;

                string sqlSubstringEvent = sqlstring.Substring(0, 6);
                List<Event> eventReturnList = new List<Event>();

                if (sqlSubstringEvent == "SELECT")
                {
                    using (SqlDataReader reader = eventCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Event eventLine = new Event(reader["Name"].ToString(), Convert.ToDateTime(reader["Date"]), reader["Beschreibung"].ToString(), reader["Ortsname"].ToString(), reader["PLZ"].ToString());
                            eventReturnList.Add(eventLine);
                        }
                    }
                }
                dbConn.Close();
                return eventReturnList;
            }
           
        }

        //Car SQL execution
        public static List<Car> executeCarSql(string sqlstring)
        {
            using (SqlConnection dbConn = new SqlConnection(m_dbstringbuilder.ConnectionString))
            {
                dbConn.Open();

                SqlCommand carCmd = new SqlCommand(sqlstring);

                carCmd.Connection = dbConn;

                string sqlSubstringCar = sqlstring.Substring(0, 6);
                List<Car> carReturnList = new List<Car>();

                if (sqlSubstringCar == "SELECT")
                {
                    using (SqlDataReader reader = carCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int plaetze = Convert.ToInt32(reader["Plaetze"]);
                            Car carLine = new Car(reader["Autonummer"].ToString(), reader["Name"].ToString(), plaetze, reader["Beschreibung"].ToString(), reader["VornameFahrer"].ToString(), reader["NachnameFahrer"].ToString(), reader["EventName"].ToString(), Convert.ToDateTime(reader["EventDate"]));
                            carReturnList.Add(carLine);
                        }
                    }
                }
                else if (sqlSubstringCar == "INSERT" || sqlSubstringCar == "UPDATE" || sqlSubstringCar == "DELETE")
                {
                    carCmd.ExecuteNonQuery();
                }
                dbConn.Close();
                return carReturnList;
            }
        }

        //CarMitglied SQL execution
        public static List<CarMitglied> executeCarMitgliedSql(string sqlstring)
        {
            using (SqlConnection dbConn = new SqlConnection(m_dbstringbuilder.ConnectionString))
            {
                dbConn.Open();
                SqlCommand carMitgliedCmd = new SqlCommand(sqlstring);
                carMitgliedCmd.Connection = dbConn;

                string sqlSubstringCarMitglied = sqlstring.Substring(0, 6);
                List<CarMitglied> carMitgliedReturnList = new List<CarMitglied>();

                if (sqlSubstringCarMitglied == "SELECT")
                {
                    using (SqlDataReader reader = carMitgliedCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarMitglied carMitgliedLine = new CarMitglied(reader["Vorname"].ToString(), reader["Nachname"].ToString(), Convert.ToDateTime(reader["Geburtstag"]), reader["Autonummer"].ToString(), reader["EventName"].ToString(), Convert.ToDateTime(reader["EventDate"]));
                            carMitgliedReturnList.Add(carMitgliedLine);
                        }
                    }

                }
                else if (sqlSubstringCarMitglied == "INSERT" || sqlSubstringCarMitglied == "UPDATE" || sqlSubstringCarMitglied == "DELETE")
                {
                    carMitgliedCmd.ExecuteNonQuery();
                }
                dbConn.Close();
                return carMitgliedReturnList;
            }
        }

        //Mitglied SQL execution
        public static List<Mitglied> executeMitgliedSql(string sqlstring)
        {
            using (SqlConnection dbConn = new SqlConnection(m_dbstringbuilder.ConnectionString))
            {
                SqlCommand mitgliedCmd = new SqlCommand(sqlstring);
                mitgliedCmd.Connection = m_dbconn;

                string sqlSubstringMitglied = sqlstring.Substring(0, 6);
                List<Mitglied> mitgliedReturnList = new List<Mitglied>();

                if (sqlSubstringMitglied == "SELECT")
                {
                    using (SqlDataReader reader = mitgliedCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Mitglied carMitgliedLine = new Mitglied(reader["Vorname"].ToString(), reader["Nachname"].ToString(), reader["Geburtstag"].ToString(), reader["Email"].ToString(), reader["Anschrift"].ToString(), reader["Ortsname"].ToString(), reader["PLZ"].ToString(), reader["Rollenname"].ToString());
                            mitgliedReturnList.Add(carMitgliedLine);
                        }
                    }

                }
                else if (sqlSubstringMitglied == "INSERT" || sqlSubstringMitglied == "UPDATE" || sqlSubstringMitglied == "DELETE")
                {
                    mitgliedCmd.ExecuteNonQuery();
                }
                dbConn.Close();
                return mitgliedReturnList;
            }
            
        }


        //Event funktionen

        //Gibt Eventliste zurück
        public List<Event> getEventList()
        {
            string sqlstring = "SELECT * FROM dbo.Event";
            return executeEventSql(sqlstring);
        }
              
        //Gibt ausgewähltes Event zurück
        public static List<Event> getEvent(string name, DateTime datum)
        {
            DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            string date = datum.ToString("d", fmt);
            string sqlstring = "SELECT * FROM dbo.Event WHERE Name = '" + name + "' AND Date = '" + date + "'";
            return executeEventSql(sqlstring);
        }

        //Auto funktionen

        //Fahrzeugliste für ausgewähltes Event laden
        public static List<Car> getEventCarList(string eventName, DateTime eventDate)
        {
            DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            string date = eventDate.ToString("d", fmt);
            string sqlstring = "SELECT * FROM dbo.Auto WHERE EventName='" + eventName + "' AND EventDate='" + date + "'";

            return executeCarSql(sqlstring);
        }

        //Select Car
        public static List<Car> selectCar(string eventName, DateTime eventDate, string autonummer)
        {
            DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            string date = eventDate.ToString("d", fmt);
            string sqlstring = "SELECT * FROM dbo.Auto WHERE Autonummer='" + autonummer + "' AND EventName = '" + eventName + "' AND EventDate = '" + date + "'";
            return executeCarSql(sqlstring);
        }

        //Insert Car
        public static List<Car> insertCar(Car newCar)
        {
            DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            string date = newCar.Event_Datum.ToString("d", fmt);
            string sqlstring = "INSERT INTO dbo.Auto (Autonummer, Name, Plaetze, Beschreibung, VornameFahrer, NachnameFahrer, EventName, EventDate) VALUES ('" + newCar.Autonummer + "', '" + newCar.Name + "', " + newCar.Plaetze + ", '" + newCar.Details + "', '" + newCar.Fahrer_Vorname + "', '" + newCar.Fahrer_Nachname + "', '" + newCar.Event_Name + "', '" + date + "')";
            executeCarSql(sqlstring);
            return getEventCarList(newCar.Event_Name, newCar.Event_Datum);
        }

        //Update Car
        public static List<Car> updateCar(Car newCar)
        {
            DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            string date = newCar.Event_Datum.ToString("d", fmt);
            string sqlstring = "UPDATE dbo.Auto SET Name = '" + newCar.Name + "', Plaetze = " + newCar.Plaetze + ", Beschreibung = '" + newCar.Details + "', VornameFahrer = '" + newCar.Fahrer_Vorname + "', NachnameFahrer = '" + newCar.Fahrer_Nachname + "' WHERE Autonummer = '" + newCar.Autonummer + "' AND EventName = '" + newCar.Event_Name + "' AND EventDate = '" + date + "'";
            executeCarSql(sqlstring);
            return getEventCarList(newCar.Event_Name, newCar.Event_Datum);
        }

        //Delete Car
        public static List<Car> deleteCar(string eventName, DateTime eventDate, string autonummer)
        {
            DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            string date = eventDate.ToString("d", fmt);
            string sqlstring1 = "DELETE FROM dbo.Auto WHERE Autonummer = '" + autonummer + "' AND EventName = '" + eventName + "' AND EventDate = '" + date + "'";
            string sqlstring2 = "DELETE FROM dbo.AutoMitglied WHERE Autonummer = '" + autonummer + "' AND EventName = '" + eventName + "' AND EventDate = '" + date + "'";
            
            executeCarSql(sqlstring1);
            executeCarSql(sqlstring2);

            return getEventCarList(eventName, eventDate);
        }


        //Mitfahrer funktionen

        //Mitfahrer für ein Fahrzeug laden
        public static List<CarMitglied> getPassangersForCar(string eventName, DateTime eventDate, string autonummer)
        {
            DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            string date = eventDate.ToString("d", fmt);
            string sqlstring = "SELECT * FROM dbo.AutoMitglied WHERE Autonummer = '" + autonummer + "' AND EventName = '" + eventName + "' AND EventDate = '" + date + "'";
            return executeCarMitgliedSql(sqlstring);
        }

        //Mitglied als Mitfahrer eintragen
        public static List<CarMitglied> addPassengerToCar(CarMitglied newPass)
        {
            DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            string date = newPass.Eventdatum.ToString("d", fmt);
            string sqlstring = "INSERT INTO dbo.AutoMitglied (Vorname, Nachname, Geburtstag, Autonummer, EventName, EventDate) VALUES ('" + newPass.Vorname + "', '" + newPass.Nachname + "', '" + newPass.Geburtsdatum + "', '" + newPass.Autonummer + "', '" + newPass.Eventname + "', '" + date + "')";
            executeCarMitgliedSql(sqlstring);
            return getPassangersForCar(newPass.Eventname, newPass.Eventdatum, newPass.Autonummer);
        }

        //Mitglied von Mitfahrerlist entfernen
        public static List<CarMitglied> removePassangerFromCar(CarMitglied removePass)
        {
            DateTimeFormatInfo fmt = (new CultureInfo("de-DE")).DateTimeFormat;
            string date = removePass.Eventdatum.ToString("d", fmt);
            string sqlstring = "DELETE FROM dbo.AutoMitglied WHERE Autonummer = '" + removePass.Autonummer + "' AND EventName = '" + removePass.Eventname + "' AND EventDate = '" + date + "'";
            executeCarMitgliedSql(sqlstring);
            return getPassangersForCar(removePass.Eventname, removePass.Eventdatum, removePass.Autonummer);
        }


        //Mitglieder funktionen

        //Mitglied zurückgeben
        public static List<Mitglied> getUser(Mitglied Mitglied)
        {
            string sqlstring = "SELECT * FROM dbo.Mitglied WHERE Vorname = '" + Mitglied.Vorname + "' AND Nachname = '" + Mitglied.Nachname + "' AND Geburtstag = '" + Mitglied.Geburtstag + "'";
            return executeMitgliedSql(sqlstring);
        }

        public static List<Mitglied> getUserViaEmail(string email)
        {
            string sqlstring = "SELECT * FROM dbo.Mitglied WHERE Email = '" + email + "'";
            return executeMitgliedSql(sqlstring);
        }

        //Mitglied hinzufügen
        public static List<Mitglied> addUser(Mitglied newMitglied)
        { 
            string sqlstring = "INSERT INTO dbo.Mitglied (Vorname, Nachname, Geburtstag, Email, Anschrift, Ortsname, PLZ, Rollenname) VALUES ('" + newMitglied.Vorname + "', '" + newMitglied.Nachname + "', '" + newMitglied.Geburtstag + "', '" + newMitglied.Mail + "', '" + newMitglied.Anschrift + "', '" + newMitglied.Ortsname + "', '" + newMitglied.PLZ + "', '" + newMitglied.Rollenname + "')";
            executeMitgliedSql(sqlstring);
            return getUser(newMitglied);
        }

        //Mitglied anpassen
        public static List<Mitglied> updateUser(Mitglied newMitglied)
        {
            //\\ Vorname, Nachname, Geburtstag können nicht angepasst werden weil Primärschlüssel //\\
            string sqlstring = "UPDATE dbo.Mitglied SET Anschrift = '" + newMitglied.Anschrift + "', Ortsname = '" + newMitglied.Ortsname + "', PLZ = '" + newMitglied.PLZ + "' WHERE Vorname = '" + newMitglied.Vorname + "' AND Nachname = '" + newMitglied.Nachname + "' AND Geburtstag = '" + newMitglied.Geburtstag + "'";
            executeMitgliedSql(sqlstring);
            return getUser(newMitglied);
        }

























        //Admin add new Event
        // -> run storedprocedure

        ////Beispieldaten
        //      public static List<Event> EventTable = new List<Event>() {
        //          new Event(GetEventID(), "Fussballspiel Vaduz", "Abfahrt um 8:00 Uhr", new DateTime(2018, 12, 19)),
        //          new Event(GetEventID(), "Fussballspiel Bern", "Abfahrt um 12:00 Uhr", new DateTime(2019, 1, 19)),
        //          new Event(GetEventID(), "Fussballspiel Thailand", "Abfahrt um 5:00 Uhr", new DateTime(2019, 1, 9))
        //      };

        //      private static int _EventID = 0;

        ////Event auslesen
        //public static int GetEventID()
        //      {
        //          return _EventID++;
        //      }

        ////Beispieldaten
        //      public static List<Car> CarTable = new List<Car>() {
        //          new Car("Auto Hansdotter", "Peter", "Hansdotter", "Abfahrt um 8:00 Uhr", "SG123", 5, 0),
        //          new Car("Auto Meier", "Franz", "Meier", "Abfahrt um 8:00 Uhr", "SG223", 5, 0),
        //          new Car("Auto 3", "13", "23", "Abfahrt um 8:00 Uhr", "SG3", 5, 0),
        //          new Car("Auto 4", "14", "24", "Abfahrt um 8:00 Uhr", "SG4", 5, 0),
        //          new Car("Auto 5", "15", "25", "Abfahrt um 8:00 Uhr", "SG5", 5, 0),
        //          new Car("Auto 6", "16", "26", "Abfahrt um 8:00 Uhr", "SG6", 5, 0),
        //          new Car("Auto 7", "17", "27", "Abfahrt um 8:00 Uhr", "SG7", 5, 0),
        //          new Car("Auto 8", "18", "28", "Abfahrt um 8:00 Uhr", "SG8", 5, 0),
        //          new Car("Auto 9", "19", "29", "Abfahrt um 8:00 Uhr", "SG9", 5, 0)          
        //      };

        //      private static int _CarID = 0;
        ////Rückgabe CarID
        //public static int GetCarID()
        //      {
        //          return Autonummer;
        //      }

        public static List<Dist> DistTable = new List<Dist>()
        {
            //new Dist(2, List<1,2>);
        };
    }

}
//public class tClass
//{
//    public Event test(int t)
//    {
//        int ind = DB.EventTable.FindIndex(m => m.ID == t);
//        if (ind >= 0) return DB.EventTable[ind];
//        return null;
//    }

//    public Event updateEvent(int id)
//    {
 
//        return (from md in DB.EventTable where md.ID == id select md).FirstOrDefault(); //auch bekannt als linq (wie SQL)
//    }
//}