using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public class DatabaseMethods
    {
        public DatabaseMethods() 
        {
            
        }

        public SqlConnection OpenConnection()
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            cnn.Open();
            return cnn;
        }

        public int Insert(string sqlQuery)
        {
            SqlConnection cnn = this.OpenConnection();
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            int affected = cmd.ExecuteNonQuery();
            cnn.Close();
            return affected;

        }

        public int Update(string sqlQuery)
        {
            SqlConnection cnn = this.OpenConnection();
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            int affected = cmd.ExecuteNonQuery();
            cnn.Close();
            return affected;

        }

        public int Delete(string sqlQuery)
        {
            SqlConnection cnn = this.OpenConnection();
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            int affected = cmd.ExecuteNonQuery();
            cnn.Close();
            return affected;

        }

        public int InsertWithLastId(string sqlQuery) 
        {
            SqlConnection cnn = this.OpenConnection();
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            adt.Dispose();
            cnn.Close();
            OpenConnection().Close();
            OpenConnection().Dispose();
            return int.Parse(dt.Rows[0]["LastInsertedId"].ToString());

            //SqlConnection cnn = this.OpenConnection();
            //SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            //int affected = cmd.ExecuteNonQuery();
            //cnn.Close();
            //return affected;
            
        }

        public DataSet GetDataset(string sqlQuery) 
        {
            SqlConnection cnn = this.OpenConnection();
            SqlCommand cmd = new SqlCommand( sqlQuery , cnn);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adt.Fill(ds);
            adt.Dispose();
            cnn.Close();
            OpenConnection().Close();
            OpenConnection().Dispose();
            return ds;
        }

        //public SqlDataReader GetDataReader(string sqlQuery) 
        //{
        //    SqlConnection cnn = this.OpenConnection();
        //    SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    return dr;
        //}

        public DataTable GetDataTable(string sqlQuery)
        {
            SqlConnection cnn = this.OpenConnection();
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            adt.Dispose();
            cnn.Close();
            OpenConnection().Close();
            OpenConnection().Dispose();
            return dt;
        }
    }
}