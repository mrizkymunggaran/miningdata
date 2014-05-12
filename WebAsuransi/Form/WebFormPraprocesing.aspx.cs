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
using System.Collections.Generic;
using WebAsuransi.model;
using WebAsuransi.Algortima_C45;

namespace WebAsuransi.Form
{
    public partial class WebFormPraprocesing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg.MsgBoxAnswered += MsgAnswered;
            if (!IsPostBack)
            {
                btnETL.Enabled = false;
                

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
                            string name = System.IO.Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
                            name = name + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Minute + DateTime.Now.Minute + FileExt;
                            FileUpload1.SaveAs(Server.MapPath(FilePath) + name);
                         
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

                            FileDao fileDao = new FileDao();
                            FileDir f = new FileDir();
                            f.id = int.Parse( fileDao.GetPrimaryKey());
                            f.ket = "Praproccesing";
                            f.tgl = DateTime.Now;
                            f.namaFile = name;
                            f.dir = FilePath + name;
                            f.extention = "application/ms-excel";
                            Session["file"]=f;

                            //Bind the dataset into gridview to display excel contents
                            //DataTable



                            GridView1.DataSource = ExcelDataSet;
                            Session["data"] = ExcelDataSet;
                            GridView1.DataBind();
                            btnETL.Enabled = true;

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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            if (Session["data"] != null)
            {
                GridView1.DataSource = (DataTable)Session["data"];
                GridView1.DataBind();
                btnETL.Enabled = true;
            }
            else
            {
                btnETL.Enabled = false;
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

        protected void btnETLProses_Click(object sender, EventArgs e)
        {
         
           ETL etl= new ETL();
          List<Katagori> lModus=  etl.GetModus((DataTable)Session["data"]);
          DataTable dt = etl.CleaningData(lModus, (DataTable)Session["data"]);
       //   dt = Transformasi(dt);
          lblJumlah.Text = etl.jumlahClean+"";
          if (dt != null)
          {
              Session["dataClean"] = dt;
              Div2.Visible = true;
              DivSimpan.Visible = true;
              GridView2.DataSource = dt;
              GridView2.DataBind();
          }
          
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;

            if (Session["dataClean"] != null)
            {
                GridView2.DataSource = (DataTable)Session["dataClean"];
                GridView2.DataBind();
                Div2.Visible = true;
            }
            else
            {
                Div2.Visible = false;  
            }



        }

        
      


        protected void btnSimpan_Click(object sender, EventArgs e) {
            IDao dao = new HistoriAsuransiDao();
            DataTable dt = (DataTable)Session["dataClean"];
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dra in dt.Rows)
                {

                    HistoriAsuransi a = new HistoriAsuransi();
                    a.id_histori = int.Parse(dao.GetPrimaryKey());
                    a.jkPolis = (string)dra[0];
                    a.usiaPolis = (string)dra[1];
                    a.statKawin = (string)dra[2];
                    a.penghasilanPolis = (string)dra[3];
                    a.sumberDana = (string)dra[4];
                    a.kecamatan = (string)dra[5];
                    a.pekerjaan = (string)dra[6];
                    a.jkTertanggung = (string)dra[7];
                    a.usiaTertanggung = (string)dra[8];
                    a.tertanggung_pempol = (string)dra[9];
                    a.penerima_pempol = (string)dra[10];
                    a.jenisAsuransi = (string)dra[11];
                    a.masaAsuransi = (string)dra[12];
                    a.UangPertanggung = (string)dra[13];
                    a.caraBayar = (string)dra[14];
                    a.jenisProses = (string)dra[15];
                    a.status = (string)dra[16];
                    a.statusAktif = 0;
                    dao.Save(a);
                    System.Diagnostics.Debug.WriteLine("TEST");
                }
            }

            FileDao fileDao = new FileDao();
           if (Session["file"]!=null){
           FileDir f=(FileDir) Session["file"];
           fileDao.Save(f);
           Session.Remove("file");
           } 
           
            Msg.AddMessage(MessageProperties.DATA_TERSIMPAN +" Sebanyak " + dt.Rows.Count.ToString(), MessageBox.enmMessageType.Success);
        }
        public void MsgAnswered(object sender, MessageBox.MsgBoxEventArgs e)
        {
            if (e.Answer == MessageBox.enmAnswer.OK)
            {
               


            }



        }



    }
}
