using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tokobedia.Factory
{
    public class ProductTypeFactory
    {
        public static ProductTypes CreateProductType(int ID, string Name, string Desc)
        {
            ProductTypes productType = new ProductTypes
            {
                ID = ID,
                Name = Name,
                Description = Desc
            };

            return productType;
        }
        public  ProductTypes CreateProductType(string Name, string Desc)
        {
            ProductTypes productType = new ProductTypes
            {
                Name = Name,
                Description = Desc
            };

            return productType;
        }
    }
}