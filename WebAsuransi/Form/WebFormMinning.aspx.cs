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
using System.Data.OleDb;
using System.IO;
using WebAsuransi.dao;
using WebAsuransi.Algortima_C45;
using WebAsuransi.model;
using System.Collections.Generic;

namespace WebAsuransi.Form
{
    public partial class WebFormMinning : System.Web.UI.Page
    {
        string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg.MsgBoxAnswered += MsgAnswered;
            if (!IsPostBack)
            {
                btnPrediksi.Enabled = false;


            }

        }

        protected void btnPrediksi_Click(object sender, EventArgs e)
        {

            ETL etl = new ETL();
            List<Katagori> lModus = etl.GetModus((DataTable)Session["data"]);
            DataTable dt = etl.CleaningData(lModus, (DataTable)Session["data"]);
            //   dt = Transformasi(dt);
           
          
            HistoriAsuransi a = new HistoriAsuransi();
         // List<FieldAtribut> Tfield= new List<FieldAtribut>();
            List<String> TString= new List<String>();
            AturanDao dao = new AturanDao();
            List<Aturan> lAturan = dao.SelectAll().Cast<Aturan>().ToList();
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dra in dt.Rows)
                {
                    /*GET ISI DATA PELANGGAN YANG AKAN DI PREDIKSI*/
                    for (int i = 0; i < UtilCode.TAtribut.Length; i++)
                    {
                    //    FieldAtribut f = new FieldAtribut();
                    //    f.nama = UtilCode.TAtribut[i];
                     //   f.isi = (string)dra[i];
                        string s = UtilCode.TAtribut[i] + " == " + (string)dra[i];
                        System.Diagnostics.Debug.WriteLine(s);
                        TString.Add(s);
                       // Tfield.Add(f);
                    }
                    DivTabelInfo.Visible = true;

                    C45 c45 = new C45();
                   dra[16]= c45.PrediksiC45(TString, lAturan);

                   TString.Clear();

                    
                    
                    
                }

                /*SORTING DATA TABEL*/
                dt.DefaultView.Sort = "Status ASC";
                GridView2.DataSource = dt;
                Session["dataprediksi"] = dt;
                GridView2.DataBind();


                /*save to excel*/
                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

                // Render grid view control.
                GridView2.RenderControl(htw);

                // Write the rendered content to a file.
                string renderedGridView = sw.ToString();

                string nameDate = "" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Minute + DateTime.Now.Second;
                System.IO.File.WriteAllText(Server.MapPath(FilePath) + "Hasilprediksi_" + nameDate + ".xls", renderedGridView);
                string filename = "Hasilprediksi_" + nameDate + ".xls";

                FileDao fileDao = new FileDao();
                FileDir f = new FileDir();
                f.id = int.Parse(fileDao.GetPrimaryKey());
                f.ket = "Hasil Prediksi";
                f.tgl = DateTime.Now;
                f.namaFile = filename;
                f.dir = FilePath + filename;
                f.extention = "application/ms-excel";
                fileDao.Save(f);
            }

        
         

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            if (Session["data"] != null)
            {
                GridView1.DataSource = (DataTable)Session["data"];
                GridView1.DataBind();
                btnPrediksi.Enabled = true;
            }
            else
            {
                btnPrediksi.Enabled = false;
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
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;

            if (Session["dataprediksi"] != null)
            {
                GridView2.DataSource = (DataTable)Session["dataprediksi"];
                GridView2.DataBind();
                
            }
            else
            {
               
            }



        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {


                try
                {
                    string[] allowdFile = { ".xls", ".xlsx" };
                    //Here we are allowing only excel file so verifying selected file pdf or not
                    string FileExt = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
                    string filename = string.Empty;
                    // Get size of uploaded file, here restricting size of file
                    int FileSize = FileUpload1.PostedFile.ContentLength;

                    //Check whether selected file is valid extension or not
                    bool isValidFile = allowdFile.Contains(FileExt);
                    if (!isValidFile)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Hanya file bertipe .xls atau .xlsx yang bisa di submit";
                    }
                    else
                    {

                        if (FileSize <= 1048576)//1048576 byte = 1MB
                        {
                            //Get file name of selected file
                            filename = Path.GetFileName(Server.MapPath(FileUpload1.FileName));

                            //Save selected file into server location
                            FileUpload1.SaveAs(Server.MapPath(FilePath) + filename);
                            //Get file path
                            string filePath = Server.MapPath(FilePath) + filename;
                            //Open the connection with excel file based on excel version
                            OleDbConnection con = null;
                            if (FileExt == ".xls")
                            {
                                con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0;");

                            }
                            else if (FileExt == ".xlsx")
                            {
                                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;");
                            }
                            con.Open();
                            //Get the list of sheet available in excel sheet
                            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            //Get first sheet name
                            string getExcelSheetName = dt.Rows[0]["Table_Name"].ToString();
                            //Select rows from first sheet in excel sheet and fill into dataset
                            OleDbCommand ExcelCommand = new OleDbCommand(@"SELECT * FROM [" + getExcelSheetName + @"]", con);
                            OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
                            DataTable ExcelDataSet = new DataTable();
                            ExcelAdapter.Fill(ExcelDataSet);
                            con.Close();
                            //Bind the dataset into gridview to display excel contents
                            //DataTable
                            GridView1.DataSource = ExcelDataSet;
                            Session["data"] = ExcelDataSet;
                            GridView1.DataBind();
                            btnPrediksi.Enabled = true;

                        }
                        else
                        {
                            lblError.Text = "Attachment file size should not be greater then 1 MB!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error occurred while uploading a file: " + ex.Message;
                }
            }
            else
            {
                lblError.Text = "Please select a file to upload.";
            }
        }

        public void MsgAnswered(object sender, MessageBox.MsgBoxEventArgs e)
        {
            if (e.Answer == MessageBox.enmAnswer.OK)
            {



            }



        }

        protected void btnDownloadPrediksi_Click(object sender, EventArgs e)
        {
            //string nameDate = "" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Minute + DateTime.Now.Second;
            //string attachment = "attachment; filename=Prediksi_" + nameDate + ".xls";
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", attachment);
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //GridView2.RenderControl(htw);
            //Response.Write(sw.ToString());
            //Response.End();

            FileDao fileDao = new FileDao();
            int id = int.Parse(fileDao.GetPrimaryKey()) - 1;
            ArrayList ar = new ArrayList();
            ar.Add("application/ms-excel");
            FileDir f = (FileDir)fileDao.SelectByCriterias(ar).Cast<FileDir>().ToList()[0];
            Download(f);

        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
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
