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
using System.IO;
using WebAsuransi.dao;
using WebAsuransi.util;

namespace WebAsuransi.Form
{
    public partial class WebFormTraining : System.Web.UI.Page
    {
        string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg.MsgBoxAnswered += MsgAnswered;
            if (!IsPostBack)
            {
                HistoriAsuransiDao hda = new HistoriAsuransiDao();
             lblData.Text=   hda.SelectCount().ToString();


            }
        }

      
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            if (Session["training"] != null)
            {
              //  GridView1.DataSource = (DataTable)Session["training"];
              //  GridView1.DataBind();
                
            }
            else
            {
                
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

        protected void btnTraining_Click(object sender, EventArgs e)
        {
            DivSimpan.Visible = true;
            IDao idao = new HistoriAsuransiDao();
            List<HistoriAsuransi> l = idao.SelectAll().Cast<HistoriAsuransi>().ToList();
            C45 prosesC45 = new C45();

            List<ModelC45> lModel = prosesC45.TrainingC45(l);
            GridView1.DataSource = lModel;
               GridView1.DataBind();

             //  DivLogik.Visible = true;
               lblJumlahLogik.Text = C45.TAturan.Count+"";
              lblLogik.Text = prosesC45.logik;
              DivTabelInfo.Visible = true;

              AturanDao dao = new AturanDao();
              dao.Delete(null);
              for (int i=0; i < C45.TAturan.Count; i++) { 

              Aturan a= C45.TAturan[i];
              a.id = (i+1)+"";
            
             a.prediksi = ConvertString.AturanIFToString(a);
              dao.Save(a);

              }
                  if (GridView1.Rows.Count > 0) DivSimpan.Visible = true;


            
            
                  /*save to excel*/
              System.IO.StringWriter sw = new System.IO.StringWriter();
              System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

              // Render grid view control.
              GridView1.RenderControl(htw);

              // Write the rendered content to a file.
              string renderedGridView = sw.ToString();
                   
                   string nameDate = "" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Minute + DateTime.Now.Second;
                   System.IO.File.WriteAllText(Server.MapPath(FilePath) + "Trainning_"+nameDate+".xls", renderedGridView);
                   string filename = "Trainning_" + nameDate + ".xls";

                   FileDao fileDao = new FileDao();
                   FileDir f = new FileDir();
                   f.id = int.Parse(fileDao.GetPrimaryKey());
                   f.ket = "Trainning";
                   f.tgl = DateTime.Now;
                   f.namaFile = filename;
                   f.dir = FilePath + filename;
                   f.extention = "application/ms-excel";
                   fileDao.Save(f);

                   /*save aturan to notepad*/

                   string st = lblLogik.Text;
                
                   string Filename = "Aturan_"+nameDate +".txt";
                   if (!File.Exists(Server.MapPath(FilePath)+Filename))
                   {
                       StreamWriter txtFile = File.CreateText(Server.MapPath(FilePath)+Filename);
                       txtFile.Close();
                       txtFile = File.AppendText(Server.MapPath(FilePath)+Filename);
                       txtFile.WriteLine(st);
                       txtFile.Close();
                   }
                   else
                       File.AppendAllText(Server.MapPath(FilePath) + Filename, st);
            fileDao = new FileDao();
                   f = new FileDir();
                   f.id = int.Parse(fileDao.GetPrimaryKey());
                   f.ket = "Aturan";
                   f.tgl = DateTime.Now;
                   f.namaFile = Filename;
                   f.dir = FilePath + Filename;
                   f.extention = "text/plain";
                   fileDao.Save(f);
                      
                          
          
        }

   

        public void MsgAnswered(object sender, MessageBox.MsgBoxEventArgs e)
        {
            if (e.Answer == MessageBox.enmAnswer.OK)
            {
               
            }



        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
        }
        //private void PrepareGridViewForExport(System.Web.UI.Control gv)
        //{
        //    LinkButton lb = new LinkButton();
        //    Literal l = new Literal();
        //    string name = String.Empty;
        //    for (int i = 0; i < gv.Controls.Count; i++)
        //    {
        //        PrepareGridViewForExport(gv);
        //    }
        //}
        protected void btnExport_Click(object sender, EventArgs e)
        {

            FileDao fileDao = new FileDao();
            int id = int.Parse(fileDao.GetPrimaryKey()) - 1;
            ArrayList ar = new ArrayList();
            ar.Add("application/ms-excel");
            FileDir f = (FileDir)fileDao.SelectByCriterias(ar).Cast<FileDir>().ToList()[0];
            Download(f);

            /*export grid to excel*/
            //Response.AddHeader("content-disposition", attachment);
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //GridView1.RenderControl(htw);
            //Response.Write(sw.ToString());
            //Response.End();
        }


        protected void btnDownloadAturan_Click(object sender, EventArgs e)
        {
            FileDao fileDao = new FileDao();
          int id= int.Parse(  fileDao.GetPrimaryKey())-1;
          ArrayList ar = new ArrayList();
          ar.Add("text/plain");
           FileDir f= (FileDir) fileDao.SelectByCriterias(ar).Cast<FileDir>().ToList()[0];
           Download(f);
        }


        private void Download(FileDir f)
        {

            System.Diagnostics.Debug.WriteLine(f.dir);
            //string nameDate = "" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Minute + DateTime.Now.Second;
            string attachment = "attachment;filename=" + f.namaFile.Replace(" ", "_");
            Response.ClearContent();

            Response.ContentType = f.extention;
            Response.AppendHeader("Content-Disposition", attachment);
            Response.TransmitFile(Server.MapPath(f.dir) + "");
            Response.End();

        }
    }
}
