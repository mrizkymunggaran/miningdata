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
    public class FileDir
    {
        public int id { set; get; }
        public DateTime tgl { set; get; }        
        public string   namaFile { set; get; }
        public string extention { set; get; }
        public string ket { set; get; }
        public string dir { set; get; }
    }
}
