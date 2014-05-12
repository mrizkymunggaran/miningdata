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
    public class ModelC45
    {
        public string node { set; get; }
        public string atribut { set; get; }
        public string katagori { set; get; }
        public int jumKasus { set; get; }
        public int jumYa { set; get; }
        public int jumTidak { set; get; }
        public double entropy { set; get; }
        public double gain { set; get; }
        public double split { set; get; }
        public double gainRatio { set; get; }
        public double prunning { set; get; }
        public List<Aturan> aturans { set; get; }
       public FieldAtribut fieldAtribut { set; get; }
    }
}
