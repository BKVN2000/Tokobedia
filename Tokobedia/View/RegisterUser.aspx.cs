using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tokobedia.Factory;
using Tokobedia.Handler;

namespace Tokobedia.View
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_SubmitUser(object sender,EventArgs e)
        {
            if (Page.IsValid)
            {
                Userr user = UserFactory.CreateProduct(TxtBox_Name.Text.ToString(), TxtBox_Email.Text.ToString(), TxtBox_Password.Text.ToString(),
                rbl_Gender.SelectedValue, "Active", 2);
                try
                {
                    UserHandler.RegisterUser(user);
                    Response.Redirect("~/View/Home.aspx");
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Data Inserted UnSuccesfully" + "');", true);
                    throw ex;
                }
            }
        }
        protected void CheckEmailAvailability(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (new UserHandler().CheckEmailAvailability(TxtBox_Email.Text.ToString()))
            {
                args.IsValid = true;
            }
            else
            {
                if (Session.Keys.Count != 0)
                {
                    if (TxtBox_Email.Text.ToString().Equals(Session[SessionFactory.Email].ToString()))
                    {
                        args.IsValid = true;
                    }
                }

            }
        }
    }
}