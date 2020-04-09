using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tokobedia.Repository;

namespace Tokobedia.Handler
{
    public class ProductTypeHandler
    {
        public static List<ProductTypes> GetProductTypes() => ProductTypeRepository.FindAll();
        public static bool CheckProductNameAvailability(string Name)
        {
            if (ProductTypeRepository.FindByName(Name) == null)
                return true;

            return false;
        }
        public static List<ProductTypes> GetProductType() => ProductTypeRepository.FindAll();
        public static ProductTypes GetProductTypeByID(int ID)
        {
            return ProductTypeRepository.Find(ID);
        }
        public static ProductTypes UpdateProductType(ProductTypes productType)
        {
            return ProductTypeRepository.Update(productType);
        }

        public void InsertProductType(ProductTypes productType)
        {
            new ProductTypeRepository().Insert(productType);
        }

        public int IsConflictedData(int productTypeID)
        {
            List<Product> products = ProductTypeRepository.FindProductRelated(productTypeID);
            return (products == null) ? 0 : products.Count; 
        }

        public void DeleteProductType(int ID)
        {
            ProductTypeRepository.Delete(ID);
        }
    }
}