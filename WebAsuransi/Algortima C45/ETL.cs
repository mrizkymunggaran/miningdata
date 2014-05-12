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
using WebAsuransi.model;
using System.Collections.Generic;

namespace WebAsuransi.Algortima_C45
{
   
    public class ETL
    {
public int jumlahClean;
        public DataTable CleaningData(List<Katagori> l, DataTable dt)
        {
            DataTable dtClean = new DataTable();
            int C = 0;
            int[] f = UtilCode.Fields;
            dtClean = dt.Copy();
            for (int j = 0; j < f.Length; j++)
            {

                for (int i = 0; i < dtClean.Rows.Count; i++)
                {
                    // dtClean.NewRow(); 
                    if (dtClean.Rows[i][f[j]].ToString() == "")
                    {
                        dtClean.Rows[i][f[j]] = l[j].katagori;
                        System.Diagnostics.Debug.WriteLine(" ISI = " + l[j].katagori);
                        C++;
                    }
                    // dtClean.Rows[i][j]= l[j].katagori;
                    // dtClean.Columns.RemoveAt(1);

                }
                // dtClean.Rows.Add(dt.Rows[


            }


            for (int j = dtClean.Columns.Count - 1; j >= 0; j--)
            {
                if (Array.IndexOf(f, j) == -1)
                    dtClean.Columns.RemoveAt(j);
            }

            jumlahClean = C;

            dtClean = Transformasi(dtClean);

            return dtClean;

        }

        private DataTable Transformasi(DataTable dt)
        {
            DataTable dtTrans = new DataTable();
            int colUang = 13;
            int colUTer = 8;
            int colUPolis = 1;
            int colAsuransi = 12;
            int colPenghasilan = 3;
            int colStat = 16;
            dtTrans = dt.Clone();
            dtTrans.Columns[colUang].DataType = typeof(System.String);
            dtTrans.Columns[colUPolis].DataType = typeof(System.String);
            dtTrans.Columns[colUTer].DataType = typeof(System.String);
            dtTrans.Columns[colAsuransi].DataType = typeof(System.String);
            dtTrans.Columns[colStat].DataType = typeof(System.String);

            foreach (DataRow row in dt.Rows)
            {
                dtTrans.ImportRow(row);
            }
            for (int i = 0; i < dtTrans.Rows.Count; i++)
            {
                try { 
              
                dtTrans.Rows[i][colUang] = TransUangPertanggung(double.Parse(dtTrans.Rows[i][colUang].ToString()));                 // dtTrans.Columns[colUTer].DataType = System.Type.GetType("System.String");
                dtTrans.Rows[i][colUTer] = TransUmurTertanggung(int.Parse(dtTrans.Rows[i][colUTer].ToString()));               // dtTrans.Columns[colUPolis].DataType = System.Type.GetType("System.String");
                dtTrans.Rows[i][colUPolis] = TransUmurPemegangPolis(int.Parse(dtTrans.Rows[i][colUPolis].ToString()));
                dtTrans.Rows[i][colAsuransi] = TransMasaAsuransi(int.Parse(dtTrans.Rows[i][colAsuransi].ToString()));
                dtTrans.Rows[i][colStat] = TransStatus(dtTrans.Rows[i][colStat].ToString());

                System.Diagnostics.Debug.WriteLine(" ISI STAT = " + dtTrans.Rows[i][colStat].ToString());

            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("ERROR : " + ex.Message.ToString());
                dtTrans.Rows[i][colStat] = "";
                
                
                }

              
            }





            return dtTrans;

        }

        private string TransUmurTertanggung(int umur)
        {
            string hasil = umur.ToString();


            if (umur <= 23)
            {
                hasil = UtilCode.TUsiaTertanggung[0];
            }
            else if ((umur >= 24) && (umur <= 30))
            {

                hasil = UtilCode.TUsiaTertanggung[1];
            }

            else if ((umur >= 31) && (umur <= 40))
            {
                hasil = UtilCode.TUsiaTertanggung[2];

            }
            else if ((umur >= 41) && (umur <= 50))
            {

                hasil = UtilCode.TUsiaTertanggung[3];
            }
            else if ((umur >= 51) && (umur <= 65))
            {
                hasil = UtilCode.TUsiaTertanggung[4];

            }


            return hasil;
        }

        private string TransUmurPemegangPolis(int umur)
        {
            string hasil = umur.ToString();

            if (umur <= 23)
            {
                hasil = UtilCode.TUsiaPolis[0];
            }
            else if ((umur >= 24) && (umur <= 30))
            {

                hasil = UtilCode.TUsiaPolis[1];
            }

            else if ((umur >= 31) && (umur <= 40))
            {
                hasil = UtilCode.TUsiaPolis[2];
            }
            else if ((umur >= 41) && (umur <= 50))
            {

                hasil = UtilCode.TUsiaPolis[3];
            }
            else if ((umur >= 51) && (umur <= 65))
            {
                hasil = UtilCode.TUsiaPolis[4];

            }


            return hasil;
        }

        private string TransMasaAsuransi(int masa)
        {
            string hasil = masa.ToString();

            if ((masa >= 1) && (masa <= 5))
            {

                hasil = UtilCode.TMassaAsuransi[0];
            }

            else if ((masa >= 6) && (masa <= 10))
            {
                hasil = UtilCode.TMassaAsuransi[1];

            }
            else if ((masa >= 11) && (masa <= 17))
            {

                hasil = UtilCode.TMassaAsuransi[2];
            }


            return hasil;
        }

        private string TransUangPertanggung(double uang)
        {
            string hasil = uang.ToString();

            if ((uang >= 10000000) && (uang <= 50000000))
            {

                hasil = UtilCode.TUangTertanggung[0];
            }

            else if ((uang > 50000000) && (uang <= 100000000))
            {
                hasil = UtilCode.TUangTertanggung[1];

            }
            else if ((uang > 100000000) && (uang <= 150000000))
            {

                hasil = UtilCode.TUangTertanggung[2];
            }
            else if ((uang > 150000000) && (uang <= 200000000))
            {

                hasil = UtilCode.TUangTertanggung[3];
            }
            else if ((uang > 200000000))
            {

                hasil = UtilCode.TUangTertanggung[4];
            }

            return hasil;
        }

        private string TransPenghasilan(double uang)
        {
            string hasil = uang.ToString();

            if ((uang >= 10000000) && (uang <= 50000000))
            {

                hasil = UtilCode.TPenghasilan[0];
            }

            else if ((uang > 50000000) && (uang <= 100000000))
            {
                hasil = UtilCode.TPenghasilan[1];

            }
            else if ((uang > 100000000) && (uang <= 150000000))
            {

                hasil = UtilCode.TPenghasilan[2];
            }
            else if ((uang > 150000000) && (uang <= 200000000))
            {

                hasil = UtilCode.TPenghasilan[3];
            }
            else if ((uang > 200000000))
            {

                hasil = UtilCode.TPenghasilan[4];
            }

            return hasil;
        }

        private string TransStatus(string stat)
        {
            string hasil = stat.ToString();

            if (stat == "1")
            {
                hasil = UtilCode.TStatus[0];
            }
            else if ((stat == "2"))
            {

                hasil = UtilCode.TStatus[1];
            }

            return hasil;
        }

        public List<Katagori> GetModus(DataTable dt)
        {
            List<Katagori> listModus = new List<Katagori>();
            try { 
            
           
            if (dt.Rows.Count != 0)
            {
                int[] f = UtilCode.Fields;
                for (int j = 0; j < f.Length; j++)
                {
                    List<Katagori> listCount = new List<Katagori>();

                    Katagori a = new Katagori();

                    a.katagori = dt.Rows[0][f[j]].ToString();
                    a.count = 1;
                    listCount.Add(a);
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][f[j]].ToString() != "")
                        {
                            if (listCount.FindIndex(p => p.katagori == dt.Rows[i][f[j]].ToString()) != -1)
                            {
                                int index = listCount.FindIndex(p => p.katagori == dt.Rows[i][f[j]].ToString());
                                listCount[index].count++;
                                // System.Diagnostics.Debug.WriteLine("Jumlah index list count ke " + index + " = " + listCount[index].count + " KATAGORI + " + listCount[index].katagori);
                            }
                            else
                            {
                                a = new Katagori();
                                a.katagori = dt.Rows[i][f[j]].ToString();
                                listCount.Add(a);
                                // System.Diagnostics.Debug.WriteLine(a.katagori + "  ---  :" + listCount.Count);
                            }

                        }

                    }

                    Katagori k = listCount.OrderByDescending(p => p.count).ToList()[0];
                    listModus.Add(k);
                    System.Diagnostics.Debug.WriteLine(" MOUDUS = " + k.katagori + "   COunt :" + listModus.Count.ToString());

                }
            }

                 } catch(Exception ex){
                     System.Diagnostics.Debug.WriteLine("ERROR GET MODUS (ETL): " + ex.Message);

                     }
            return listModus;

        }
        
    }


}
