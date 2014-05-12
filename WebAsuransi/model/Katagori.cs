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
    public class Katagori
    {
        public string katagori { set; get; }
        public int id { set; get; }
        public int count { set; get; }
    }
}
