using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tokobedia.Factory;

namespace Tokobedia.View
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (Session.Keys.Count == 0)    
            {
                string mess = "You are Not Authorized to access this page";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                   "alert('"+mess+ "'); window.location='" +
                   Request.ApplicationPath + "View/Home.aspx';", true);
            }

            else if (Session[SessionFactory.RoleID].ToString() != "1")
            {
                string mess = "Only Administrator can access this page";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                  "alert('" + mess + "'); window.location='" +
                  Request.ApplicationPath + "View/Home.aspx';", true);
            }           
        }
    }
}