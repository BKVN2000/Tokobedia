using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tokobedia.Repository;

namespace Tokobedia.Handler
{
    public class ProductHandler
    {
        public static List<Product> GetRandom5Products() => ProductRepository.FindRandom5Products();
        public IEnumerable<Product> GetProductsByProductType(int ProductTypeID) 
        {
            IEnumerable<Product> listProduct =  ProductRepository.FindByProductType(ProductTypeID);
            if (listProduct.Count() == 0)
            {
                return null;
            }
            return listProduct;
        }
        public  static Product GetProductByID(int ID) => ProductRepository.Find(ID);
        public static Product UpdateProduct(Product product)
        {
            return ProductRepository.UpdateWithoutProductType(product);
        }

        public void InsertProduct(Product p)
        {
            new ProductRepository().InsertProduct(p);
        }

        public List<Product> GetAllProduct()
        {
            return ProductRepository.FindAll();
        }

        public void DeleteProduct(int productID)
        {
            ProductRepository.Delete(productID);
        }
    }  
}