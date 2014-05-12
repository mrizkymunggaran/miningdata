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

    public class TipeUserDao:Dao,IDao
    {
        #region DAO

        protected override System.Collections.Generic.List<object> SetDataTableTolist(DataTable dt)
        {
            List<object> list = new List<object>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dra in dt.Rows)
                {

                    //TipeUser a = new TipeUser();
                    //a.idTipe = (string)dra["id_tipe"];                   
                    //a.tipe = (string)dra["tipe"];                   

                    //list.Add(a);

                }

            };

            return list;


        }

        protected override System.Collections.ArrayList SetObjectToArrList(object obj)
        {
            ArrayList arrs = new ArrayList();
            //TipeUser detail = (TipeUser)obj;
            //arrs.Add(detail.idTipe);          
            //arrs.Add(detail.tipe);
          
            return arrs;
        }



        #endregion

       

        #region IDao Members

        public bool Delete(object model)
        {
            bool status = false;
            string strSQL = "Delete from tbtipeuser where id_tipe ='" + model.ToString() + "'";
            status = SetQueryUpdateDatabase(strSQL);
            return status;
        }

        public bool Save(object model)
        {
            bool status = false;
            try { 

            ArrayList arrs = SetObjectToArrList(model);
           
            string strSQL = "Insert into tbtipeuser(id_tipe,tipe) values('" +
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
               
                string strSQL = "Update tbtipeuser " +
                            
                   " Set tipe='" + arrs[1] + "'" +
                   
                    "where id_tipe ='" + id + "'";

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

                string query = "select * from tbtipeuser order by id_tipe";
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

                string query = "select * from tbtipeuser where id_tipe ='" + id + "' order by id_tipe";
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

                string query = "select * from tbtipeuser where tipe like '%" +
                 criterias[0] + "%' order by id_tipe";
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
            string strSQL = "Select id_tipe from tbtipeuser order by id_tipe desc";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                strTemp = (dReader["id_tipe"].ToString().Substring(1, 5));
            }
            else
            {
                id = "T00001";
                return id;
            }
            strValue = (int.Parse(strTemp) + 1).ToString();
            id = "T" + "00000".Substring(0, 5 - strValue.Length) + strValue;
            con.Close();

            return id;
        }
        #endregion
    }

 

