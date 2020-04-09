using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tokobedia.Encryption;
using Tokobedia.Handler;

namespace Tokobedia.View
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
       {
            if (!IsPostBack)
            {
                //Set Dropdown
                ProductType_ddl.DataSource = ProductTypeHandler.GetProductTypes();
                ProductType_ddl.DataTextField = "Name";
                ProductType_ddl.DataValueField = "ID";
                ProductType_ddl.SelectedIndex = -1;
                ProductType_ddl.DataBind();

                ProductType_ddl.Items.Insert(0, new ListItem("--Select Product Type--", "-1"));

                //fill data in repeater
                RptProductListByType.DataSource = new ProductHandler().GetAllProduct();
                RptProductListByType.DataBind();
            }
            //jika admin
            if (Session.Keys.Count !=0)
            {
                if (Session["RoleID"].ToString().Equals("1"))
                {
                    Btn_InsertNewProd.Visible = true;
                }                
            }
        }
        protected void ProductType_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProductTypeID = int.Parse(ProductType_ddl.SelectedValue);
            if (ProductTypeID == -1)
            {
                RptProductListByType.DataSource = new ProductHandler().GetAllProduct();
            }
            else
            {
                RptProductListByType.DataSource = new ProductHandler().GetProductsByProductType(ProductTypeID);
            }

            RptProductListByType.DataBind();
        }
        protected void InitRepeater(object sender, RepeaterItemEventArgs e)
        {
            if (Session.Keys.Count!= 0){
                if(Session["RoleID"].ToString() == "1")
                {
                    Panel myPanel = (Panel)e.Item.FindControl("Pnl_ProductionAction");
                    myPanel.Visible = true;
                }
            }              
        }
        protected void RptProductList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string ProductID = e.CommandArgument.ToString();
            if (e.CommandName == "UpdateProduct")
            {
                string EncryptedProductID = new EncryptDecryptQueryString().Encrypt(ProductID);
                Response.Redirect(string.Format("UpdateProduct.aspx?ProductID={0}", HttpUtility.UrlEncode(EncryptedProductID)));
                //Response.Redirect("UpdateProduct.aspx?ProductID="+ProductID);
            }
            else if (e.CommandName == "DeleteProduct")
            {
                new ProductHandler().DeleteProduct(Convert.ToInt32(ProductID));
                Response.Redirect("ViewProduct.aspx");
            }
        }
        protected void Btn_InsertProductOnClick(object sender, EventArgs e)
        {
            Response.Redirect("RegisterProduct.aspx");
        }
    }
}