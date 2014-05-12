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


    public class Conn
    {

         public static SqlConnection Connections()
        {
             string dbconn = System.Configuration.ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

            SqlConnection con;
            con = new SqlConnection(dbconn);
            return con;
        }

        
        
           }

