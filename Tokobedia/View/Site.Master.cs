using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tokobedia
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lb_ViewProfile.Text = "Hi,Guest";
            if (Session.Keys.Count != 0)
            {
                lb_Register.Visible = false;
                lb_Logout.Visible = true;
                Lb_ViewProfile.Text = String.Format("Hi,{0}", Session["UserName"]);
                //admin
                if (Session["RoleID"].ToString() == "1")
                {
                    Pnl_Admin1.Visible = true;
                    Pnl_Admin2.Visible = true;
                }
                 Login_h1.Visible = false;
            }
        }

        protected void Login_onClick(object sender, EventArgs e)
        {
            Response.Redirect("~/View/LoginPage.aspx");
        }      
        protected void LogOut_onClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/View/Home.aspx");
        }
        protected void Register_onClick(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RegisterUser.aspx");
        }
        protected void ViewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/UpdateUser.aspx");   
        }
    }
}