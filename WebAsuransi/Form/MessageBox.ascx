<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBox.ascx.cs" Inherits="WebAsuransi.Form.MessageBox" %>
<%@ Register TagPrefix="ajx" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
  <link href="../styles/Popup.css" rel="stylesheet" type="text/css"/>
  
<asp:UpdatePanel ID="udpMsj" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
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
    
    
    
    
        <asp:Button ID="btnD" runat="server" Text="" Style="display: none" Width="0" Height="0" />
        <asp:Button ID="btnD2" runat="server" Text="" Style="display: none" Width="0" Height="0" />
        <asp:Panel ID="pnlMsg" runat="server" CssClass="mpMsg" Style="display: none" Width="550px" ScrollBars="Auto">
            <asp:Panel ID="pnlMsgHD" runat="server" CssClass="mpHdMsg">
                &nbsp;Message
            </asp:Panel>
          
            <asp:GridView ID="grvMsg" runat="server" ShowHeader="false" Width="100%" AutoGenerateColumns="false" GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                          <asp:Panel ID="pnl1" runat="server" Width="530px"  ScrollBars="Auto" >
                           <div onscroll="Onscrollfnction();">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Image ID="imgErr" runat="server" ImageUrl="~/images/ImgMessage/err.png" 
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Error) ? true : false %>' />
                                        <asp:Image ID="imgSuc" runat="server" ImageUrl="~/images/ImgMessage/suc.png"
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Success) ? true : false %>' />
                                        <asp:Image ID="imgAtt" runat="server" ImageUrl="~/images/ImgMessage/att.png"
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Attention) ? true : false %>' />
                                        <asp:Image ID="imgInf" runat="server" ImageUrl="~/images/ImgMessage/inf.png"
                                            Visible=' <%# (((Message)Container.DataItem).MessageType == enmMessageType.Info) ? true : false %>' />
                                    </td>
                                    <td style="font-size:12px; ">
                                        <%# Eval("MessageText")%>
                                    </td>
                                </tr>
                            </table>
                            </div>
                             </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            <div class="mpCloseMsg">
                <asp:Button ID="btnOK" runat="server" Text="OK" CausesValidation="false" Width="60px" />
                <asp:Button ID="btnPostOK" runat="server" Text="OK" CausesValidation="false" OnClick="btnPostOK_Click"
                    Visible="false" Width="60px" />
                <asp:Button ID="btnPostCancel" runat="server" Text="Cancel" CausesValidation="false"
                    OnClick="btnPostCancel_Click" Visible="false" Width="60px" />
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeMsg" runat="server" TargetControlID="btnD"
            PopupControlID="pnlMsg" PopupDragHandleControlID="pnlMsgHD" BackgroundCssClass="mpBg"
            DropShadow="false" OkControlID="btnOK">
        </ajx:ModalPopupExtender>
    </ContentTemplate>
</asp:UpdatePanel>
