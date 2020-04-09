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
    public partial class RegisterProduct : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //ProductType_ddl.DataSource = ProductHandler
                ProductType_ddl.DataSource = ProductTypeHandler.GetProductTypes();
                ProductType_ddl.DataTextField = "Name";
                ProductType_ddl.DataValueField = "ID";
                ProductType_ddl.SelectedIndex = 0;
                ProductType_ddl.DataBind();

                //ProductType_ddl.Items.Insert(0, new ListItem("--Select Item Product--", "-1"));
            }
        }
        protected void IsMultiplicationOf1000Check(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (Convert.ToInt32(args.Value) % 1000 == 0 && Convert.ToInt32(args.Value) != 0)
            {
                args.IsValid = true;
            }
        }
        protected void Btn_InsertProductOnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string Name = NameTxt.Text.ToString();
                string Stock = StockTxt.Text.ToString();
                string Price = PriceTxt.Text.ToString();
                int ProductTypeID = int.Parse(ProductType_ddl.SelectedValue);
                try
                {
                    Product p = ProductFactory.CreateProduct(Name, int.Parse(Price), int.Parse(Stock),ProductTypeID);
                    new ProductHandler().InsertProduct(p);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Data Updated Succesfully" + "');", true);
                    Response.Redirect("ViewProduct.aspx");
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Data Updated Unsuccesfully" + "');", true);
                    Response.Redirect("ViewProduct.aspx");
                }
            }
        }
    }
}