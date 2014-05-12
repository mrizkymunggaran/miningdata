using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using WebAsuransi.model;

namespace WebAsuransi.Form
{
    public partial class PopHasilPrediksi : Popup
    {

        public event PopupEventHandler PopupAnswered;
        HistoriAsuransi h;
        public override void RanderObject(object obj)
        {
            if (obj != null)
            {
                h = (HistoriAsuransi)obj;
                Session["h"] = h;

                txtNama.Text = h.nama;
                txtUsiaPolis.Text = h.usiaPolis;
                txtTlp.Text = h.tlp;
                txtUsiaTertangung.Text = h.usiaTertanggung;

                txtMasaAsuransi.Text =h.masaAsuransi;
                txtJenisAsuransi.Text = h.jenisAsuransi;
                txtKecamatan.Text = h.kecamatan;
                txtPekerjaan.Text = h.pekerjaan;
                txtPenerimaPempol.Text = h.penerima_pempol;
                txtPengahasilan.Text = h.penghasilanPolis;
                txtSumberDana.Text = h.sumberDana;
                txtTertanggungPempol.Text = h.tertanggung_pempol;
                txtUangPertanggungan.Text = h.UangPertanggung;
                txtJenisProses.Text = h.jenisProses;
                txtJKPolis.Text = h.jkPolis;
                txtJkTertanggung.Text = h.jkTertanggung;
                txtStatKawin.Text = h.statKawin;
                txtUsiaTertangung.Text=h.usiaTertanggung;
                lblStatus.Text = h.status;
                txtCaraPembayaran.Text = h.caraBayar;

            }
           

            udpPopUp.Update();
            mpeMsg.Show();
        }

        protected void btnPostOK_Click(object sender, EventArgs e)
        {



            if (Session["h"] != null)
                {
                    HistoriAsuransiDao dao = new HistoriAsuransiDao();
                    h = (HistoriAsuransi)Session["h"];
                    h.id_histori = int.Parse( dao.GetPrimaryKey());
                    h.statusAktif = 1;
                                   dao.Save(h);
                    PopupAnswered(this, new PopupEventArgs(MessageProperties.DATA_TERSIMPAN));

                }

           

        }

        protected void btnPostCancel_Click(object sender, EventArgs e)
        {




        }
    }
}