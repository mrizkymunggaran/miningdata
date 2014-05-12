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

namespace WebAsuransi.model
{
    public class Aturan 
    {
        public Aturan(){

            fields = new List<FieldAtribut>();
        
                   }
       
     public List<FieldAtribut> fields { set; get; }
     public string hasil { set; get; }
     public string id { set; get; }
     public string prediksi { set; get; }
     public List<string> prediksis { set; get; }
    }
    
}
