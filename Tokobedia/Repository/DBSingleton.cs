using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tokobedia.Repository
{
    public class DBSingleton
    {
        public static TokobediaEntities1 db;

        public static TokobediaEntities1 GetInstance()
        {
            if (db == null)
            {
                db = new TokobediaEntities1();
            }
            return db;
        }
    }
}