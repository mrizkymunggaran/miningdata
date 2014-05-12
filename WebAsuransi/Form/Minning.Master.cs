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
    public partial class Minning : System.Web.UI.MasterPage
    {
        public User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                System.Diagnostics.Debug.WriteLine(ContentPlaceHolder1.Page.Title.ToString());


                if (Request.QueryString["ID"] == null)
                {
                 
                    System.Diagnostics.Debug.WriteLine("---REQUEST NULL----");
                    pnlAdmin.Visible = false;
                    pnlAdmin2.Visible = false;
                    pnlUser.Visible = true;
                   

                }
                else
                {

                    System.Diagnostics.Debug.WriteLine("---REQUEST ADA----");
                    pnlAdmin2.Visible = true;
                    pnlAdmin.Visible = true;
                    pnlUser.Visible = false;
                    string login;
                    login = Request.QueryString["ID"];
                    System.Diagnostics.Debug.WriteLine(login);
                    CekLogin(SecurityUser.DeskripBase64(login));
                    lblLogin.Text = "logout ";
                   

                }

               

            }






        }

        private void CekLogin(string login)
        {

            UserDao usrDao = new UserDao();
            user = (User)usrDao.SelectById(login);
            object vId = (object)Session["login"];
            if (user == null || vId == null)
            {

              //  Response.Redirect("Form/WebFormHome.aspx");
                pnlAdmin.Visible = false;
                pnlAdmin2.Visible = false;
                pnlUser.Visible = true;
            }
            else
            {
                lblId.Text = user.idUser;
                lblUserName.Text = user.userName;
              //  lblHide.Text = SecurityUser.EnkripToBase64(lblId.Text);
                // Page.DataBind();
                System.Diagnostics.Debug.WriteLine("--CEK LOGIN ---");
                //  JSMessageBox.Show("ddd");
                //  msg.AddMessage("masuk", Latihan2.util.FormMsg.MessageBox.enmMessageType.Info);
                lblPraposesing.HRef = lblPraposesing.HRef + "?ID=" + SecurityUser.EnkripToBase64(user.idUser);
                lblMfile.HRef = lblMfile.HRef + "?ID=" + SecurityUser.EnkripToBase64(user.idUser);
                lblPelatihan.HRef = lblPelatihan.HRef + "?ID=" + SecurityUser.EnkripToBase64(user.idUser);
                lblUploadMinning.HRef = lblUploadMinning.HRef + "?ID=" + SecurityUser.EnkripToBase64(user.idUser);
                lblHome.HRef = lblHome.HRef + "?ID=" + SecurityUser.EnkripToBase64(user.idUser);
                System.Diagnostics.Debug.WriteLine(lblMfile.HRef.ToString());
                System.Diagnostics.Debug.WriteLine(lblPelatihan.HRef.ToString());
                System.Diagnostics.Debug.WriteLine(lblUploadMinning.HRef.ToString());
                System.Diagnostics.Debug.WriteLine(lblHome.HRef.ToString());



            }

        }
    }
}
