using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tokobedia.Encryption;
using Tokobedia.Factory;
using Tokobedia.Handler;

namespace Tokobedia.View
{
    public partial class UpdateProduct : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ProductID"] == null)
                {
                    Response.Redirect("Home.aspx");
                }
                string DecriptedText = new EncryptDecryptQueryString().Decrypt(HttpUtility.UrlDecode(Request.QueryString["ProductID"]));
                int ProductID = Convert.ToInt32(DecriptedText);
                //Find Corresponding product

                Product p = ProductHandler.GetProductByID(ProductID);
                if (p == null)
                {
                    Response.Clear();
                    Response.StatusCode = 404;
                    Response.End();
                   // throw new HttpException(404,"PageNotFound");
                }
                HdnProductId.Value = ProductID.ToString();
                NameTxt.Text = p.Name;
                StockTxt.Text = p.Stock.ToString();
                PriceTxt.Text = p.Price.ToString();
            }            
        }
        protected void IsMultiplicationOf1000Check(object sender,ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (Convert.ToInt32(args.Value) % 1000 == 0 && Convert.ToInt32(args.Value) != 0)
            {
                args.IsValid = true;
            }
        }

        protected void Btn_SubmitProduct(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string Name = NameTxt.Text.ToString();
                string Stock = StockTxt.Text.ToString();
                string Price = PriceTxt.Text.ToString();
                int ID =  int.Parse(HdnProductId.Value);
                Product p = ProductFactory.CreateProduct(ID, Name,int.Parse(Price),int.Parse(Stock));
                Product UpdatedProduct = ProductHandler.UpdateProduct(p);
                
                if (UpdatedProduct != null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" +"Data Updated Succesfully"+ "');", true);
                    Response.Redirect("ViewProduct.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Data Updated Unsuccesfully" + "');", true);
                    Response.Redirect("ViewProduct.aspx");
                }
            }
        }
    }
}