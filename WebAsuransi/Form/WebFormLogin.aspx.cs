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
    public partial class WebFormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            if (!IsPostBack) {
                
            }
           
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {


            if (DoValidate())
            {

                UserDao usrdao = new UserDao();
                User user = (User)usrdao.LoginUser(txtUserName.Text, txtPass.Text);

                if (user != null)
                {
                    string login = SecurityUser.EnkripToBase64(user.idUser);
                    Session["login"] = login;
                    Response.Redirect("WebFormHome.aspx?ID=" + login, false);

                }
                else
                {
                    lblErrLogin.Visible = true;
                }
            }


        }


        private bool DoValidate()
        {
            lblErrPass.Visible = false;
            lblErrUserName.Visible = false;
            int flag = 0;
            string message = "";
            bool stat = true;
            if (!Validator.validNullEmpty(ref flag, ref message, txtUserName, lblErrUserName)) lblErrUserName.Visible = true;
            if (!Validator.validNullEmpty(ref flag, ref message, txtPass, lblErrPass)) lblErrPass.Visible = true;

            if (flag > 0)
            {

                //  msgBox.AddMessage(message, MessageBox.enmMessageType.Error);
                stat = false;
            }

            return stat;


        }

    }
}
