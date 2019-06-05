using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
    public class VereinEvent
    {
        // v ?? v
        public string EventName;
        public string Verein;
        // ^ ?? ^

        public VereinEvent(string eventname, string verein)
        {
            EventName = eventname;
            Verein = verein;
        }

        //SQL :: ?
    }
}