using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tokobedia.Handler;
using Tokobedia.Repository;

namespace Tokobedia.View
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Logged in user and registed userz
            
            UnregistedPnl.Visible = true;
            //Member
            if ((Session["Email"] != null && Session["Password"] != null))
            {
                string Email = Session["Email"].ToString();
                if (UserHandler.IsRegistedUser(Email))
                {
                    UnregistedPnl.Visible = false;
                }
            }
            
            RptProductList.DataSource = ProductHandler.GetRandom5Products();
            RptProductList.DataBind();
        }
        protected void Register_Click(object sender, EventArgs e)
        {

        }
        protected void RptProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            //Literal Name_lit = (Literal)(item.FindControl("litProductName"));
            //Literal Rating_lit = (Literal)(item.FindControl("litRating"));
            //Literal Price_lit = (Literal)(item.FindControl("litPrice"));


            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    string customerID = DataBinder.Eval(e.Item.DataItem, "CustomerID").ToString());
            //}
        }
    }
}