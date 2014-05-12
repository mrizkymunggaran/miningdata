<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PopHasilPrediksi.ascx.cs" Inherits="WebAsuransi.Form.PopHasilPrediksi" %>
<%@ Register TagPrefix="ajx" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
  <link href="../styles/Popup.css" rel="stylesheet" type="text/css" />
  <%@ Register Src="~/Form/MessageBox.ascx" TagName="Msg" TagPrefix="uc1" %>

  
   
<asp:UpdatePanel ID="udpPopUp" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>    
                       
           <asp:Panel ID="pnlPopUp" runat="server" CssClass="mp" Style="display: none" Width="550px">
             <asp:Panel ID="pnlPopUpHD" runat="server" CssClass="mpHd">
                &nbsp;Popup Hasil Prediksi
                 <asp:Button ID="btnD" runat="server" Text="X" Style="display: none ; float:right"  />
            </asp:Panel>
             <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" CssClass="mp-1" >
                <div style="border:solid 1px grey;">
            <table width="95%" style="font-size:12px; margin:10px;">
                <tr bgcolor="#e1f8ff">
                    <td width="30%">
                        Nama
                    </td>
                  <td width="5%">
                        :
                    </td>
                    <td width="50%">
                        <asp:Label runat="server" ID="txtNama" ></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        Jenis Kelamin Polis
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtJKPolis" runat="server" ></asp:Label>
                    </td>
                  
                </tr>
               <tr bgcolor="#e1f8ff">
                    <td>
                        Usia Pemegang Polis
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtUsiaPolis" runat="server">
                        </asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        Status Perkawinan
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtStatKawin" runat="server"  >
                        </asp:Label>
                    </td>
                                    </tr>
                <tr bgcolor="#e1f8ff">
                    <td>
                        Pengahasilan
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtPengahasilan" runat="server">
                        </asp:Label>
                    </td>
                                 </tr>
                <tr>
                    <td>
                        Sumber Dana
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtSumberDana" runat="server">
                        </asp:Label>
                    </td>
                                   </tr>
                 <tr bgcolor="#e1f8ff">
                    <td>
                        Kecamatan
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtKecamatan" runat="server">
                        </asp:Label>
                    </td>
                                   </tr>
                <tr>
                    <td>
                        Pekerjaan
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtPekerjaan" runat="server">
                        </asp:Label>
                    </td>
                                   </tr>
               <tr bgcolor="#e1f8ff">
                    <td>
                        Jenis Kelamin Tertanggung
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtJkTertanggung" runat="server" BackColor="Transparent" >
                        </asp:Label>
                    </td>
                                    </tr>
                <tr>
                    <td>
                        Usia tertanggung
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtUsiaTertangung" runat="server">
                        </asp:Label>
                    </td>
                                   </tr>
                <tr bgcolor="#e1f8ff">
                    <td>
                        Tertanggung Pempol
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtTertanggungPempol" runat="server">
                        </asp:Label>
                    </td>
                                    </tr>
                <tr>
                    <td>
                        Penerima Pempol
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtPenerimaPempol" runat="server">
                        </asp:Label>
                    </td>
                                    </tr>
                <tr bgcolor="#e1f8ff">
                    <td>
                        Jenis Asuransi
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtJenisAsuransi" runat="server">
                        </asp:Label>
                    </td>
                                    </tr>
                <tr>
                    <td>
                        Masa Asuransi
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtMasaAsuransi" runat="server">
                        </asp:Label>
                    </td>
                                    </tr>
               <tr bgcolor="#e1f8ff">
                    <td>
                        Uang Pertanggungan
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtUangPertanggungan" runat="server">
                        </asp:Label>
                    </td>
                                    </tr>
                <tr>
                    <td>
                        Cara Pembayaran
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtCaraPembayaran" runat="server">
                        </asp:Label>
                    </td>
                                   </tr>
                 <tr bgcolor="#e1f8ff">
                    <td>
                        Jenis Proses
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtJenisProses" runat="server" BackColor="Transparent">
                        </asp:Label>
                    </td>
                                  </tr>
                <tr>
                    <td>
                        Tlp
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="txtTlp" runat="server"></asp:Label>
                    </td>
                                   </tr>
                                   
                                   <tr>
                    <td>
                        Prediksi Status
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="15px"></asp:Label>
                    </td>
                                   </tr>
            </table>
              <br />
            
               <br />
        </div>
                      </asp:Panel>
             
            <div class="mpClose">
                 <asp:Button ID="btnPostOK" runat="server" Text="Simpan" CausesValidation="false" OnClick="btnPostOK_Click"
                    Visible="true" Width="60px" BackColor="Blue" ForeColor="White" />
                <asp:Button ID="btnPostCancel" runat="server" Text="Keluar" CausesValidation="false"
                    OnClick="btnPostCancel_Click" Visible="true" Width="60px" />
            </div>
          
            </asp:Panel>
        
        <ajx:ModalPopupExtender ID="mpeMsg" runat="server" TargetControlID="btnD"
            PopupControlID="pnlPopUp" PopupDragHandleControlID="pnlPopUpHD" BackgroundCssClass="mpBg"
            DropShadow="false">
            
        </ajx:ModalPopupExtender>
          <uc1:Msg ID="msgBox" runat="server" />
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="btnPostOK" EventName="Click" />
     </Triggers>
</asp:UpdatePanel>