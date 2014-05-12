using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;
using WebAsuransi.model;
using WebAsuransi.dao;

namespace WebAsuransi.Form
{
    public partial class WebFormInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pop.PopupAnswered += PopReturn;
            Msg.MsgBoxAnswered += MsgAnswered;
            if (!IsPostBack)
            {
               
                txtCaraPembayaran.DataSource = UtilCode.TPembayaranPremi;
                txtUsiaPolis.DataSource = UtilCode.TUsiaPolis;
              
                txtUsiaTertangung.DataSource = UtilCode.TUangTertanggung;
               
                txtMasaAsuransi.DataSource = UtilCode.TMassaAsuransi;
                txtJenisAsuransi.DataSource = UtilCode.TJenisAsuransi;
                txtKecamatan.DataSource = UtilCode.TKecamatan;
                txtPekerjaan.DataSource = UtilCode.TPekerjaan;
                txtPenerimaPempol.DataSource = UtilCode.TPembayaranPremi;
                txtPengahasilan.DataSource = UtilCode.TPenghasilan;
                txtSumberDana.DataSource = UtilCode.TSumberDana;
                txtTertanggungPempol.DataSource = UtilCode.TTertanggungPempol;
                txtUangPertanggungan.DataSource = UtilCode.TUangTertanggung;
                rbJenisProses.DataSource = UtilCode.TJenisProses;
                rbJKPolis.DataSource = UtilCode.TJKPolis;
                rbJkTertanggung.DataSource = UtilCode.TJKTertanggung;
                rbStatKawin.DataSource = UtilCode.TStatKawin;
                txtUsiaTertangung.DataBind();

                txtUsiaPolis.DataBind();
                txtMasaAsuransi.DataBind();
                txtJenisAsuransi.DataBind();
                txtKecamatan.DataBind();
                txtPekerjaan.DataBind();
                txtPenerimaPempol.DataBind();
                txtPengahasilan.DataBind();
                txtSumberDana.DataBind();
                txtTertanggungPempol.DataBind();
                txtUangPertanggungan.DataBind();
                rbJenisProses.DataBind();
                rbJKPolis.DataBind();
                rbJkTertanggung.DataBind();
                rbStatKawin.DataBind();             
                txtCaraPembayaran.DataBind();

                txtUsiaPolis.Items.Insert(0,new ListItem("-Pilih-"));
                txtMasaAsuransi.Items.Insert(0,new ListItem("-Pilih-"));
                txtJenisAsuransi.Items.Insert(0,new ListItem("-Pilih-"));
                txtKecamatan.Items.Insert(0,new ListItem("-Pilih-"));
                txtPekerjaan.Items.Insert(0,new ListItem("-Pilih-"));
                txtPenerimaPempol.Items.Insert(0,new ListItem("-Pilih-"));
                txtPengahasilan.Items.Insert(0,new ListItem("-Pilih-"));
                txtSumberDana.Items.Insert(0,new ListItem("-Pilih-"));
                txtTertanggungPempol.Items.Insert(0,new ListItem("-Pilih-"));
                txtUangPertanggungan.Items.Insert(0,new ListItem("-Pilih-"));
                rbJenisProses.SelectedIndex = 0;
                rbJKPolis.SelectedIndex = 0;
                rbJkTertanggung.SelectedIndex = 0;
                rbStatKawin.SelectedIndex = 0;
                txtCaraPembayaran.Items.Insert(0,new ListItem("-Pilih-"));
                txtUsiaTertangung.Items.Insert(0, new ListItem("-Pilih-"));


                txtUsiaPolis.SelectedIndex=1;
                txtMasaAsuransi.SelectedIndex=1;
                txtJenisAsuransi.SelectedIndex=1;
                txtKecamatan.SelectedIndex=1;
                txtPekerjaan.SelectedIndex=1;
                txtPenerimaPempol.SelectedIndex=1;
                txtPengahasilan.SelectedIndex=1;
                txtSumberDana.SelectedIndex=1;
                txtTertanggungPempol.SelectedIndex=1;
                txtUangPertanggungan.SelectedIndex=1;
                txtUsiaTertangung.SelectedIndex = 1;
                txtCaraPembayaran.SelectedIndex=1;
                txtNama.Text = "test";
                txtTlp.Text = "12345";
            }
        }

        protected void btnPrediksi_Click(object sender, EventArgs e)
        {
           
           if (DoValidate()){


               List<String> TString = new List<String>();
               AturanDao dao = new AturanDao();
               List<Aturan> lAturan = dao.SelectAll().Cast<Aturan>().ToList();


               TString.Add(UtilCode.TAtribut[1].ToString() + " == " + rbJKPolis.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[2].ToString() + " == " + txtUsiaPolis.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[2].ToString() + " == " + rbStatKawin.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[3].ToString() + " == " + txtPengahasilan.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[4].ToString() + " == " + txtSumberDana.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[5].ToString() + " == " + txtKecamatan.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[6].ToString() + " == " + txtPekerjaan.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[7].ToString() + " == " + rbJkTertanggung.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[8].ToString() + " == " + txtUsiaTertangung.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[9].ToString() + " == " + txtTertanggungPempol.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[10].ToString() + " == " + txtPenerimaPempol.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[11].ToString() + " == " + txtJenisAsuransi.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[12].ToString() + " == " + txtMasaAsuransi.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[13].ToString() + " == " + txtUangPertanggungan.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[14].ToString() + " == " + txtCaraPembayaran.SelectedValue.ToString());
               TString.Add(UtilCode.TAtribut[15].ToString() + " == " + rbJenisProses.SelectedValue.ToString());

               HistoriAsuransi h = new HistoriAsuransi();
               h.jkPolis = rbJKPolis.SelectedValue.ToString();
               h.usiaPolis = txtUsiaPolis.SelectedValue.ToString();
               h.statKawin = rbStatKawin.SelectedValue.ToString();
               h.penghasilanPolis = txtPengahasilan.SelectedValue.ToString();
               h.sumberDana = txtSumberDana.SelectedValue.ToString();
               h.kecamatan = txtKecamatan.SelectedValue.ToString();
               h.pekerjaan = txtPekerjaan.SelectedValue.ToString();
               h.jkTertanggung = rbJkTertanggung.SelectedValue.ToString();
               h.usiaTertanggung = txtUsiaTertangung.SelectedValue.ToString();
               h.tertanggung_pempol = txtTertanggungPempol.SelectedValue.ToString();
               h.penerima_pempol = txtPenerimaPempol.SelectedValue.ToString();
               h.jenisAsuransi = txtJenisAsuransi.SelectedValue.ToString();
               h.masaAsuransi = txtMasaAsuransi.SelectedValue.ToString();
               h.UangPertanggung = txtUangPertanggungan.SelectedValue.ToString();
               h.caraBayar = txtCaraPembayaran.SelectedValue.ToString();
               h.jenisProses = rbJenisProses.SelectedValue.ToString();
               h.nama = txtNama.Text;
               h.tlp = txtTlp.Text;
               for (int i = 0; i < TString.Count - 1; i++)
               {
                   System.Diagnostics.Debug.WriteLine(TString[i]);
               }


             
               C45 c45 = new C45();
               h.status = c45.PrediksiC45(TString, lAturan);
               System.Diagnostics.Debug.WriteLine("HASIL : " + h.status);
               Pop.Show(h);


           }
        }
        public void MsgAnswered(object sender, MessageBox.MsgBoxEventArgs e)
        {
            if (e.Answer == MessageBox.enmAnswer.OK)
            {
                
            }



        }

        public void PopReturn(object sender, Popup.PopupEventArgs e)
        {

            if (e.Args != null)
            {
                Msg.AddMessage(e.Args.ToString() + "", MessageBox.enmMessageType.Info);

               
            }

        }

        private bool DoValidate() {

            bool stat = true;
            int flag = 0;
            string message = "";

            Validator.validSelectedEmpty(ref flag, ref message, txtJenisAsuransi, lblErJenisAsuransi);
            Validator.validSelectedEmpty(ref flag, ref message, txtKecamatan, lblErKecamatan);
            Validator.validSelectedEmpty(ref flag, ref message, txtMasaAsuransi, lblErMasaAsuransi);
            Validator.validSelectedEmpty(ref flag, ref message, txtPekerjaan, lblErPekerjaan);
            Validator.validSelectedEmpty(ref flag, ref message, txtPenerimaPempol, lblErPenerimaPempol);
            Validator.validSelectedEmpty(ref flag, ref message, txtPengahasilan, lblErPenghasilan);
            Validator.validSelectedEmpty(ref flag, ref message, txtSumberDana, lblErSumberDana);
            Validator.validSelectedEmpty(ref flag, ref message, txtTertanggungPempol, lblErTertanggungPempol);
            Validator.validSelectedEmpty(ref flag, ref message, txtUangPertanggungan, lblErUangPertanggungan);
            Validator.validSelectedEmpty(ref flag, ref message, txtUsiaPolis, lblErUsiaPolis);
            Validator.validSelectedEmpty(ref flag, ref message, txtUsiaTertangung, lblErUangPertanggungan);
            Validator.validNullEmpty(ref flag, ref message, txtNama, lblErNama);
            Validator.validSelectedEmpty(ref flag, ref message, txtCaraPembayaran , lblErCaraPembayaran);




            if (flag > 0)
            {
                Msg.AddMessage(message, MessageBox.enmMessageType.Error);
                stat = false;
            }

            return stat;
        }

    }
}
