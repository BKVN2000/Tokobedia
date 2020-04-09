using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tokobedia.Repository
{

    public class ProductRepository
    {
        protected static TokobediaEntities1 context = DBSingleton.GetInstance();
        public static Product Find(int ID)
        {
            Product p = context.Products.Find(ID);
            if (p != null)
            {
                return p;
            }
            return null;
        }

        public static List<Product> FindAll()
        {
            return context.Products.ToList();
        }

        public static Userr FindByEmailAndPassword(string email, string password)
        {
            Userr user = context.Userrs.Where(x =>
                x.Email.Equals(email) &&
                x.Password.Equals(password)
            ).FirstOrDefault();
            if (user == null) return null;
            return user;
        }

        public static void Delete(int ID)
        {
            Product p = context.Products.Find(ID);
            if (p != null)
            {
                context.Products.Remove(p);
                context.SaveChanges();
            }
        }

        public void InsertProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
        }

        public static void Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public static Product Update(Product NewProduct)
        {
            Product p = context.Products.Find(NewProduct.ID);
            if (p != null)
            {
                p.Name = NewProduct.Name;
                p.Price = NewProduct.Price;
                p.ProductTypeID = NewProduct.ProductTypeID;
                p.Stock = p.Stock;
                context.SaveChanges();

                return p;
            }
            return null;
        }
        public static Product UpdateWithoutProductType(Product NewProduct)
        {
            Product p = context.Products.Find(NewProduct.ID);
            if (p != null)
            {
                p.Name = NewProduct.Name;
                p.Price = NewProduct.Price;
                p.Stock = NewProduct.Stock;
                context.SaveChanges();
                return p;
            }

            return null;
        }
        public static List<Product> FindRandom5Products()
        {
            return context.Products
                  .OrderBy(c => Guid.NewGuid())
                  .Take(5).ToList();
        }
        public static IEnumerable<Product> FindByProductType(int ProductTypeID) => context.ProductTypes.Find(ProductTypeID).Product;
    }
}