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
using WebAsuransi.util;

public class C45
{
    C45 c45;
    public string logik { set; get; }
    public  static List<Aturan> TAturan;
    public List<ModelC45> TrainingC45(List<HistoriAsuransi> historis)
    {
        string node = "";
        TAturan = new List<Aturan>();
        List<HistoriAsuransi> Lhistori = historis;
        List<ModelC45> LC45 = new List<ModelC45>();
        List<double> LGain = new List<double>();
        List<Atribut> LAtribut = UtilCode.GetAtribut();
        
        double ES = 0;
        ModelC45 m = new ModelC45();
        m.node = node;
        m.jumKasus = Lhistori.Count();
        m.jumTidak = Lhistori.Count(p => p.status == UtilCode.TStatus[0]);
        m.jumYa = Lhistori.Count(p => p.status == UtilCode.TStatus[1]);
        m.katagori = "";
        m.atribut = "Total";
        m.entropy = Entropy(m.jumTidak, m.jumYa, m.jumKasus);
     //   m.prunning = Prunning(m.jumTidak, m.jumYa, m.jumKasus);
        m.split = 0;
        ES = m.entropy;
      

        LC45.Add(m);


            for (int i = 0; i < LAtribut.Count; i++)
            {
                HitungNode(Lhistori, ref LC45, ref LGain, LAtribut[i].nama, LAtribut[i].arrKode,  ES);
            }


        double gainTertinggi = LGain.ToArray().Max();

        int idx = LGain.FindIndex(p => p == LGain.Max());
        System.Diagnostics.Debug.WriteLine(" GAIN MAX = " + gainTertinggi + "index : " + idx);
        System.Diagnostics.Debug.WriteLine(" NAMA ATRINUT = " + LAtribut[idx].nama);
      
        /*Hitung Node Anak*/
       
        HitungNodeChild(Lhistori, LAtribut, ref LC45, idx, "", new Aturan());
        /*PANGKAS INDUK PRUNNING*/
        LC45.RemoveAll(P => P.node=="INDUK PRUNNING");

        System.Diagnostics.Debug.WriteLine("---------------------LIST ATURAN AKHIR= " + TAturan.Count);

        for (int i = 0; i < TAturan.Count; i++)
        {
           
            System.Diagnostics.Debug.WriteLine((i + 1) + ". " + TAturan[i].fields[0].nama + " = " + TAturan[i].fields[0].isi + " ISI DATA : " + TAturan[i].fields.Count);
        }

        string str = ConvertString.AturanIF(TAturan);
            
        logik = str;

            return LC45;
    }

    public string PrediksiC45(List<string> LUji, List<Aturan> LAturan) {
        string hasil = "";

        Aturan aturanHasil = null;
        for (int i = 0; i < LAturan.Count; i++)
        {
            Aturan atu = LAturan[i];
            int hit = 0;
            /*MEMBANDINGAKAN ISI DARI ATURAN DENGAN DATA PELAGGAN YANG AKAN DI UJI*/
            for (int k = 0; k < atu.prediksis.Count; k++)
            {
                //System.Diagnostics.Debug.WriteLine(" PREDIKSI IF :" + atu.prediksis[k]);
                hit += (LUji.Exists(st => st == atu.prediksis[k]) == true) ? 1 : 0;

            }
               System.Diagnostics.Debug.WriteLine(hit + " COUNT :" + (atu.prediksis.Count-1));
            if (hit == atu.prediksis.Count - 1)
            {
                System.Diagnostics.Debug.WriteLine("HASIL : " + atu.hasil + "");
                aturanHasil = atu;
                break;
            }
        }

        if (aturanHasil != null) hasil = aturanHasil.hasil;

        return hasil;
    }

    public void HitungNodeChild(List<HistoriAsuransi> Lhistori, List<Atribut> LAtribut, ref List<ModelC45> LC45, int idx, string kode,  Aturan aturan)
    {

        
       
        string kod = "";
        double sumPruning = 0;
       // List<FieldAtribut> fields=null;


        /* MODEL C45 UNTUK PRUNNING*/
        /*MENGHITUNG JUMLAH YA DAN TIDAK*/
        /*----------------------*/
        ModelC45 mPruning = new ModelC45();
        mPruning.jumTidak = Lhistori.Count(p => p.status == UtilCode.TStatus[0]);
        mPruning.jumYa = Lhistori.Count(p => p.status == UtilCode.TStatus[1]);
        mPruning.jumKasus = mPruning.jumYa + mPruning.jumTidak;
        mPruning.node = "INDUK PRUNNING";
        mPruning.atribut = LAtribut[idx].nama;
        mPruning.prunning = Prunning(mPruning.jumTidak, mPruning.jumYa, mPruning.jumKasus);
        LC45.Add(mPruning);
        /*----------------------*/
       
        for (int j = 0; j < LAtribut[idx].arrKode.Length; j++)
        {
            //if (LC45.Find(p => p.katagori == LAtribut[idx].arrKode[j].ToString()) != null)//&& p.entropy != 1
            //{
            kod = kode +"." +(j + 1).ToString();

            List<double> LGain = new List<double>();
            List<Atribut> LA = new List<Atribut>();
            LA.AddRange(LAtribut);

            List<HistoriAsuransi> l = new List<HistoriAsuransi>();
            l.AddRange(Lhistori);
           
             
            double ES = 0;
            ModelC45 m = new ModelC45();
            m.node = kod;         
            m.jumKasus = l.Count(p => p.listNode.Exists(x => (x.nama == LA[idx].nama) && (x.isi == LA[idx].arrKode[j])));
           
                 System.Diagnostics.Debug.WriteLine("--------------DARI NODE BESAR---------------------");
             //    System.Diagnostics.Debug.WriteLine(" KODE = " + kod);
         
            m.jumTidak = l.Count(p => p.status == UtilCode.TStatus[0] && p.listNode.Exists(x => (x.nama == LA[idx].nama) && (x.isi == LA[idx].arrKode[j])));
            m.jumYa = l.Count(p => p.status == UtilCode.TStatus[1] && p.listNode.Exists(x => (x.nama == LA[idx].nama) && (x.isi == LA[idx].arrKode[j])));

            
        //    System.Diagnostics.Debug.WriteLine("m.jumKasus  : " + m.jumKasus + "  " + LA[idx].arrKode[j]);

          
            if (m.jumKasus != 0)
            {
                                
                IEnumerable<HistoriAsuransi> query = l.Where(h => h.listNode.Exists(x => (x.nama == LA[idx].nama) && (x.isi == LA[idx].arrKode[j])));
            
                l=(query.ToList<HistoriAsuransi>());
                LA.RemoveAt(idx);
        
            //     System.Diagnostics.Debug.WriteLine(" L count :  = " + l.Count +" | " );
                m.katagori = "";
                m.atribut = LAtribut[idx].nama + " " + LAtribut[idx].arrKode[j].ToString();
                m.entropy = Entropy(m.jumTidak, m.jumYa, m.jumKasus);
                ES = m.entropy;              
                m.split = 0;
                m.fieldAtribut = new FieldAtribut(LAtribut[idx].nama, LAtribut[idx].arrKode[j].ToString(), "");  
                
             //   System.Diagnostics.Debug.WriteLine(" aturan.fields.count = " + aturan.fields.Count);

                m.prunning = Prunning(m.jumTidak, m.jumYa, m.jumKasus);

                sumPruning += ((double)m.jumKasus / (double)mPruning.jumKasus) * m.prunning;
            //    m.gainRatio = sumPruning;
                LC45.Add(m);

                /*pegecekan jika node sudah ada berhenti */
                if ((m.jumTidak != 0) && (m.jumYa != 0))
                {
                    for (int i = 0; i < LA.Count; i++)
                    {

                        HitungNode(l, ref LC45, ref LGain, LA[i].nama, LA[i].arrKode, ES);
                    }

                    double gainTertinggi = LGain.ToArray().Max();
                    int id = LGain.FindIndex(p => p == LGain.Max());
                //    System.Diagnostics.Debug.WriteLine(" kodeeeeeeeeeeeeeeeeee = " + kod + "gainTertinggi = " + gainTertinggi + " ID:  " + id + " Lgain count : " + LGain.Count + " LA.Count : " + LA.Count);
                //    System.Diagnostics.Debug.WriteLine(" NAMA ATRINUT = " + LA[id].nama);

                    if (gainTertinggi > 0)
                    {
                       /* MENGHITUNG LEAF */
                        /* --- CONTOH : 1.1, 1.1.1 DST..*/

                        HitungNodeChild(l, LA, ref LC45, id, kod, aturan);
                    }
                    
                   
                }
                else {

                    aturan = new Aturan();

                    //System.Diagnostics.Debug.WriteLine("---------------------ATURAN FIELD1= " + aturan.fields.Count +" MASUKAN DATA "+ aturan.fields[0].nama + " = " + aturan.fields[0].isi);
                    for (int xi = 1; xi < kod.Length; xi++)
                    {
                        if (kod.ToCharArray()[xi] == '.')
                        {
                            string s = kod.Substring(0, xi);
                         //   System.Diagnostics.Debug.WriteLine("SUBSTRING : " + kod.Substring(0, xi));
                            ModelC45 modelC = LC45.Find(lm => lm.node == s);
                            aturan.fields.Add(modelC.fieldAtribut);
                            //System.Diagnostics.Debug.WriteLine("modelC.fieldAtribut : " + (modelC.fieldAtribut.nama));
                            //System.Diagnostics.Debug.WriteLine("modelC.fieldAtribut isi : " + (modelC.fieldAtribut.isi));
                        }

                    }
                    aturan.fields.Add(m.fieldAtribut);
                    //System.Diagnostics.Debug.WriteLine("m.fieldAtribut : " + (m.fieldAtribut.nama));
                    //System.Diagnostics.Debug.WriteLine("m.fieldAtribut isi : " + (m.fieldAtribut.isi));
                    //System.Diagnostics.Debug.WriteLine("m.fieldAtribut jumTidak : " + (m.jumTidak));
                  
                    aturan.hasil = (m.jumTidak != 0) ? UtilCode.TStatus[0] : UtilCode.TStatus[1];
                    TAturan.Add(aturan);                   
                
                   
                   
                }

            }

            // }
        }

        /*MELAKUKAN PERBANDINGAN UNTUK PRUNNING*/
        /*JIKA JUMLAH PRUNNING ANAK LEBIH BESAR MAKA LAKUKAN PEMANGKASAN*/

        if (sumPruning > mPruning.prunning)
        {
            System.Diagnostics.Debug.WriteLine("------------BERHENTI-------");
            System.Diagnostics.Debug.WriteLine("bawah Pruning > prunning atas = " + sumPruning + " > " + mPruning.prunning);

           
            /*Menghapus / memangkas root yang tidak terpakai*/
            List<ModelC45> CopyL = new List<ModelC45>();
           
            /*Menghapus / memangkas root yang tidak terpakai*/
            for (int pr = LC45.Count - 1; pr > 0; pr--)
            {
                if ((!LC45[pr].atribut.Equals(mPruning.atribut)))
                {
                    System.Diagnostics.Debug.WriteLine(mPruning.atribut);
                   
                    LC45[pr].katagori = "PANGKAS";
                    System.Diagnostics.Debug.WriteLine("------------HAPUS MODEL-------" );
                    
                    /*pangkas modelC45 untuk tabel*/
                 //   LC45.RemoveAt(pr);
                   
                                
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("  COUNT LC45  "+LC45.Count+"  "+ mPruning.jumYa);
                    /*PANGKAS ATURAN*/
                    string atribut = "";
                    string isi = "";
                    atribut = TAturan[TAturan.Count - 1].fields[0].nama;
                    isi = TAturan[TAturan.Count - 1].fields[0].isi;

                    TAturan.RemoveAll(P => P.fields.Exists(c=>c.nama==mPruning.atribut));

                    /*tambahkan aturan pada root yang dipangkas*/
                    aturan = new Aturan();
                    FieldAtribut fa = new FieldAtribut(atribut, isi, "");
                    aturan.fields.Add(fa);
                    aturan.hasil = (mPruning.jumYa > mPruning.jumTidak)?UtilCode.TStatus[1]:UtilCode.TStatus[0];
                    TAturan.Add(aturan);

           

                    break;
                }
            }

            
       
        }
        else {

            System.Diagnostics.Debug.WriteLine("bawah Pruning < prunning atas = " + sumPruning + " < " + mPruning.prunning);

        }

     
       

    }

    private void HitungNode(List<HistoriAsuransi> Lhistori, ref List<ModelC45> LC45, ref List<double> LGain, string node, string[] codes, double ES)
    {

        double tmpGain = 0;
        //  double pruning = 0;
        double tmpSplit = 0;
  
        ModelC45 m = new ModelC45();

        for (int i = 0; i < codes.Length; i++)
        {        
           
            m = new ModelC45();
            m.jumKasus = Lhistori.Count(p => p.listNode.Exists(x=>(x.nama==node) &&  (x.isi==codes[i])));
            m.jumTidak = Lhistori.Count(p => p.status == UtilCode.TStatus[0] && p.listNode.Exists(x => (x.nama == node) && (x.isi == codes[i])));
            m.jumYa = Lhistori.Count(p => p.status == UtilCode.TStatus[1] && p.listNode.Exists(x => (x.nama == node) && (x.isi == codes[i])));
           
            
            m.katagori = codes[i];
            m.atribut = node;
            m.fieldAtribut = new FieldAtribut(node, codes[i], "");
                  //  System.Diagnostics.Debug.WriteLine("--------------DARI NODE KECIL---------------------");
                   // System.Diagnostics.Debug.WriteLine("nama : "+node + " |  isi :  " + codes[i]);
                   // System.Diagnostics.Debug.WriteLine(" codes[i] = " + codes[i] + " - " + Lhistori[0].listNode.Exists(x => (x.nama == node) && (x.isi == codes[i])));
            m.entropy = Entropy(m.jumTidak, m.jumYa, m.jumKasus);
            tmpGain += Gain(m.jumKasus, Lhistori.Count(), m.entropy);//menghitung gain sementra
          
                  //  System.Diagnostics.Debug.WriteLine(" Gain HITUNG Katagori = " + codes[i] + " |jum kasus=  " + m.jumKasus + " |jum atribut = " + Lhistori.Count() + " |entropi= " + m.entropy+"  " +((((double)m.jumKasus / (double)Lhistori.Count()) * (double)m.entropy)));
            tmpSplit += Split(m.jumKasus, Lhistori.Count());//menghitung gain sementra
            // pruning += Prunning(m.jumTidak, m.jumYa, m.jumKasus); 
            m.split = 0;

          // LC45.Add(m);

        }

        //menghitung Gain
        m = new ModelC45();
        m.gain = ES - tmpGain;
        m.split = tmpSplit;
        //  m.prunning = pruning;
        m.gainRatio = GainRatio(m.gain, m.split);
        LGain.Add(m.gainRatio);
     
              // LC45.Add(m);


    }

    private double Entropy(int A, int B, int N)
    {
        //A nilai tidak berhenti
        //B berbenti
        //N jumlah kasus
        //System.Diagnostics.Debug.WriteLine(" A = " + A);
        //System.Diagnostics.Debug.WriteLine(" B = " + B);
        //System.Diagnostics.Debug.WriteLine(" N = " + N);

        if (A == 0 || B == 0)
        {
            return 0;
        }
        else
        {

            return ((-((double)A / (double)N) * (Math.Log(((double)A / (double)N), 2))) + (-((double)B / (double)N) * Math.Log(((double)B / (double)N), 2)));

        }

        //return (Math.Log((6 / 10), 2));
    }
    private double Gain(int A, int N, double EA)
    {
        //A nilai tidak berhenti
        //B berbenti
        //N jumlah kasus

        return ((((double)A / (double)N) * (double)EA));
    }
    private double Split(int A, int N)
    {
        //jumlah pekatagori (A)
        //Jumlah Data

        if (A == 0 || N == 0)
        {
            return 0;
        }
        else
        {

            return ((-((double)A / (double)N) * (Math.Log(((double)A / (double)N), 2))));

        }
    }

    private double GainRatio(double A, double B)
    {
        //gain/Split
        if (A == 0 || B == 0)
        {
            return 0;
        }
        else
        {

            return (A / B);

        }
    }

    private double Prunning(double T, double Y, double N)
    {

        double Z;
        Z = 0.69;
        //   f-->(tidak berhenti/ya berhenti)
        //  N--> Jumlah Data
        //  f+(Z^2)/(2*N) + (Z (SQRT(f/N))) - ((f^2)/N) + ((Z^2)/(4*(N^2))) / (1+ ((Z^2)/N) );

              double min = Math.Min(T, Y);
            double f = min / N;
            double A= (Math.Pow(Z, 2))/(2*N);
            double B1= f/N;
            double B2= Math.Pow(f,2)/N;
            double B3= Math.Pow(Z,2)/(Math.Pow(N,2)*4);
             double B= Z* (Math.Sqrt(B1-B2+B3));
             double C= 1+ (Math.Pow(Z,2)/N);
             double e = (f + A + B) / C;
          //  double e = ((f + (Math.Pow(Z, 2) / (2 * N)) + (Z * (Math.Sqrt((f / N) - ((Math.Pow(f, 2)) / N) + ((Math.Pow(Z, 2) / (4 * (N * N))))) / (1 + ((Math.Pow(Z, 2) / N))))));
            System.Diagnostics.Debug.WriteLine((f + " + " + (Math.Pow(Z, 2))) + " / " + (2 * N) + " / " + (Z * (Math.Sqrt((f / N) - ((Math.Pow(f, 2)) / N) + ((Math.Pow(Z, 2)) / (4 * (N * N)))) / (1 + ((Math.Pow(Z, 2) / N))))));
            return e;


    }




}

