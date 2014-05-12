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


    public abstract partial class Popup : System.Web.UI.UserControl
    {
        //  public object obj;

        public void Show(object obj)
        {
            // this.obj = obj;
            RanderObject(obj);
        }

        public abstract void RanderObject(object obj);


        public class PopupEventArgs : System.EventArgs
        {

            public object Args;

            public PopupEventArgs(object args)
            {

                Args = args;
            }
        }

        public delegate void PopupEventHandler(object sender, PopupEventArgs e);
        // public event PopupEventHandler PopupAnswered;
    }

