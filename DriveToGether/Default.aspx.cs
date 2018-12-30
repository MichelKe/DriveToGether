using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc.Html;
using System.Web.UI.HtmlControls;
using DriveToGether.Controllers;

namespace DriveToGether
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (HtmlGenericControl hgc in EventController.GetEventList())
            {
                eventlist.Controls.Add(hgc);
            }
        }
        protected void EventDetails_Click(int id)
        {
            Response.Redirect("/Views/Event/EventDetails.aspx");
        }
    }
}