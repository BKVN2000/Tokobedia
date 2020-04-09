using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tokobedia.Handler;

namespace Tokobedia.View
{
    public partial class ViewProductType : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Gv_ProductType.DataSource = ProductTypeHandler.GetProductType();
            Gv_ProductType.DataBind();
        }
        protected void linkUpdate_Click(object sender, EventArgs e)
        {
            int ProductTypeID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Response.Redirect(String.Format("UpdateProductType.aspx?ProductTypeID={0}",ProductTypeID));
        }
        protected void Btn_InsertProductTypeOnClick(object sender, EventArgs e)
        {
            Response.Redirect("RegisterProductType.aspx");
        }
        protected void linkDeleteTriggerModal_Click(object sender, EventArgs e)
        {
            int ProductTypeID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            int ConflictedData = new ProductTypeHandler().IsConflictedData(ProductTypeID);
            HdnProductTypeId.Value = "0";
            //no conflicted data
            if (ConflictedData == 0)
            {
                Btn_DeleteProductType.Visible = true;
                HdnProductTypeId.Value = ProductTypeID.ToString(); 
                lblModalBody.Text = "Are You sure you want to delete this item?";
            }
            else
            {
                Btn_DeleteProductType.Visible = false;
                lblModalBody.Text = String.Format("Cannot Delete this Item, there is/are {0} item/s using this item!",ConflictedData.ToString());
            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#DeleteModal').modal();", true);
        }
        protected void Btn_DeleteProductTypeOnclick(object sender, EventArgs e)
        {
            try
            {
                new ProductTypeHandler().DeleteProductType(int.Parse(HdnProductTypeId.Value));
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#DeleteModal').modal('hide');", true);
                Response.Redirect("ViewProductType.aspx");
            }
            catch(Exception ex)
            {

            }
        }
    }
}