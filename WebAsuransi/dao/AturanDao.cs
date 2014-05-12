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
using System.Collections.Generic;
using WebAsuransi.model;
using System.Collections;
using System.Data.SqlClient;
using WebAsuransi.util;

namespace WebAsuransi.dao
{
    public class AturanDao:Dao,IDao
    {


        
        #region DAO

        protected override System.Collections.Generic.List<object> SetDataTableTolist(DataTable dt)
        {
            List<object> list = new List<object>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dra in dt.Rows)
                {

                    Aturan a = new Aturan();
                    a.id = (string)dra["id"];
                    a.prediksi = (string)dra["prediksi"];
                    a.prediksis = ConvertString.StringToList(a.prediksi);
                    a.hasil = a.prediksis[a.prediksis.Count - 1];
                    list.Add(a);

                }

            };

            return list;


        }

        protected override System.Collections.ArrayList SetObjectToArrList(object obj)
        {
            ArrayList arrs = new ArrayList();
            Aturan detail = (Aturan)obj;
            arrs.Add(detail.id);
            arrs.Add(detail.prediksi);
          
            return arrs;
        }



        #endregion

       

        #region IDao Members

        public bool Delete(object model)
        {
            bool status = false;
            string strSQL = "Delete from tbaturan where id <>''";
            status = SetQueryUpdateDatabase(strSQL);
            return status;
        }

        public bool Save(object model)
        {
            bool status = false;
            try { 

            ArrayList arrs = SetObjectToArrList(model);
           
            string strSQL = "Insert into tbaturan(id,prediksi) values('" +
                                       arrs[0] + "','" + arrs[1] +  "')";
            status = SetQueryUpdateDatabase(strSQL);
            

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
            }

            return status;
        }

        public bool Update(object model, string id)
        {
            bool status = false;
            try
            {

                ArrayList arrs = SetObjectToArrList(model);
               
                string strSQL = "Update tbaturan " +
                            
                   " Set prediksi='" + arrs[1] + "'" +
                   
                    "where id ='" + id + "'";

                status = SetQueryUpdateDatabase(strSQL);



               

            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
            }
            return status;
        }

        public System.Collections.Generic.List<object> SelectAll()
        {
             List<object> lists=null;
            try
            {

                string query = "select * from tbaturan order by id";
                dt = GetQueryDatabase(query);
                lists = SetDataTableTolist(dt);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
            }

            return lists;
        }

        public object SelectById(string id)
        {
            List<object> lists = null;
            object a = null;
            try
            {

                string query = "select * from tbaturan where id ='" + id + "' order by id";
                dt = GetQueryDatabase(query);
                lists = SetDataTableTolist(dt);
               
                if (lists.Count != 0)
                {
                    a = lists[0];
                }
                else
                {
                    a = null;
                }

               




            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
            }

            return a;
        }

        public System.Collections.Generic.List<object> SelectByCriterias(System.Collections.ArrayList criterias)
        {
            List<object> lists = null;
            try
            {

                string query = "select * from tbaturan where prediksi like '%" +
                 criterias[0] + "%' order by id";
                dt = GetQueryDatabase(query);
                lists = SetDataTableTolist(dt);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
            }

            return lists;
        }

        public string GetPrimaryKey()
        {

            string id = "";
            if (con.State != ConnectionState.Closed) con.Close();
            con.Open();
            string strTemp = "";
            string strValue = "";
            string strSQL = "Select id from tbaturan order by id desc";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                strTemp = dReader["id"].ToString();
            }
            else
            {
                id = "1";
                return id;
            }
            con.Close();
            strValue = (int.Parse(strTemp) + 1).ToString();
            id =   strValue;
           

            return id;
        }
        #endregion
    }
}
