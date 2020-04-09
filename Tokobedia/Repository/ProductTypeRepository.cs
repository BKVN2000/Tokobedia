using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tokobedia.Repository
{
    public class ProductTypeRepository
    {
        protected static TokobediaEntities1 context = DBSingleton.GetInstance();
        public static ProductTypes Find(int ID) => context.ProductTypes.Find(ID);
        public static List<ProductTypes> FindAll()
        {
            return context.ProductTypes.ToList();
        }
        public static ProductTypes FindByName(string Name)
        {
            ProductTypes productType = context.ProductTypes.Where(x => x.Name.Equals(Name)).FirstOrDefault();
            return (productType == null) ? null : productType;
        }
        public static ProductTypes Update(ProductTypes NewProductType)
        {
            ProductTypes p = context.ProductTypes.Find(NewProductType.ID);
            if (p != null)
            {
                p.Name = NewProductType.Name;
                p.Description = NewProductType.Description;
                context.SaveChanges();

                return p;
            }
            return null;
        }

        public void Insert(ProductTypes productType)
        {
            context.ProductTypes.Add(productType);
            context.SaveChanges();
        }

        public static List<Product> FindProductRelated(int productTypeID)
        {
            List<Product> products = context.ProductTypes.Find(productTypeID).Product.ToList();
            return (products == null) ? null : products;
        }

        public static void Delete(int ID)
        {
            ProductTypes productType = Find(ID);
            if (productType != null)
            {
                context.ProductTypes.Remove(productType);
                context.SaveChanges();
            }            
        }
    }
}