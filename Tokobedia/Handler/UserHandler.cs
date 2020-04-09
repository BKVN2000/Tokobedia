using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Tokobedia.Repository;

namespace Tokobedia.Handler
{
    public class UserHandler
    {
        public static bool IsRegistedUser(string Email)
        {
            Userr u = UserRepository.FindByEmail(Email);
            return (u == null) ? false : true;
        }

        public static List<Userr> GetAllUserLogin()
        {
            return UserRepository.FindAll().ToList();        
        }

        public Userr GetUser(int userID)
        {
            Userr user = UserRepository.Find(userID);
            if (user!= null)
            {
                return user; 
            }
            return null;
        }

        public static List<Role> GetAllRole()
        {
            return UserRepository.FindAllRole();
        }

        public static Userr IsAuthenticatedUser(string Email, string Password)
        {
            Userr user = ProductRepository.FindByEmailAndPassword(Email, Password);
            if (user == null)
            {
                return null;
            } 
            return user;
        }

        public bool CheckEmailAvailability(string Email)
        {
            List<Userr> users = UserRepository.FindAll();
            Userr user = users.FirstOrDefault(x => x.Email.Equals(Email));

            if (user == null)
                return true;

            return false;
        }

        public static void RegisterUser(Userr user)
        {
            UserRepository.Insert(user);
        }

        public static void UpdateRoleAndStatusUser(int userID, int roleID, string status)
        {
            UserRepository.UpdateRoleAndStatus(userID,roleID,status);
        }

        public void UpdateProfile(Userr user)
        {
            UserRepository.UpdateProfile(user);
        }

        public bool IsMatchWithOldPassword(string Email, int userID)
        {
            Userr user = UserRepository.Find(userID);
            if (user.Password.Equals(Email))
                return true;

            return false;
        }

        public void UpdatePassword(int userID, string newPassword)
        {
            UserRepository.UpdatePassword(userID,newPassword);
        }
    }
}