using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tokobedia.Factory
{
    public class ProductFactory
    {
        public static Product CreateProduct(int ID, string Name, int Price, int ProductTypeID, int Stock)
        {
            Product product = new Product
            {
                ID = ID,
                Name = Name,
                Price = Price,
                ProductTypeID = ProductTypeID,
                Stock = Stock
            };

            return product;
        }
        public static Product CreateProduct(int ID, string Name, int Price,int Stock)
        {
            Product product = new Product
            {
                ID = ID,
                Name = Name,
                Price = Price,
                Stock = Stock
            };

            return product;
        }

        public static Product CreateProduct(string Name, int Price, int Stock,int ProductTypeID)
        {
            Product product = new Product
            {
                Name = Name,
                Price = Price,
                Stock = Stock,
                ProductTypeID = ProductTypeID
            };

            return product;
        }
    }
}