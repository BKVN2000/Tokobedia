using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tokobedia.Factory;
using Tokobedia.Handler;
using Tokobedia.Repository;

namespace Tokobedia.View
{
    public partial class UpdateProductType : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ProductTypeID"] == null)
                {
                    Response.Redirect("Home.aspx");
                }
                int ProductTypeID = Convert.ToInt32(Request.QueryString["ProductTypeID"].ToString());

                //Find Corresponding product

                ProductTypes p = ProductTypeHandler.GetProductTypeByID(ProductTypeID);
                HdnProductTypeId.Value = ProductTypeID.ToString();
                NameTxt.Text = p.Name;
                DescTxt.Text = p.Description;
            }
        }

        protected void ValidateProductTypeName(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            string name = args.Value.ToString();
            int ProductTypeID = Convert.ToInt32(HdnProductTypeId.Value.ToString());
            if (name.Length < 5 || !ProductTypeHandler.CheckProductNameAvailability(name))
            {
                if (!ProductTypeRepository.Find(ProductTypeID).Name.Equals(name))
                args.IsValid = false;
            }
        }
        protected void Btn_SubmitProductTypeID(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int ID = Convert.ToInt32(HdnProductTypeId.Value);
                    string Name = NameTxt.Text.ToString();
                    string Desc = DescTxt.Text.ToString();
                    ProductTypes productType = ProductTypeFactory.CreateProductType(ID, Name, Desc);
                    ProductTypes updatedProductType = ProductTypeHandler.UpdateProductType(productType);

                    if (productType == null) throw new Exception();

                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Data Updated Succesfully" + "');", true);
                        Response.Redirect("ViewProductType.aspx");
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}