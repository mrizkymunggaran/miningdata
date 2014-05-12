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
using System.Collections;

using System.Collections.Generic;
using System.Data.SqlClient;
using WebAsuransi.model;

    public class CaraBayarDao:Dao,IDao
    {
        #region DAO

        protected override System.Collections.Generic.List<object> SetDataTableTolist(DataTable dt)
        {
            List<object> list = new List<object>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dra in dt.Rows)
                {

                    Katagori a = new Katagori();
                    a.id = (int)dra["id"];
                    a.katagori = (string)dra["katagori"];

                    list.Add(a);

                }

            };

            return list;


        }

        protected override System.Collections.ArrayList SetObjectToArrList(object obj)
        {
            ArrayList arrs = new ArrayList();
            Katagori detail = (Katagori)obj;
            arrs.Add(detail.id);
            arrs.Add(detail.katagori);
          
            return arrs;
        }



        #endregion

       

        #region IDao Members

        public bool Delete(object model)
        {
            bool status = false;
            string strSQL = "Delete from tbjenisproses where id ='" + model.ToString() + "'";
            status = SetQueryUpdateDatabase(strSQL);
            return status;
        }

        public bool Save(object model)
        {
            bool status = false;
            try { 

            ArrayList arrs = SetObjectToArrList(model);
           
            string strSQL = "Insert into tbjenisproses(id,katagori) values('" +
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
               
                string strSQL = "Update tbjenisproses " +
                            
                   " Set katagori='" + arrs[1] + "'" +
                   
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

                string query = "select * from tbjenisproses order by id";
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

                string query = "select * from tbjenisproses where id ='" + id + "' order by id";
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

                string query = "select * from tbjenisproses where katagori like '%" +
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
            string strSQL = "Select id from tbjenisproses order by id desc";
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
            strValue = (int.Parse(strTemp) + 1).ToString();
            id =   strValue;
            con.Close();

            return id;
        }
        #endregion
    }

 

