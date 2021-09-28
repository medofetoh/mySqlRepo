using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Collections.Generic;

namespace DAL
{
    public class DBManager
    {
        private static DBManager _instance;
        SqlConnection Sqlcn;
        SqlCommand SqlCmd;
        SqlDataAdapter DA;
        DataTable Dt;
        private DBManager()
        {
            try
            {
                Sqlcn = new SqlConnection();
                Sqlcn.ConnectionString = ConfigurationManager.ConnectionStrings["Examination"].ConnectionString;
                SqlCmd = new SqlCommand("", Sqlcn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                DA = new SqlDataAdapter(SqlCmd);
                Dt = new DataTable();
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }

        }
        public static DBManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new DBManager();

            }
            return _instance;
        }
        public int ExecuteNonQuery(string SpName)
        {
            int R = -1;
            try
            {
                if (Sqlcn?.State == ConnectionState.Closed)
                    Sqlcn.Open();

                SqlCmd.Parameters.Clear();

                SqlCmd.CommandText = SpName;

                R = SqlCmd.ExecuteNonQuery();

                Sqlcn.Close();
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return R;
        }

        public object ExecuteScaler(string SpName)
        {
            object R = new object();
            try
            {
                if (Sqlcn?.State == ConnectionState.Closed)
                    Sqlcn.Open();

                SqlCmd.Parameters.Clear();

                SqlCmd.CommandText = SpName;

                R = SqlCmd.ExecuteScalar();

                Sqlcn.Close();
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return R;
        }

        public DataTable ExecuteDataTable(string SpName)
        {
            try
            {
                Dt.Clear();
                SqlCmd.Parameters.Clear();

                SqlCmd.CommandText = SpName;

                DA.Fill(Dt);
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return Dt;
        }

        public int ExecuteNonQuery(string SpName, Dictionary<string, object> ParamList)
        {
            int R = -1;
            try
            {
                if (Sqlcn?.State == ConnectionState.Closed)
                    Sqlcn.Open();

                SqlCmd.Parameters.Clear();

                if (ParamList?.Count > 0)
                    foreach (var item in ParamList)
                        SqlCmd.Parameters.AddWithValue(item.Key, item.Value);


                SqlCmd.CommandText = SpName;

                R = SqlCmd.ExecuteNonQuery();

                Sqlcn.Close();
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return R;
        }

        public object ExecuteScaler(string SpName, Dictionary<string, object> ParamList)
        {
            object R = new object();
            try
            {
                if (Sqlcn?.State == ConnectionState.Closed)
                    Sqlcn.Open();

                SqlCmd.Parameters.Clear();

                if (ParamList?.Count > 0)
                    foreach (var item in ParamList)
                        SqlCmd.Parameters.AddWithValue(item.Key, item.Value);

                SqlCmd.CommandText = SpName;

                R = SqlCmd.ExecuteScalar();

                Sqlcn.Close();
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return R;
        }

        public DataTable ExecuteDataTable(string SpName, Dictionary<string, object> ParamList)
        {
            try
            {
                Dt.Clear();
                SqlCmd.Parameters.Clear();
                if (ParamList?.Count > 0)
                    foreach (var item in ParamList)
                        SqlCmd.Parameters.AddWithValue(item.Key, item.Value);
                SqlCmd.CommandText = SpName;

                DA.Fill(Dt);
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);
            }
            return Dt;
        }


    }
}
