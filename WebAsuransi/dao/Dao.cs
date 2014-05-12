using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;



    public abstract class Dao
    {


        private SqlDataAdapter da;
        protected DataTable dt;
        protected  SqlConnection con = Conn.Connections();
        protected DataTable GetQueryDatabase(string query)
        {
           System.Diagnostics.Debug.WriteLine(query);
           // SqlConnection con = Conn.Connections();
           // System.Diagnostics.Debug.WriteLine(con.ConnectionString.ToString());
           
            da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            return dt;

        }

        protected bool SetQueryUpdateDatabase(string query)
        {
            bool status = false;
            try
            {
               System.Diagnostics.Debug.WriteLine(query);
                SqlCommand cmd;
                cmd = new SqlCommand(query);
                SqlConnection con = Conn.Connections();
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                status = true;

            }
            catch (SqlException ex)
            {

                MsgBox.Show(ex.Message.ToString());

            }
            return status;
        }

        protected abstract List<object> SetDataTableTolist(DataTable dt);
        protected abstract ArrayList SetObjectToArrList(object obj);

    }

