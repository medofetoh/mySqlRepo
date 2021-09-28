using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BLL.EntityManager
{
   public class InstructorManager
    {
        private static InstructorManager _instance;
        DBManager dbManager = DBManager.getInstance();

        private InstructorManager()
        {

        }
        public static InstructorManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new InstructorManager();
            }

            return _instance;
        }

        public bool Login(string email,string password)
        {
            Dictionary<string, object> ParamList = new Dictionary<string, object>()
            {
                ["instEmail"] = email,
                ["password"] = password,
            };
            try 
            {
                if ((int)(dbManager.ExecuteScaler("Sp_instCheckPassword", ParamList)) > 0)
                    return true;
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return false;
        }
    }
}
