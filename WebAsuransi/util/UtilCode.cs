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
using System.Collections;
using WebAsuransi.model;



public class UtilCode
{
    public static int [] Fields={1,3,7,8,9,11,15,17,20,21,25,26,27,28,30,32,35};
   // public static int[] Fields = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 };
    //public enum EJK { L = 1, P = 2 };
    //public enum EJenisProses { MEDIS = 1, NON_MEDIS = 2 };
   // public enum EStatPelanggan { YA = 1, TIDAK = 2 };
    public static string[] TUsiaPolis = {"<=23","24-30","31-40","41-50","51-65" };
    public static string[] TUsiaTertanggung = { "<=23", "24-30", "31-40", "41-50", "51-65" };
    public static string[] TMassaAsuransi = { "1-5", "6-10", "11-17" };
    public static string[] TUangTertanggung = { "10.000.000-50.000.000", "50.000.000-100.000.000", "100.000.000-150.000.000", "150.000.000-200.000.000", ">200.000.000" };
  //  public static string[] TPenghasilan= { "10.000.000-50.000.000", "50.000.000-100.000.000", "100.000.000-150.000.000", "150.000.000-200.000.000", ">200.000.000" };
    public static string[] TPenghasilan = { "<10", "10-25", "25-50", "50-75", "75-100", "100-200", "200-300", "300-500", ">500" };
 
    public static string[] TStatKawin = { "KAWIN","BELUM KAWIN","JANDA/DUDA" };
    public static string[] TSumberDana = { "GAJI", "USAHA PRIBADI", "HASIL INVESTASI", "BONUS/INSENTIF/KOMISI","LAIN-LAIN" };
    public static string[] TKecamatan = { "CIMANGGUNG","CISARUA","CISITU","CONGGEANG","DARMARAJA","GANEAS","JATIGEDE","JATINANGOR",
                                             "JATINUNGGAL","PAMULIHAN","PASEH","RANCAKALONG","SITURAJA","SUKASARI","SUMEDANG SELATAN","SUMEDANG UTARA","SURIAN","TANJUNGKERTA",
                                                "TANJUNGMEDAR","TANJUNGSARI","TOMO","UJUNGJAYA","WADO","BUAH DUA","CIBUGEL","CIMALAKA"};

    public static string[] TPekerjaan = { "PEGAWAI NEGERI SIPIL", "PEGAWAI SWASTA", "WIRASWASTA", "LAIN-LAIN" };
    public static string[] TTertanggungPempol = { "PEMEGANG POLIS SAMA DENGAN TERTANGGUNG", "PEMEGANG POLIS TIDAK SAMA DENGAN TERTANGGUNG" };
    public static string[] TPenerimaPempol = { "ANAK","ORANG TUA","CUCU","SUAMI","ISTRI" };
    public static string[] TJenisAsuransi = { "MITRA BEASISWA","MITRA PERMATA","MITRA MELATI","MITRA CERDAS",
                                                "MITRA SEHAT","MITRA GURU","MITRA BP-LINK" };
    public static string[] TPembayaranPremi = { "BULANAN","TRIWULAN","SETENGAH TAHUNAN","TAHUNAN","TUNGGAL" };
    public static string[] TStatus = { "TIDAK BERHENTI", "BERHENTI" };
    public static string[] TJenisProses = { "MEDIS", "NON MEDIS" };

    public static string[] TJKTertanggung = { "LAKI-LAKI", "PEREMPUAN" };
    public static string[] TJKPolis = { "LAKI-LAKI", "PEREMPUAN" };

    public static string[] TfieldDb ={"id_histori","jenis_kelamin_polis" ,"usia_pemegang_polis" ,	"status_perkawinan" ,	"penghasilan" ,	"sumber_dana" ,	"kecamatan" ,
	                            "pekerjaan" ,	"jenis_kelamin_tertangung" ,	"usia_tertanggung" ,	"tertanggung_pempol","penerima_pempol",
	                                "jenis_asuransi" ,	"masa_asuransi" ,	"uang_pertanggungan" ,	"cara_pembayaran" ,	"jenis_proses" ,	"status"};

    public static string[] TAtribut ={"JK Polis" ,"Usia Polis" ,	"S Kawin" ,	"Penghasilan" ,	"S Dana" ,	"Kecamatan Polis" ,
	                            "Pekerjaan" ,	"JK Tertanggung" ,	"Usia Tertangung" ,	"Tertanggung Pempol","Penerima Pempol",
	                                "Jenis Asuransi" ,	"Masa Asuransi" ,	"Uang Pertanggungan" ,	"Cara Bayar" ,	"Jenis Proses" ,	"Status"};

    public static List<Atribut> GetAtribut()
    {
        List<Atribut> l = new List<Atribut>();
        Atribut a = new Atribut();
        a.nama = TAtribut[0];
        a.arrKode = UtilCode.TJKPolis;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[1];
        a.arrKode = UtilCode.TUsiaPolis;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[2];
        a.arrKode = UtilCode.TStatKawin;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[3];
        a.arrKode = UtilCode.TPenghasilan;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[4];
        a.arrKode = UtilCode.TSumberDana;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[5];
        a.arrKode = UtilCode.TKecamatan;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[6]; 
        a.arrKode = UtilCode.TPekerjaan;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[7];
        a.arrKode = UtilCode.TJKTertanggung; ;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[8];
        a.arrKode = UtilCode.TUsiaTertanggung;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[9];
        a.arrKode = UtilCode.TTertanggungPempol;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[10];
        a.arrKode = UtilCode.TPenerimaPempol;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[11];
        a.arrKode = UtilCode.TJenisAsuransi;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[12];
        a.arrKode = UtilCode.TMassaAsuransi;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[13];
        a.arrKode = UtilCode.TUangTertanggung;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[14];
        a.arrKode = UtilCode.TPembayaranPremi;
        l.Add(a);

        a = new Atribut();
        a.nama = TAtribut[15];
        a.arrKode = UtilCode.TJenisProses;
        l.Add(a);

       

        return l;
    }
    
    //public static List<Katagori> SelectAllEJenisProses()
//    {
//        List<Katagori> l = null;
//        foreach (int i in Enum.GetValues(typeof(EJenisProses))) {
//            Katagori a = new Katagori();
//            a.id = i;
//            a.katagori = Enum.GetName(typeof(EJenisProses), i);
//            l.Add(a);
            
//        }
//        return l;
//    }

//    public static List<Katagori> SelectAllJK()
//    {
//        List<Katagori> l = null;
//        foreach (int i in Enum.GetValues(typeof(EJK)))
//        {
//            Katagori a = new Katagori();
//            a.id = i;
//            a.katagori = Enum.GetName(typeof(EJK), i);
//            l.Add(a);
//        }
//        return l;
//    }

//    public static List<Katagori> SelectAllEStatPelanggan()
//    {
//        List<Katagori> l = null;
//        foreach (int i in Enum.GetValues(typeof(EStatPelanggan))) {
//            Katagori a = new Katagori();
//            a.id = i;
//            a.katagori = Enum.GetName(typeof(EStatPelanggan), i);
//            l.Add(a);
//        }
//        return l;
//}

    public static List<Katagori> SelectAllUP()
    {
        IDao idao = new UPDao();
        List<object> l = idao.SelectAll();
        return l.Cast<Katagori>().ToList();
    }

    public static List<Katagori> SelectCaraBayar()
    {
        IDao idao = new CaraBayarDao();
        List<object> l = idao.SelectAll();
        return l.Cast<Katagori>().ToList();
    }

    public static List<Katagori> SelectAllJenisAsuransi()
    {
        IDao idao = new JenisAsuransiDao();
        List<object> l = idao.SelectAll();
        return l.Cast<Katagori>().ToList();
    }

    public static List<Katagori> SelectAllKecamatan()
    {
        IDao idao = new KecamatanDao();
        List<object> l = idao.SelectAll();
        return l.Cast<Katagori>().ToList();
    }

    public static List<Katagori> SelectAllMassaAsuransi()
    {
        IDao idao = new MasaAsuransiDao();
        List<object> l = idao.SelectAll();
     
        return l.Cast<Katagori>().ToList();
    }

    public static List<Katagori> SelectAllPekerjaan()
    {
        IDao idao = new PekerjaanDao();
        List<object> l = idao.SelectAll();
        return l.Cast<Katagori>().ToList();
    }

    public static List<Katagori> SelectAllPenghasilan()
    {
        IDao idao = new PenghasilanDao();
        List<object> l = idao.SelectAll();
        return l.Cast<Katagori>().ToList();
    }


    public static List<Katagori> SelectAllStatKawin()
    {
        IDao idao = new StatKawinDao();
        List<object> l = idao.SelectAll();
        return l.Cast<Katagori>().ToList();
    }

    public static List<Katagori> SelectAllSumberDana()
    {
        IDao idao = new SumberDanaDao();
        List<object> l = idao.SelectAll();
        return l.Cast<Katagori>().ToList();
    }

    public static List<Katagori> SelectAllUsiaPolis()
    {
        IDao idao = new UsiaPolisDao();
        List<object> l = idao.SelectAll();
        return l.Cast<Katagori>().ToList();
    }
    

    //public static void LoadJurusan(ref DropDownList dr)
    //{
    //    dr.Items.Clear();
    //    IDao idao = new JurusanDao();
    //    List<object> l = idao.SelectAll();
    //    //Cara 1

    //    // dr.DataSource = l;
    //    // dr.DataTextField = "namaJurusan";
    //    // dr.DataValueField = "idJurusan";
    //    // dr.DataBind();

    //    //Cara 2
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    for (int i = 0; i <= l.Count - 1; i++)
    //    {
    //        Jurusan jur = (Jurusan)l[i];
    //        dr.Items.Add(new ListItem(jur.namaJurusan, jur.idJurusan + ""));

    //    }



    //}

    //public static void LoadDosen(ref DropDownList dr)
    //{
    //    dr.Items.Clear();
    //    IDao idao = new DosenDao();
    //    List<object> l = idao.SelectAll();
    //    //Cara 1

    //    // dr.DataSource = l;
    //    // dr.DataTextField = "namaJurusan";
    //    // dr.DataValueField = "idJurusan";
    //    // dr.DataBind();

    //    //Cara 2
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    for (int i = 0; i <= l.Count - 1; i++)
    //    {
    //        Dosen d = (Dosen)l[i];
    //        dr.Items.Add(new ListItem(d.namaDosen , d.idDosen + ""));

    //    }



    //}

    //public static void LoadMK(ref DropDownList dr, string idJur)
    //{
    //    dr.Items.Clear();
    //    IDao idao = new MataKuliahDao();
    //    ArrayList arr = new ArrayList();
    //    arr.Add("");
    //    arr.Add("");
    //    arr.Add(idJur);
    //    List<object> l = idao.SelectByCriterias(arr);
    //    //Cara 1

    //    // dr.DataSource = l;
    //    // dr.DataTextField = "namaJurusan";
    //    // dr.DataValueField = "idJurusan";
    //    // dr.DataBind();

    //    //Cara 2
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    for (int i = 0; i <= l.Count - 1; i++)
    //    {
    //        MataKuliah d = (MataKuliah)l[i];
    //        dr.Items.Add(new ListItem(d.namaMk, d.idmk + ""));

    //    }



    //}

    //public static void LoadTahunAkademik(ref DropDownList dr){

    //    dr.Items.Clear();
    //    int i =2000;
    //    ArrayList a= new ArrayList();
    //   dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //     while(i<= DateTime.Now.Year+1)
    //    {
    //        a.Add(i + "/" + (i + 1));
    //         dr.Items.Add(new ListItem(i + "/" + (i + 1),i + "/" + (i + 1)));
    //        i++;
          
    //    }
    //     dr.SelectedValue=(DateTime.Now.Year + "/" + (DateTime.Now.Year + 1));

    //}

    //public static void LoadSemester(ref DropDownList dr, string kel)
    //{
    //    dr.Items.Clear();
    //    int i = 1;
    //    ArrayList a = new ArrayList();
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    while (i <= 8)
    //    {
    //        if (kel == "GANJIL")
    //        {
    //            if ((i % 2) == 1)
    //            {
    //                dr.Items.Add(new ListItem(i + "", i + ""));
    //            }

    //        }
    //        else {

    //            if ((i % 2) == 0)
    //            {
    //                dr.Items.Add(new ListItem(i + "", i + ""));
    //            }
            
    //        }
           
            
            
    //        i++;

    //    }


    //}

    //public static void LoadSKS(ref DropDownList dr)
    //{
    //    dr.Items.Clear();
    //    int i = 1;
    //    ArrayList a = new ArrayList();
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    while (i <= 5)
    //    {

    //        dr.Items.Add(new ListItem(i + "", i + ""));
    //        i++;

    //    }


    //}

    //public static void LoadDurasi(ref DropDownList dr)
    //{
    //    dr.Items.Clear();
    //    int i = 1;
    //    ArrayList a = new ArrayList();
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    while (i <= 12)
    //    {

    //        dr.Items.Add(new ListItem(i + "", i + ""));
    //        i++;

    //    }


    //}

    //public static void LoadHari(ref DropDownList dr)
    //{
    //    dr.Items.Clear();
    //    IDao idao = new HariDao();
    //    ArrayList arr=new ArrayList();
    //    arr.Add(1);
    //    List<object> l = idao.SelectByCriterias(arr);
    //    //Cara 1

    //    // dr.DataSource = l;
    //    // dr.DataTextField = "namaJurusan";
    //    // dr.DataValueField = "idJurusan";
    //    // dr.DataBind();

    //    //Cara 2
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    for (int i = 0; i <= l.Count - 1; i++)
    //    {
    //        Hari hr = (Hari)l[i];
            
    //        dr.Items.Add(new ListItem(hr.namaHari , hr.idHari + ""));

    //    }



    //}
    //public static void LoadJamAwal(ref DropDownList dr)
    //{
    //    dr.Items.Clear();

        

    //    int i = 7;
    //    ArrayList a = new ArrayList();
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    while (i <= 20)
    //    {

    //        string tmp = i + "";
    //        string id = "00".Substring(0, 2 - tmp.Length) + i + ".00";
    //        dr.Items.Add(new ListItem(id + "", id + ""));
    //        i++;

    //    }


    //}
    //public static void LoadJam(ref DropDownList dr)
    //{
    //    dr.Items.Clear();

    //    IDao idao = new JamDao();
    //    List<object> l = idao.SelectAll();
    //    Jam jam = (Jam)l[0];
    //    System.Diagnostics.Debug.WriteLine(jam.jamAwal.ToString().Substring(0, 2));
    //    int jamAwal = int.Parse(jam.jamAwal.ToString().Substring(0, 2));
    //    int jamAkhir = int.Parse(jam.jamAkhir.ToString().Substring(0, 2));


    //    int i = jamAwal;
    //    ArrayList a = new ArrayList();
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    while (i <= jamAkhir)
    //    {

    //        string tmp = i + "";
    //      string  id =  "00".Substring(0, 2-tmp.Length) + i+".00";
    //      dr.Items.Add(new ListItem(id + "", id + ""));
    //        i++;

    //    }


    //}

    //public static void LoadUserTipe(ref DropDownList dr)
    //{
    //    dr.Items.Clear();
    //    IDao idao = new TipeUserDao();
    //    List<object> l = idao.SelectAll();
    //    //Cara 1

    //    // dr.DataSource = l;
    //    // dr.DataTextField = "namaJurusan";
    //    // dr.DataValueField = "idJurusan";
    //    // dr.DataBind();

    //    //Cara 2
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    for (int i = 0; i <= l.Count - 1; i++)
    //    {
    //        TipeUser d = (TipeUser)l[i];
    //        dr.Items.Add(new ListItem(d.tipe, d.idTipe + ""));

    //    }



    //}

    //public static void LoadKelompok(ref RadioButtonList dr)
    //{
    //    dr.Items.Clear();     
    //    ArrayList a = new ArrayList();
    //    dr.Items.Add(new ListItem("GANJIL", "GANJIL"));
    //    dr.Items.Add(new ListItem("GENAP" , "GENAP"));
       


    //}

    //public static void LoadKelas(ref DropDownList dr)
    //{
    //    string s = "ABCDEFGH";
    //    dr.Items.Clear();
    //    int i = 0;
    //    ArrayList a = new ArrayList();
    //    dr.Items.Add(new ListItem("-Pilih-", string.Empty));
    //    while (i <= s.Length-1)
    //    {

    //        dr.Items.Add(new ListItem(s[i] + "", s[i] + ""));
    //        i++;

    //    }


    //}

}
