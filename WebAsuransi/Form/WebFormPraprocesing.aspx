<%@ Page Language="C#" MasterPageFile="~/Form/Minning.Master" AutoEventWireup="true"
    CodeBehind="WebFormPraprocesing.aspx.cs" Inherits="WebAsuransi.Form.WebFormPraprocesing"
    Title="Praprocesing" %>

<%@ Register Src="~/Form/LoadControl.ascx" TagName="load" TagPrefix="lod" %>
<%@ Register Src="~/Form/MessageBox.ascx" TagName="Msg" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" href="../styles/Grid.css" rel="stylesheet" />
    <link type="text/css" href="../styles/GlobalForm.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
     
     
    function Onscrollfnction() 
    {   
        var div = document.getElementByIdMenu('DataDiv'); 
        var div2= document.getElementByIdMenu('HeaderDiv'); 
        //****** Scrolling HeaderDiv along with DataDiv ******
        div2.scrollLeft = div.scrollLeft; 
        return false;
    }
    
    </script>

    <div class="page" style="margin-top: 50px;">
        <div class="page-region-content">
            <h1>
                <i class="icon-cog"></i>Praproses<small class="on-right">perbaikan data</small>
            </h1>
            <div class="cari">
                <asp:Label ID="judul" runat="server" Text="Upload file berekstensi <b> .xls atau .xlsx. ukuran file max 1MB </b> "></asp:Label><br />
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" />
                <asp:Button ID="btnUpload" runat="server" Text="Submit" OnClick="btnUpload_Click"
                    CssClass="bg-darkGreen fg-white" />
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <br />
            <lod:load ID="progresswaiting" runat="server"></lod:load>
            <asp:UpdatePanel ID="udpMsj" runat="server" UpdateMode="Always" RenderMode="Block">
                <ContentTemplate>
                    <div class="btnCari center">
                        <asp:Button ID="btnETL" runat="server" Text="ETL Proses" OnClick="btnETLProses_Click"
                            CssClass="bg-amber fg-white" />
                        <p style="font-size: 10px;">
                            ETL proses untuk memproses perbaikan data, transformasi data</p>
                    </div>
                    <div id="DataDiv" style="margin-top: 10px; width: 100%; overflow: auto; border: solid 1px grey;">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AlternatingRowStyle-CssClass="alt"
                            OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated"
                            CssClass="mGrid" GridLines="None" PagerSettings-PageButtonCount="5" PagerStyle-CssClass="pgr"
                            PageSize="10" ShowFooter="true">
                            <RowStyle BackColor="White" />
                            <AlternatingRowStyle BackColor="WhiteSmoke" />
                            <FooterStyle CssClass="GridFooterStyle" />
                        </asp:GridView>
                        <%-- <asp:Label ID ="Label1" runat="server" Text="Jumlah Data yang yang rusak: "></asp:Label>
                <asp:Label ID ="lblJumlahError" runat="server" Text=""></asp:Label>
  --%>
                    </div>
                    <div id="Div2" runat="server" style="margin-top: 40px; width: 100%; overflow: auto;
                        border: solid 1px grey;" visible="false">
                       <h3> <asp:Label ID="lblClean" runat="server" Text="HASIL PERBAIKAN DATA"></asp:Label></h3>
                        <asp:GridView ID="GridView2" runat="server" AllowPaging="true" AlternatingRowStyle-CssClass="alt"
                            OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCreated="GridView1_RowCreated"
                            CssClass="mGrid" GridLines="None" PagerSettings-PageButtonCount="5" PagerStyle-CssClass="pgr"
                            PageSize="10" ShowFooter="true">
                            <RowStyle BackColor="White" />
                            <AlternatingRowStyle BackColor="WhiteSmoke" />
                            <FooterStyle CssClass="GridFooterStyle" />
                        </asp:GridView>
                        <asp:Label ID="lblInformasi" runat="server" Text="Jumlah Data yang di perbaiki : "
                            Font-Size="12px"></asp:Label>
                        <asp:Label ID="lblJumlah" runat="server" Text="" Font-Size="12px"></asp:Label>
                    </div>
                    <br />
                    <div id="DivSimpan" class="btnCari" runat="server" visible="false" border="1px">
                        <asp:Button ID="btnSimpan" runat="server" Text="Simpan" OnClick="btnSimpan_Click"
                            CssClass="bg-darkBlue fg-white" />
                        <p style="font-size: 10px;">
                            Simpan hasil cleanning kedalam database</p>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <uc1:Msg ID="Msg" runat="server" />
</asp:Content>
