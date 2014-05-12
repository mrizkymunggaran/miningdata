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

public class HistoriAsuransiDao : Dao, IDao
    {
        #region DAO

        protected override System.Collections.Generic.List<object> SetDataTableTolist(DataTable dt)
        {
            List<object> list = new List<object>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dra in dt.Rows)
                {

                    HistoriAsuransi a = new HistoriAsuransi();
                    a.id_histori = (int)dra["id_histori"];
                    a.jkPolis = (string)dra["jenis_kelamin_polis"];
                    a.usiaPolis = (string)dra["usia_pemegang_polis"];
                    a.statKawin = (string)dra["status_perkawinan"];
                    a.penghasilanPolis = (string)dra["penghasilan"];
                    a.sumberDana = (string)dra["sumber_dana"];
                    a.kecamatan = (string)dra["kecamatan"];
                    a.pekerjaan = (string)dra["pekerjaan"];
                    a.jkTertanggung = (string)dra["jenis_kelamin_tertangung"];
                    a.usiaTertanggung = (string)dra["usia_tertanggung"];
                    a.tertanggung_pempol = (string)dra["tertanggung_pempol"];
                    a.penerima_pempol = (string)dra["penerima_pempol"];
                    a.jenisAsuransi = (string)dra["jenis_asuransi"];
                    a.masaAsuransi = (string)dra["masa_asuransi"];
                    a.UangPertanggung = (string)dra["uang_pertanggungan"];
                    a.caraBayar = (string)dra["cara_pembayaran"];
                    a.jenisProses = (string)dra["jenis_proses"];
                    a.status = (string)dra["status"];
                    a.statusAktif = (int)dra["statusAktif"];
                    a.SetList();


                    list.Add(a);

                }

            };

            return list;


        }

        protected override System.Collections.ArrayList SetObjectToArrList(object obj)
        {
            ArrayList arrs = new ArrayList();
            HistoriAsuransi a = (HistoriAsuransi)obj;
            arrs.Add(a.id_histori);
            arrs.Add(a.jkPolis);
            arrs.Add(a.usiaPolis );
           arrs.Add( a.statKawin );
           arrs.Add( a.penghasilanPolis );
            arrs.Add(a.sumberDana);
            arrs.Add(a.kecamatan );
            arrs.Add(a.pekerjaan );
            arrs.Add(a.jkTertanggung );
            arrs.Add(a.usiaTertanggung );
           arrs.Add( a.tertanggung_pempol );
           arrs.Add( a.penerima_pempol );
            arrs.Add(a.jenisAsuransi );
           arrs.Add( a.masaAsuransi );
           arrs.Add( a.UangPertanggung );
           arrs.Add( a.caraBayar );
           arrs.Add(a.jenisProses);
           arrs.Add( a.status );
           arrs.Add(a.statusAktif);
          
            return arrs;
        }



        #endregion

       

        #region IDao Members

        public bool Delete(object model)
        {
            bool status = false;
            string strSQL = "Delete from tbhistoriasuransi where id_histori ='" + model.ToString() + "'";
            status = SetQueryUpdateDatabase(strSQL);
            return status;
        }

        public bool Save(object model)
        {
            bool status = false;
            try { 

            ArrayList arrs = SetObjectToArrList(model);
           
            string strSQL = "Insert into tbhistoriasuransi(id_histori,jenis_kelamin_polis,usia_pemegang_polis,status_perkawinan,	penghasilan,"+
                "sumber_dana,	kecamatan,	pekerjaan,jenis_kelamin_tertangung,usia_tertanggung,"+
                "tertanggung_pempol,penerima_pempol,jenis_asuransi,	masa_asuransi," +
                "uang_pertanggungan,cara_pembayaran,jenis_proses,	status,statusAktif) values('" +
                                       arrs[0] + "','" + arrs[1] + "','" + arrs[2] + "','" + arrs[3] + "','" + arrs[4] + "','" + arrs[5] +
                                       "','" + arrs[6] + "','" + arrs[7] + "','" + arrs[8] +
                                       "','" + arrs[9] + "','" + arrs[10] + "','" + arrs[11] +
                                       "','" + arrs[12] + "','" + arrs[13] + "','" + arrs[14] + "','" + arrs[15] + "','" + arrs[16] + "','" + arrs[17] + "','" + arrs[18]+ "')";


            status = SetQueryUpdateDatabase(strSQL);
            

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
            }

            return status;
        }

        public bool Update(object model, string id_histori)
        {
            bool status = false;
            try
            {

                ArrayList arrs = SetObjectToArrList(model);
               
                string strSQL = "Update tbhistoriasuransi " +
                            
                   " Set jenis_kelamin_polis='" + arrs[1] + "'" +
                   
                    "where id_histori ='" + id_histori + "'";

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

                string query = "select * from tbhistoriasuransi order by id_histori";
                dt = GetQueryDatabase(query);
                lists = SetDataTableTolist(dt);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
            }

            return lists;
        }

        public object SelectById(string id_histori)
        {
            List<object> lists = null;
            object a = null;
            try
            {

                string query = "select * from tbhistoriasuransi where id_histori ='" + id_histori + "' order by id_histori";
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

                //string query = "select * from tbhistoriasuransi where jenis_kelamin_polis like '%" +
                // criterias[0] + "%' order by id_histori";
                //dt = GetQueryDatabase(query);
                //lists = SetDataTableTolist(dt);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
            }

            return lists;
        }

        public string GetPrimaryKey()
        {

            string id_histori = "";
            if (con.State != ConnectionState.Closed) con.Close();
            con.Open();
            string strTemp = "";
            string strValue = "";
            string strSQL = "Select id_histori from tbhistoriasuransi order by id_histori desc";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                strTemp = dReader["id_histori"].ToString();
            }
            else
            {
                id_histori = "1";
                return id_histori;
            }
            strValue = (int.Parse(strTemp) + 1).ToString();
            id_histori =   strValue;
            con.Close();

            return id_histori;
        }



        #endregion


        public int SelectCount()
        {
            List<int> lists = null;
            int a = 0;
            try
            {

                string query = "select Count(id_histori)as jum from tbhistoriasuransi";
                dt = GetQueryDatabase(query);
                foreach (DataRow dr in dt.Rows) {
                    a =(int) dr[0];
                }

              

            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
            }

            return a;
        }
    }

 

