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
using WebAsuransi.model;

namespace WebAsuransi.util
{
    public static class ConvertString
    {
        public static string AturanIF(List<Aturan> TAturan)
        {
            string str = "";

            for (int i = 0; i < TAturan.Count; i++)
            {
                Aturan a = TAturan[i];
                System.Diagnostics.Debug.Write((i + 1) + "  IF ");
                str += (i + 1) + ".  IF (";
                for (int j = 0; j < a.fields.Count; j++)
                {
                    System.Diagnostics.Debug.Write(a.fields[j].nama + " == " + a.fields[j].isi);
                    str += a.fields[j].nama + " == " + a.fields[j].isi;
                    if (j < a.fields.Count - 1)
                    {
                        System.Diagnostics.Debug.Write(" && ");
                        str += ") && (";
                    }
                }

                System.Diagnostics.Debug.WriteLine(" THEN  " + a.hasil);
                str += ") THEN <b>" + a.hasil + "</b>";
                str += "</br></br>  ";

                System.Diagnostics.Debug.WriteLine("-------------------------------------------------");
            }
            return str;
        }


        public static List<String> StringToList(string words) {

            string[] split = words.Split(new Char[] {';'});
            List<string> p = new List<string>();
            foreach (string s in split)
            {

                if (s.Trim() != "")
                    p.Add(s);
            }
            return p;
        
        }

        public static string StringSplit(string words, char[] csplit)
        {

            string[] split = words.Split(csplit);
           string p = "";
            foreach (string s in split)
            {

                if (s.Trim() != "")
                    p += s+";";
            }
            return p;

        }

        public static string AturanIFToString(Aturan a)
        {
            string str = "";

                   for (int j = 0; j < a.fields.Count; j++)
                {
                    System.Diagnostics.Debug.Write(a.fields[j].nama + " == " + a.fields[j].isi);
                    str += a.fields[j].nama + " == " + a.fields[j].isi+";";
                   
                }
                
            
            return str+=a.hasil+";";
        }

    }
}
