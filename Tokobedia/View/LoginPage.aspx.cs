using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tokobedia.Factory;
using Tokobedia.Handler;
using Tokobedia.Repository;

namespace Tokobedia.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["UserLoggedIn"];
                if (cookie != null)
                {
                    //if (DateTime.Compare(cookie.Expires, DateTime.Now) > 0)
                    //{
                        EmailTxt.Text = cookie["Email"];
                        PasswodTxt.Text = cookie["Password"];
                        ChkBox_RememberMe.Checked = true;
                    //}
                }
            }         
        }
        protected void Btn_LogInOnclick(object sender, EventArgs e)
        {
            string mess ="";
            if (Page.IsValid)
            {
                Userr user = UserHandler.IsAuthenticatedUser(EmailTxt.Text.ToString(), PasswodTxt.Text.ToString());               
                if (user != null)
                {
                    //validates if they blocked
                    if (user.Status.ToLower().Equals("blocked"))
                    {
                        mess = "You are Blocked :))";
                    }

                    else
                    {
                        Session[SessionFactory.ID] = Session.SessionID.ToString();
                        Session[SessionFactory.UserID] = user.ID;
                        Session[SessionFactory.UserName] = user.Nama;
                        Session[SessionFactory.RoleID] = user.RoleID;

                        Session[SessionFactory.Email] = user.Email;
                        Session[SessionFactory.Password] = user.Password;

                        string trimmedSession = Session[SessionFactory.ID] + "|" + Session[SessionFactory.UserID] + "|" + Session[SessionFactory.UserName]
                            + "|" + Session[SessionFactory.RoleID] + "|" +
                            Session[SessionFactory.Email] + "|" + Session[SessionFactory.Password];

                        if (ChkBox_RememberMe.Checked)
                        {
                            SetCookie(trimmedSession);
                        }
                        else
                        {
                            //clear prev cookie if exist
                            HttpCookie cookie = Request.Cookies["UserLoggedIn"];
                            if (cookie!= null)
                            {
                                Response.Cookies["UserLoggedIn"].Expires = DateTime.Now.AddYears(-2);
                            }
                        }

                        Response.Redirect("Home.aspx");
                    }                 
                }

                else
                {
                    if (mess.Equals(""))
                    mess = "Username or Password is incorrect ";                  
                }

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mess + "');", true);
            }
        }

        private void SetCookie(string TrimmedSession)
        {
            HttpCookie cookie = new HttpCookie("UserLoggedIn");
            string [] str = TrimmedSession.Split('|');
            cookie["ID"] = str[0];
            cookie["UserID"] = str[1];
            cookie["UserName"] = str[2];
            cookie["RoleID"] = str[3];
            cookie["Email"] = str[4];
            cookie["Password"] = str[5];

            cookie.Expires = DateTime.Now.AddYears(2);
        

            Response.Cookies.Add(cookie);
        }

    }
}