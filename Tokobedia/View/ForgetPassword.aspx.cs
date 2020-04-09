using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tokobedia.Handler;

namespace Tokobedia.View
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_ChangePasswordOnclick(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(Session["UserID"]);
            if (Page.IsValid)
            {
                try
                {
                    new UserHandler().UpdatePassword(UserID, NewPasswordTxt.Text.ToString());
                    Response.Redirect("Home.aspx");
                }
                catch (Exception ex)
                {

                }
            }
        }
        protected void CheckOldPasswordValidation(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            int UserID = Convert.ToInt32(Session["UserID"]);
            if (new UserHandler().IsMatchWithOldPassword(args.Value.ToString(), UserID))
            {
                args.IsValid = true;
            }
        }
    }
}