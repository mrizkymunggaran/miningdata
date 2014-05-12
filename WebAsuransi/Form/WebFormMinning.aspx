<%@ Page Language="C#" MasterPageFile="~/Form/Minning.Master" AutoEventWireup="true" CodeBehind="WebFormMinning.aspx.cs" Inherits="WebAsuransi.Form.WebFormMinning" Title="upload prediksi" %>
<%@ Register Src="~/Form/LoadControl.ascx" TagName="load" TagPrefix="lod" %>
<%@ Register Src="~/Form/MessageBox.ascx" TagName="Msg" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link type="text/css" href="../styles/Grid.css" rel="stylesheet" />
<link type="text/css" href="../styles/GlobalForm.css" rel="stylesheet" />
<link type="text/css" href="../styles/buttonBlue.css" rel="stylesheet" />

<div class="page" style="margin-top:50px;">
           <div class="page-region-content">
                <h1>
                   <i class="icon-upload-2"></i>
                    Prediksi<small class="on-right">upload file</small>
                </h1>

<div class="cari">
            <asp:Label ID="judul" runat="server" Text="Upload file berekstensi <b> .xls atau .xlsx. ukuran file max 1MB </b> "></asp:Label><br /><br />
                 <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" />                
               
                <asp:Button ID="btnUpload" runat="server" Text="Submit"  onclick="btnUpload_Click" CssClass="bg-darkGreen fg-white"/>
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
               
            </div>
            
            <br />
            <lod:load id="progresswaiting" runat="server"></lod:load>
        
                <div class="btnCari">
                

                    <asp:Button ID="btnPrediksi" runat="server" Text="Prediksi" OnClick="btnPrediksi_Click" CssClass="bg-green fg-white" ></asp:button>
                     <p style="font-size:10px;  ">proses menghitung metode C45</p>
                  </div>
         
            <div id="DataDiv" style="margin-top: 10px; width:100%; overflow: auto; border:solid 1px grey;" >
                <asp:GridView ID="GridView1" runat="server" AllowPaging="true" 
                    AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging" 
                    OnRowCreated="GridView1_RowCreated"  CssClass="mGrid" 
                    GridLines="None" PagerSettings-PageButtonCount="5" 
                    PagerStyle-CssClass="pgr" PageSize="10" ShowFooter="true">
                    <RowStyle BackColor="White" />
                    <AlternatingRowStyle BackColor="WhiteSmoke" />
                    <FooterStyle CssClass="GridFooterStyle" />                
                </asp:GridView>
               <%-- <asp:Label ID ="Label1" runat="server" Text="Jumlah Data yang yang rusak: "></asp:Label>
                <asp:Label ID ="lblJumlahError" runat="server" Text=""></asp:Label>
  --%>          </div>
         
  
     <asp:UpdatePanel ID="udpMsj" runat="server" UpdateMode="Conditional" RenderMode="Inline" >
         
            <ContentTemplate>          
            
                <div  id="DivTabelInfo" runat="server" visible="false" style="padding-top:10px;">   
                
                <div id="Div1" style="text-align:left; font-size:9.5px; font-weight:bold" runat="server" visible="true" >
                   <h3><i class =" icon-download-2"> </i><asp:LinkButton ID="btnDownloadPrediksi" runat="server" Text=" Download hasil prediksi" OnClick="btnDownloadPrediksi_Click"  />
                   </h3>
                </div>            
                
               <div >
                  
               </t><b><asp:Label ID ="lblHasilPrediki" runat="server" Text=" Hasil Prediksi :"></asp:Label></b>
               </div> 
               
                  <div id="Div2" style="margin-top: 10px; width:100%; overflow: auto; border:solid 1px grey;" >
                <asp:GridView ID="GridView2" runat="server" AllowPaging="true" 
                    AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView2_PageIndexChanging" 
                    OnRowCreated="GridView1_RowCreated"  CssClass="mGrid" 
                    GridLines="None" PagerSettings-PageButtonCount="5"  
                    PagerStyle-CssClass="pgr" PageSize="10" ShowFooter="true">
                    
                    <RowStyle BackColor="White" />
                    <AlternatingRowStyle BackColor="WhiteSmoke" />
                    <FooterStyle CssClass="GridFooterStyle" />                
                </asp:GridView>
               <%-- <asp:Label ID ="Label1" runat="server" Text="Jumlah Data yang yang rusak: "></asp:Label>
                <asp:Label ID ="lblJumlahError" runat="server" Text=""></asp:Label>
  --%>          </div>
    
           
                
                </div>
            </ContentTemplate>
             <Triggers> 
                <asp:AsyncPostBackTrigger ControlID="btnPrediksi" EventName="Click" /> 
                   <asp:PostBackTrigger ControlID="btnDownloadPrediksi" />
                  
                </Triggers>
        </asp:UpdatePanel>  
                
               
     </div>
       <uc1:msg id="Msg" runat="server" />
    
</asp:Content>
