using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tokobedia.Handler;

namespace Tokobedia.View
{
    public partial class ViewUser : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_Role.DataSource = UserHandler.GetAllRole();
                ddl_Role.DataTextField = "Name";
                ddl_Role.DataValueField = "ID";
                ddl_Role.DataBind();
            }

            gv_ViewUsers.DataSource = UserHandler.GetAllUserLogin();
            gv_ViewUsers.DataBind();
        }
        protected void gvCustomres_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ID =e.Row.Cells[0].Text;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkView = (LinkButton)e.Row.FindControl("linkSelect");
                var rowView = (DataRowView)e.Row.DataItem;
                lnkView.CommandArgument = ID;
            }
        }

        protected void linkUpdate_Click(object sender, EventArgs e)
        {
            string UserID = (sender as LinkButton).CommandArgument;
            HdnUserId.Value = UserID;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }
        protected void Btn_UpdateUserOnclick(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(HdnUserId.Value);
            int roleID = Convert.ToInt32(ddl_Role.SelectedValue);
            string status = ddl_Status.SelectedValue;

            if (HdnUserId.Value.Equals(Session["UserID"].ToString()))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ClientScript", "alert('Yout Cannot Update your own profile.')", true);
            }
            else
            {
                UserHandler.UpdateRoleAndStatusUser(userID, roleID, status);
                Response.Redirect("ViewUser.aspx");
            }
        }
    }
}