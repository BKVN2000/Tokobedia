using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tokobedia.Factory
{
    public class UserFactory
    {
        public static Userr CreateProduct(string UserName, string UserEmail, string UserPassword, string Gender, string Status, int RoleID)
        {
           
            Userr user = new Userr
            {
                //ID = UserID,
                Email = UserEmail,
                Nama = UserName,
                Gender = Gender,
                RoleID = RoleID,
                Status = Status,
                Password = UserPassword
            };

            return user;
        }

        public Userr Create(int ID,string nama, string email, string gender)
        {
            return new Userr
            {
                ID = ID,
                Nama = nama,
                Email = email,
                Gender = gender
            };
        }
    }
}