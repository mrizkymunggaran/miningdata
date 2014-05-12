using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using WebAsuransi.model;
using System.Collections.Generic;

namespace WebAsuransi.Form
{
    public partial class WebFormManageFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg.MsgBoxAnswered += MsgAnswered;

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //calculate colspan. we want to display totals in the last column
                //and label in the last but one column. since we dont want to deal
                //with the borders and cell widths we simply merge remaining columns
                int labelTextCellColsSpan = e.Row.Cells.Count;
                for (int colIndex = 1; colIndex <= labelTextCellColsSpan - 1; colIndex++)
                    e.Row.Cells[colIndex].Visible = false;
                e.Row.Cells[0].ColumnSpan = labelTextCellColsSpan;
                e.Row.Cells[0].Text = "Total : " + GridView1.Rows.Count;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;



            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // When dosen moves mouse over the GridView row,First save original or previous color to new attribute,
                // and then change it by magenta color to highlight the gridview row.
                e.Row.Attributes.Add("onmouseover", "this.previous_color=this.style.backgroundColor;this.style.backgroundColor='LightGray'");

                // When dosen leaves the mouse from the row,change the bg color
                // or backgroud color to its previous or original value 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.previous_color;");
            }
        }

        private void LoadData()
        {
            try
            {
                //ArrayList arrs = new ArrayList();
                //arrs.Add(txtId.Text);
                //arrs.Add(txtName.Text);

                IDao idao = new FileDao();

                List<object> list = idao.SelectAll();
                if (list == null || list.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("NULL");
                    list = new List<object>();
                    GridView1.EmptyDataText = MessageProperties.NULL_EMPTY;
                    GridView1.DataBind();
                  

                }
                else
                {

                   // countData = list.Count;
                    SettoGrid(list.Cast<FileDir>().ToList());

                }

            }
            catch (Exception es)
            {
                Msg.AddMessage(es.ToString(), MessageBox.enmMessageType.Error);
            }



        }

        private void SettoGrid(List<FileDir> lists)
        {

            GridView1.DataSource = lists;
            GridView1.DataBind();
            

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadData();

        }
        protected void OnClickDownload(object sender, EventArgs e)
        {
            try
            {
          

            ImageButton btn = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int index = gvr.RowIndex;

            Label label = (Label)GridView1.Rows[index].FindControl("lblID");

            FileDao dao = new FileDao();
            FileDir f = (FileDir)dao.SelectById(label.Text);

            Download(f);
           
            }
            catch (Exception ex)
            {


                Msg.AddMessage(ex.Message, MessageBox.enmMessageType.Error);
            }


        }

        private void Download(FileDir f) {

            System.Diagnostics.Debug.WriteLine(f.dir);
            //string nameDate = "" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Minute + DateTime.Now.Second;
            string attachment = "attachment;filename=" + f.namaFile.Replace(" ","_");
            System.Diagnostics.Debug.WriteLine("ATTACTHMENT : " +attachment);
            Response.ClearContent();

            Response.ContentType = f.extention;
            Response.AppendHeader("Content-Disposition", attachment);
            Response.TransmitFile(Server.MapPath(f.dir) +"");
            Response.End();

        }

        public void MsgAnswered(object sender, MessageBox.MsgBoxEventArgs e)
        {
            if (e.Answer == MessageBox.enmAnswer.OK)
            {
               
            }



        }

    }
}
