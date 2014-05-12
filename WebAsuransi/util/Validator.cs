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


using System.Drawing;


public class Validator
{

   static Color err = System.Drawing.Color.Bisque;
   static Color NoErr = System.Drawing.Color.LightCyan;
  
  
    public static bool validZeroEmpty(ref int flag, ref string message, TextBox textbox, Label lbl)
    {
        //MsgBox(textbox.Text)
        if ((string.IsNullOrEmpty(textbox.Text)) | (textbox.Text == "0") | (textbox.Text == "0.0") | (textbox.Text == ""))
        {
            flag += 1;

            message += "<br>* " + lbl.Text + MessageProperties.NULL_EMPTY;
          //  textbox.BackColor = err;
          //  lbl.Text = lbl.Text + MessageProperties.NULL_EMPTY;
          //  lbl.Visible = true;
            // textbox.BackColor=
            return false;
        }
        else
        {
           // textbox.BackColor = NoErr;
            lbl.Visible = false;
            return true;
        }
    }

    public static bool validNullEmpty(ref int flag, ref string message, TextBox textbox, Label lbl)
    {
        //MsgBox(textbox.Text)
        if ((string.IsNullOrEmpty(textbox.Text)) | (textbox.Text == ""))
        {
            flag += 1;

            message += "</br>* " + lbl.Text + MessageProperties.NULL_EMPTY;
          //  lbl.Text = lbl.Text + MessageProperties.NULL_EMPTY;
          // lbl.Visible = true;
          //  textbox.BackColor = err;
            return false;
        }
        else
        {
            lbl.Visible = false;
          //  textbox.BackColor = NoErr;
            return true;
        }
    }

    public static bool ValidCheckBoxInGridCheck(GridView grd, string ID)
    {
        bool abool = false;
        try
        {
            for (int i = 0; i <= grd.Rows.Count - 1; i++)
            {

                CheckBox chk = (CheckBox)grd.Rows[i].FindControl(ID);
                if (chk.Checked == true)
                {

                    abool = true;
                    i = grd.Rows.Count - 1;
                }

            }

        }
        catch (Exception ex)
        {
            MsgBox.Show(ex.Message.ToString());
        }
        return abool;
    }

    public static bool validSameData(ref int flag, ref string message, TextBox textbox, Dao dao)
    {
        IDao idao = (IDao)dao;
        object obj = idao.SelectById(textbox.Text);

        if (obj != null)
        {
            flag += 1;
            message += "<br>* " + textbox.Text + MessageProperties.SAME_DATA;
            return false;
        }
        else
        {
            return true;
        }

    }

    public static bool validInteger(ref int flag, ref string message, TextBox textbox, Label lbl)
    {
        //MsgBox(textbox.Text)

        try {

            int number = int.Parse(textbox.Text);
            lbl.Visible = false;
            return true;
        
        
        }catch(Exception e){

            flag += 1;
            textbox.Text = "0";
            message += "<br>* " + lbl.Text + MessageProperties.MUST_NUMBER;
            //  textbox.BackColor = err;
            //  lbl.Text = lbl.Text + MessageProperties.NULL_EMPTY;
            //  lbl.Visible = true;
            // textbox.BackColor=
            return false;
        
        }
       
    }

    public static bool validDouble(ref int flag, ref string message, TextBox textbox, Label lbl)
    {
        //MsgBox(textbox.Text)

        try
        {

            double number = double.Parse(textbox.Text);
            lbl.Visible = false;
            return true;


        }
        catch (Exception e)
        {

            flag += 1;
            textbox.Text = "0.0";
            message += "<br>* " + lbl.Text + MessageProperties.MUST_NUMBER;
            //  textbox.BackColor = err;
            //  lbl.Text = lbl.Text + MessageProperties.NULL_EMPTY;
            //  lbl.Visible = true;
            // textbox.BackColor=
            return false;

        }

    }

    public static bool validSelectedEmpty(ref int flag, ref string message, DropDownList dd, Label lbl)
    {
        //MsgBox(textbox.Text)
        if (dd.SelectedValue==string.Empty || dd.SelectedIndex==0)
        {
            flag += 1;

            message += "<br>* " + lbl.Text + MessageProperties.NOT_SELECTED;
            //  lbl.Text = lbl.Text + MessageProperties.NULL_EMPTY;
            // lbl.Visible = true;
            //  textbox.BackColor = err;
            return false;
        }
        else
        {
            lbl.Visible = false;
            //  textbox.BackColor = NoErr;
            return true;
        }
    }


    public static bool validIntMin(ref int flag, ref string message, TextBox textbox, int min, Label lbl)
    {
        //MsgBox(textbox.Text)
        int nilai =int.Parse(textbox.Text);
        if ((nilai > min))
        {
            // textbox.BackColor = NoErr;
            lbl.Visible = false;
            return true;

          
        }
        else
        {

            flag += 1;

            message += "<br>* " + lbl.Text + MessageProperties.MUST_MAX_THAN + min;
            //  textbox.BackColor = err;
            //  lbl.Text = lbl.Text + MessageProperties.NULL_EMPTY;
            //  lbl.Visible = true;
            // textbox.BackColor=
            return false;
           
        }
    }


    public static bool validDoubleMin(ref int flag, ref string message, TextBox textbox, double min, Label lbl)
    {
        //MsgBox(textbox.Text)
        double nilai = double.Parse(textbox.Text);
        if ((nilai > min))
        {
            // textbox.BackColor = NoErr;
            lbl.Visible = false;
            return true;


        }
        else
        {

            flag += 1;

            message += "<br>* " + lbl.Text + MessageProperties.MUST_MAX_THAN + min;
            //  textbox.BackColor = err;
            //  lbl.Text = lbl.Text + MessageProperties.NULL_EMPTY;
            //  lbl.Visible = true;
            // textbox.BackColor=
            return false;

        }
    }

    public static bool validNumberBetween(ref int flag, ref string message, TextBox textbox, double min, double max, Label lbl)
    {
        //MsgBox(textbox.Text)
        double nilai = double.Parse(textbox.Text);
        if ((nilai > min) && nilai <= max)
        {
            // textbox.BackColor = NoErr;
            lbl.Visible = false;
            return true; 
        }
        else
        {          
            flag += 1;

            message += "<br>* " + lbl.Text + MessageProperties.MUST_BETWEEN +min + " dan " + max;
            //  textbox.BackColor = err;
            //  lbl.Text = lbl.Text + MessageProperties.NULL_EMPTY;
            //  lbl.Visible = true;
            // textbox.BackColor=
            return false;
        }
    }


}

