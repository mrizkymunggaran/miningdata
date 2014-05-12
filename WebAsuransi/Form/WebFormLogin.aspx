<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormLogin.aspx.cs" Inherits="WebAsuransi.Form.WebFormLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Src="~/Form/MessageBox.ascx" TagName="Msg" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../styles/Login.css" rel="stylesheet" type="text/css" />
<link href="../styles/buttonBlue.css" rel="stylesheet" type="text/css" />
<%--<link href="App_Themes/default/default.css" rel="stylesheet" type="text/css" />--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>login</title>
    

</head>
<body>
 
    <form id="form1" runat="server">
   
    <%--<div class="tengah_tulisan">    
            <p class="judul">Asuransi </p>    
               
    </div>
      <div class="tengah_tulisan">
    
              <p class="judul_2">teknik informatika</p>     
            
    </div>--%>
   
    <div id="tengah">
    
        <%-- <div align="center"> SISTEM PENJADWALAN FAKULTAS MIPA UNJANI</div>
   --%>
        <div id="tengah_tb">
            <div style="margin-bottom: 10px; font-size:large">
                Login :
            </div>
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>
           <%--   <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />--%>
            <asp:UpdatePanel ID="upLogin" runat="server" RenderMode="Block" UpdateMode="Conditional">
                <ContentTemplate>
                    <table id="grdlogin">
                        <tr>
                            <td>
                                User name
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" Text=""  BorderStyle="Solid" Width="200px" />
                                <br>
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
                                <br>
                                    <asp:Label ID="lblErrPass" runat="server" ForeColor="Red" Text="password is empty"
                                        Visible="false" />
                                
                            </td>
                        </tr>
                    </table>
                   
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="btnlogin">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="button" />
            </div>
            
             <div style="margin-top: 5px;">
                        <asp:Label ID="lblErrLogin" runat="server" ForeColor="Red" Text="No access contact administrator"
                            Visible="false" />
                    </div>
            
           <%-- <asp:Label ID="a" runat="server" Text="<%$ Resources:RLabel, save %>"/>
    
                 <tt><%# (a.Text) %></tt>--%>
        </div>
        
         
    </div>
    
  
    
   
     <uc1:msg id="msgBox" runat="server" />
     
    
    </form>
    
</body>
</html>
