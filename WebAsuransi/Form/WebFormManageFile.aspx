<%@ Page Language="C#" MasterPageFile="~/Form/Minning.Master" AutoEventWireup="true"
    CodeBehind="WebFormManageFile.aspx.cs" Inherits="WebAsuransi.Form.WebFormManageFile"
    Title="Management file" %>

<%@ Register Src="~/Form/LoadControl.ascx" TagName="load" TagPrefix="lod" %>
<%@ Register Src="~/Form/MessageBox.ascx" TagName="Msg" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" href="../styles/Grid.css" rel="stylesheet" />
    <link type="text/css" href="../styles/GlobalForm.css" rel="stylesheet" />
    <div class="page" style="margin-top: 50px;">
        <div class="page-region-content">
            <h1>
                <i class="icon-folder"></i>Management<small class="on-right">file</small>
            </h1>
        </div>
        <h3>DOWNLOAD
            <small>file repository prediksi asuransi</small></h3> 
        <div id="pnlDownload" class="btnCari">
            
           
               <%--  <asp:UpdatePanel ID="udpMsj" runat="server" UpdateMode="Always" RenderMode="Block">
        <ContentTemplate>--%>
              <div id="DataDiv" style="margin-top: 10px; overflow: auto; border: solid 1px grey;">
                             <asp:GridView ID="GridView1" runat="server" AllowPaging="true" 
                    AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" 
                    GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" 
                    OnRowCreated="GridView1_RowCreated" PagerSettings-PageButtonCount="5" 
                    PagerStyle-CssClass="pgr" PageSize="10" ShowFooter="true">
                    <RowStyle BackColor="White" />
                    <AlternatingRowStyle BackColor="WhiteSmoke" />
                    <FooterStyle CssClass="GridFooterStyle" />
                    <Columns>
                      
                       
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                            <div style="text-align:center;">
                                <asp:Label ID="lblID" runat="server"  Text='<%#Eval("id") %>' /></div>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tanggal">
                            <ItemTemplate>
                            <div style="padding:0 0 0 4;">
                                <asp:Label ID="lblTgl" runat="server" Text='<%#Eval("tgl") %>' /></div>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nama File">
                            <ItemTemplate>
                                    <asp:Label ID="lblNamaFile" runat="server"   Text='<%#Eval("namafile") %>' />
                                
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="NotSet" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Extention">
                            <ItemTemplate>
                                
                                    <asp:Label ID="lblExtention" runat="server"   Text='<%#Eval("extention") %>' />
                                
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="NotSet" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="URL">
                            <ItemTemplate>
                              
                                    <asp:Label ID="lblDir" runat="server"   Text='<%#Eval("dir") %>' />
                             
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="NotSet" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Keterangan">
                            <ItemTemplate>
                              
                                    <asp:Label ID="lblKet" runat="server"   Text='<%#Eval("ket") %>' />
                             
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="NotSet" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField ControlStyle-BackColor="Green" HeaderStyle-BackColor="Green" HeaderText="Download">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnEdit" runat="server" 
                                    Height="15px" ImageUrl="~/cssmui/images/download-32.png" OnClick="OnClickDownload" ToolTip="Download" 
                                    ValidationGroup="Validation" Width="15px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                      
                    </Columns>
                </asp:GridView>
                        </div>
                        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
            
            
        </div>
        <br />
         <div id="pnlUpdate" class="btnCari">
         
            <h3> AKTIF PELANGGAN 
             <small>masih dalam countruction</small></h3>
         </div>
        
        <uc1:Msg ID="Msg" runat="server" />
       
    </div>
</asp:Content>
