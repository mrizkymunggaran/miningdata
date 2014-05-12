<%@ Page Language="C#" MasterPageFile="~/Form/Minning.Master" AutoEventWireup="true" CodeBehind="WebFormLoginAdmin.aspx.cs" Inherits="WebAsuransi.Form.WebFormLoginAdmin" Title="login admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link type="text/css" href="../styles/GlobalForm.css" rel="stylesheet" />
 <div style="margin-top:50px;">
 <div class="page">
        <div class="page-region">
            <div class="page-region-content">
                <h1>
                    <i class="icon-user-3 fg-darker"></i>
                    Login<small class="on-right">Admin</small>
                </h1>

                <p class="description">
                   Hal ini digunakan untuk admin web
                </p>
                
                
               <div class="btnCari">
   
               <div id="tengahHome">           
        
            <asp:UpdatePanel ID="upLogin" runat="server" RenderMode="Block" UpdateMode="Conditional">
                <ContentTemplate>
                
                    <table id="tengahHome">
                        <tr>
                            <td>
                                User name
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" Text=""  BorderStyle="Solid" Width="200px" />
                                
                                    <asp:Label ID="lblErrUserName" runat="server" ForeColor="Red" Text="User name is empty"
                                        Visible="false" />
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Password
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtPass" runat="server" Text="" BorderStyle="Solid" TextMode="Password" Width="200px" />
                                
                                    <asp:Label ID="lblErrPass" runat="server" ForeColor="Red" Text="password is empty"
                                        Visible="false" />
                                
                            </td>
                        </tr>
                    </table>
                   
                </ContentTemplate>
            </asp:UpdatePanel>
          <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="button" />
               <asp:Label ID="lblErrLogin" runat="server" ForeColor="Red" Text="No access contact administrator"
                            Visible="false" />
                   
             <br />
              <br />
        </div>
        
         
    </div>

              
</div>
 </div>
 
 </div>
 </div>
</asp:Content>
