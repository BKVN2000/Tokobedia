using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Tokobedia.Repository
{
    public class UserRepository
    {
        protected static TokobediaEntities1 context = DBSingleton.GetInstance();

        public static Userr Find(int ID)
        {
            Userr u = context.Userrs.Find(ID);
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public static List<Role> FindAllRole()
        {
            return context.Roles.ToList();
        }

        //public static IEnumerable<Userr> FindAllRoleAndStatus()
        //{
        //    return (from p in context.Userrs
        //            select new { Status = p.Status,RoleName = p.Role.Name}).ToList()
        //               .Select(x => new Userr { Status = x.Status ,RoleName = x.RoleName});
        //}

        public static List<Userr> FindAll()
        {
            return context.Userrs.ToList();
        }

        public static void Delete(int ID)
        {
            Userr u = context.Userrs.Find(ID);
            if (u != null)
            {
                context.Userrs.Remove(u);
                context.SaveChanges();
            }
        }

        public static void Insert(Userr user)
        {
            context.Userrs.Add(user);
            context.SaveChanges();
        }

        public static void UpdateRoleAndStatus(int userID,  int roleID, string status)
        {
            Userr user = Find(userID);
            if (user != null)
            {
                user.RoleID = roleID;
                user.Status = status;
                context.SaveChanges();
            }
        }

        public static void UpdateProfile(Userr user)
        {
            Userr u = Find(user.ID);
            if (u != null)
            {
                u.Nama = user.Nama;
                u.Email = user.Email;
                u.Gender = user.Gender;

                //context.Entry(u).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void UpdatePassword(int userID, string newPassword)
        {
            Userr u = Find(userID);
            if (u != null)
            {
                u.Password = newPassword;
                context.SaveChanges();
            }
        }

        public static void Create(Userr user)
        {
            context.Userrs.Add(user);
            context.SaveChanges();
        }

        public static Userr Update(Userr Newuser)
        {
            Userr u = context.Userrs.Find(Newuser.ID);
            if (u != null)
            {
                u.Email = Newuser.Email;
                u.Gender = Newuser.Gender;
                u.Nama = Newuser.Nama;
                u.Password = u.Password;
                u.RoleID = Newuser.RoleID;
                u.Status = Newuser.Status;
                context.SaveChanges();
                return u;
            }
            return null;
        }

        public static Userr FindByEmailAndPassword(string Email, string Password)
        {
            Userr u = context.Userrs.Where(x => x.Email.Equals(Email) && x.Password.Equals(Password)).FirstOrDefault();
            if (u != null) return u;
            return null;
        }

        public static Userr FindByEmail(string Email)
        {
            Userr u = context.Userrs.Where(x => x.Email.Equals(Email)).FirstOrDefault();
            return (u != null) ? u : null;
        }
    }
}