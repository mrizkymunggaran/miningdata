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

namespace WebAsuransi.model
{
    public class HistoriAsuransi
    {
        public int id_histori { set; get; }
        public string jkPolis { set; get; }
        public string jkTertanggung { set; get; }
        public string usiaPolis { set; get; }
        public string sumberDana { set; get; }
        public string usiaTertanggung { set; get; }
        public string statKawin { set; get; }
        public string kecamatan { set; get; }
        public string pekerjaan { set; get; }
        public string penghasilanPolis { set; get; }
        public string UangPertanggung { set; get; }
        public string tertanggung_pempol { set; get; }
        public string penerima_pempol { set; get; }
        public string jenisAsuransi { set; get; }
        public string masaAsuransi { set; get; }
        public string jenisProses { set; get; }
        public string caraBayar { set; get; }
        public string status { set; get; }
        public string nama { set; get; }
        public string tlp { set; get; }
        public int statusAktif { set; get; }
        public List<FieldAtribut> listNode { set; get; }

        //public void SetList()
        //{
        //    List<string> l = new List<string>();
        //    l.Add(jkPolis);
        //    l.Add(usiaPolis);
        //    l.Add(statKawin);
        //    l.Add(penghasilanPolis);
        //    l.Add(sumberDana);
        //    l.Add(kecamatan);
        //    l.Add(pekerjaan);
        //    l.Add(jkTertanggung);
        //    l.Add(usiaTertanggung);
        //    l.Add(tertanggung_pempol);
        //    l.Add(penerima_pempol);
        //    l.Add(jenisAsuransi);
        //    l.Add(masaAsuransi);
        //    l.Add(UangPertanggung);
        //    l.Add(jenisProses);
        //    l.Add(caraBayar);
        //    listNode = l;
           

        //}


        public void SetList()
        {
            List<FieldAtribut> l = new List<FieldAtribut>();
            FieldAtribut a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[0];
            a.isi = jkPolis;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[1];
            a.isi=  usiaPolis;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[2];
            a.isi = statKawin;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[3];
            a.isi = penghasilanPolis;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[4];
            a.isi = sumberDana;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[5];
            a.isi = kecamatan;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[6];
            a.isi = pekerjaan;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[7];
            a.isi = jkTertanggung;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[8];
            a.isi = usiaTertanggung;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[9];
            a.isi = tertanggung_pempol;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[10];
            a.isi = penerima_pempol;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[11];
            a.isi = jenisAsuransi;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[12];
            a.isi = masaAsuransi;
            l.Add(a);


            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[13];
            a.isi = UangPertanggung;
            l.Add(a);


            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[14];
            a.isi = caraBayar;
            l.Add(a);

            a = new FieldAtribut();
            a.nama = UtilCode.TAtribut[15];
            a.isi = jenisProses;
            l.Add(a);

            listNode = l;
            
        }
              
        //public List<String> GetList() {
        //    List<string> l = new List<string>();
        //l.Add(jkPolis );
        //l.Add(usiaPolis);
        //l.Add(statKawin);
        //l.Add(penghasilanPolis);
        //l.Add(sumberDana);        
        //l.Add(kecamatan);
        //l.Add(pekerjaan);
        //l.Add(jkTertanggung);
        //l.Add(usiaTertanggung);        
        //l.Add(tertanggung_pempol);
        //l.Add(penerima_pempol);
        //l.Add(jenisAsuransi);
        //l.Add(masaAsuransi);
        //l.Add(UangPertanggung);
        //l.Add(jenisProses);
        //l.Add(caraBayar);
        
        //return l;
        
        //}

       

    }
}
