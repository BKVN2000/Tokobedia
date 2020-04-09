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
    public partial class UpdateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {                    
                    int UserID = Convert.ToInt32(Session["UserID"].ToString());
                    Userr user = new UserHandler().GetUser(UserID);
                    if (user != null)
                    {
                        Lit_NameTxt.Text = user.Nama;
                        Lit_EmailTxt.Text = user.Email;
                        Lit_GenderTxt.Text = user.Gender;
                        TxtBox_Name.Text = user.Nama;
                        TxtBox_Email.Text = user.Email;
                        if (user.Gender.ToLower().Equals("male"))
                        {
                            rbl_Gender.SelectedIndex = 0;
                        }
                        else
                        {
                            rbl_Gender.SelectedIndex = 1;
                        }
                    }
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }
        protected void Btn_SubmitUserOnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string Nama = TxtBox_Name.Text.ToString();
                string Email = TxtBox_Email.Text.ToString();
                string Gender = rbl_Gender.SelectedValue.ToString();
                int UserID = Convert.ToInt32(Session["UserID"].ToString());
                Userr user = new UserFactory().Create(UserID, Nama, Email, Gender);
                try
                {
                    new UserHandler().UpdateProfile(user);
                    Session.Abandon();
                    Response.Redirect("LoginPage.aspx");
                }
                catch (Exception ex)
                {

                }
            }
        }
        protected void Btn_ChangePassword(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }
        //protected void Btn_ChangePasswordOnclick(object sender, EventArgs e)
        //{
        //    int UserID = Convert.ToInt32(Session["UserID"]);
        //    if (Page.IsValid)
        //    {
        //        try
        //        {
        //            new UserHandler().UpdatePassword(UserID, NewPasswordTxt.Text.ToString());
        //            Response.Redirect("Home.aspx");
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //}
        protected void CheckOldPasswordValidation(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            int UserID = Convert.ToInt32(Session["UserID"]);
            if (new UserHandler().IsMatchWithOldPassword(args.Value.ToString(), UserID))
            {
                args.IsValid = true;
            }
        }
        protected void CheckEmailAvailability(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (new UserHandler().CheckEmailAvailability(TxtBox_Email.Text.ToString()) || TxtBox_Email.Text.ToString().Equals(Session["Email"].ToString()))
            {
                args.IsValid = true;
            }
        }
    }
}




