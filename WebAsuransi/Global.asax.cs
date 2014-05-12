using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

namespace WebAsuransi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

            //Uncomment the following line to demonstrate an infinite loop - caution: you will have 
            //to stop the request manually
            //  Response.Redirect("NoSuchPageExists.aspx");


            //Uncomment the following code for handling application level errors - this would 
            //prevent customErrors settings to come into scope

            string path;

            path = "~/ErrorPages/ApplicationError.html";

            // Uncomment this line to force exception for 404
            //			path = "/ErrorHandling/ErrorPages/NoSuchPageExists.html";

            try
            {
                Server.ClearError();

                // Attempt to redirect the user
                Server.Transfer(path);
            }
            catch
            {
                // Error occured while redirecting user to an error page. We could do nothing
                // now, but setting a status code and completing the request
                Response.StatusCode = 404;
                this.CompleteRequest();
            }

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}