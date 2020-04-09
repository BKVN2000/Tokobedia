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
    public partial class RegisterProductType : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ValidateProductTypeName(object sender, ServerValidateEventArgs args)
        {
            string name = args.Value.ToString();
            if (name.Length < 5 || !ProductTypeHandler.CheckProductNameAvailability(name))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void Btn_SubmitProductType(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string Name = NameTxt.Text.ToString();
                    string Desc = DescTxt.Text.ToString();

                    ProductTypes productType = new ProductTypeFactory().CreateProductType(Name, Desc);
                    new ProductTypeHandler().InsertProductType(productType);

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