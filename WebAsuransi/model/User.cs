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

namespace WebAsuransi.model
{
    public class User
    {
        public string idUser { set; get; }
        public string userName { set; get; }
        public string password { set; get; }
        public string tipeUser { set; get; }
        //public TipeUser tipeUser { set; get; }
    }
}
