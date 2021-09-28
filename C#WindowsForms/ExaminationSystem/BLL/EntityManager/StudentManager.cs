using BLL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BLL.EntityManager
{
   public class StudentManager
    {
        private static StudentManager _instance;
        DBManager dbManager = DBManager.getInstance();
        int studentID;
        public int StudentID { get => studentID; }

        private StudentManager() { }

        public static StudentManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new StudentManager();
            }

            return _instance;
        }

        public int Login(string email, string password)
        {
            int r = -1;
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            {
                ["useremail"] = email,
                ["password"] = password,
            };
            try 
            {
                r = (int)(dbManager.ExecuteScaler("Sp_StudentCheckPassword", ParamList));
                if (r > 0)
                {
                    studentID = r;
                    return r;
                }
                   

            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return r;
        }
    }
}
