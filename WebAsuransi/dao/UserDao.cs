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

    public class UserDao:Dao,IDao
    {
        #region DAO

        protected override System.Collections.Generic.List<object> SetDataTableTolist(DataTable dt)
        {
            List<object> list = new List<object>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dra in dt.Rows)
                {

                    User a = new User();
                    a.idUser = (string)dra["id_user"];
                    a.userName = (string)dra["user_name"];
                    a.password = (string)dra["password"];
                    a.tipeUser= (string)dra["tipe_user"];
                   
                    list.Add(a);

                }

            };

            return list;


        }

        protected override System.Collections.ArrayList SetObjectToArrList(object obj)
        {
            ArrayList arrs = new ArrayList();
            User detail = (User)obj;
            arrs.Add(detail.idUser);
            arrs.Add(detail.userName);
            arrs.Add(detail.password);
            arrs.Add(detail.tipeUser);
            
            return arrs;
        }



        #endregion

       

        #region IDao Members

        public bool Delete(object model)
        {
            bool status = false;
            string strSQL = "Delete from tbuser where id_user ='" + model.ToString() + "'";
            status = SetQueryUpdateDatabase(strSQL);
            return status;
        }

        public bool Save(object model)
        {
            bool status = false;
            try { 

            ArrayList arrs = SetObjectToArrList(model);
           
            string strSQL = "Insert into tbuser(id_user,user_name,password,tipe_user) values('" +
                                       arrs[0] + "','" + arrs[1] + "','" + arrs[2] + "','" + arrs[3] +  "')";
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
               
                string strSQL = "Update tbuser " +
                   " Set id_user='" + arrs[0] + "'," +
                   "user_name='" + arrs[1] + "'," +
                   " password='" + arrs[2] + "'," +
                    " tipe_user='" + arrs[3] + "'" +
                    
                    "where id_user ='" + id + "'";

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

                string query = "select * from tbuser";
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

                string query = "select * from tbuser  where id_user ='" + id + "'";
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

                string query = "select * from tbuser user_name like '%" + criterias[0] + "%'" +
                                           "and tipe_user like '%" + (criterias[1].ToString()) + "%' order by id_user ";
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
            string strSQL = "Select id_user from tbuser order by id_user desc";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                strTemp = (dReader["id_user"].ToString().Substring(1, 5));
            }
            else
            {
                id = "U00001";
                return id;
            }
            strValue = (int.Parse(strTemp) + 1).ToString();
            id = "U" + "00000".Substring(0, 5 - strValue.Length) + strValue;
            con.Close();

            return id;
        }

        #endregion

        public User LoginUser(string name, string password)
        {
            List<object> lists = null;
            User a = null;
            string query = "select * from tbuser where user_name='" + name + "' and password='" + password + "'";
            dt = GetQueryDatabase(query);
            lists = SetDataTableTolist(dt);
            if (lists.Count != 0)
            {
                a = (User)lists[0];
            }
            else
            {
                a = null;
            }

            return a;

        }
    }

 

