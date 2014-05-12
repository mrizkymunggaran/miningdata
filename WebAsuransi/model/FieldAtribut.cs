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
    public class FieldAtribut
    {
        public FieldAtribut(string nama, string isi, string fieldDB)
        {
            this.nama = nama;
            this.isi = isi;
            this.fieldDB = fieldDB;
        }
        public FieldAtribut() { }
        public string nama { set; get; }
        public string isi { set; get; }
        public string fieldDB { set; get; }
    }
}
