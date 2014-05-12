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
using System.Security.Cryptography;
using System.Text;


    public class SecurityUser
    {
        public static string EncodePasswordMD5(string pass)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }

        public string EncryptPasswordSHA256(string password)
        {
            byte[] pass = Encoding.UTF8.GetBytes(password);

            SHA256 encpwrd = new SHA256CryptoServiceProvider();
            return Encoding.UTF8.GetString(encpwrd.ComputeHash(pass));
        }


        public static string EnkripToBase64(string id)
        {

            byte[] data = UnicodeEncoding.Unicode.GetBytes(id);
            return Convert.ToBase64String(data);
        }

        public static string DeskripBase64(string enkrip)
        {
            string re = "";
            try
            {
                byte[] data = Convert.FromBase64String(enkrip);

                re= UnicodeEncoding.Unicode.GetString(data);

            }
            catch (Exception e) {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString() +" SECURITY ");
                re = "";
            }

            return re;
        }
    }

      
    

