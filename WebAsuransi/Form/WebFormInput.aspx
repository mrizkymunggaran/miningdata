<%@ Page Language="C#" MasterPageFile="~/Form/Minning.Master" AutoEventWireup="true"
    CodeBehind="WebFormInput.aspx.cs" Inherits="WebAsuransi.Form.WebFormInput" Title="Form Prediksi" %>

<%@ Register Src="~/Form/PopHasilPrediksi.ascx" TagName="Pop" TagPrefix="po" %>
<%@ Register Src="~/Form/LoadControl.ascx" TagName="load" TagPrefix="lod" %>
<%@ Register Src="~/Form/MessageBox.ascx" TagName="Msg" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" href="../styles/Grid.css" rel="stylesheet" />
    <link type="text/css" href="../styles/GlobalForm.css" rel="stylesheet" />
    <link type="text/css" href="../styles/buttonBlue.css" rel="stylesheet" />
    <div class="page" style="margin-top: 50px;">
        <div class="page-region-content">
            <h1>
                <i class="icon-snowy-5"></i>Form Prediksi<small class="on-right">masukan</small>
            </h1>
            <div style="border: solid 1px grey; width: 80%">
                <table width="98%" style="font-size: 12px; margin: 10px;">
                    <tr bgcolor="#e1f8ff">
                        <td>
                            Nama
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNama" Width="400"></asp:TextBox>
                        </td>
                        <asp:Label ID="lblErNama" runat="server" Text="Nama" ForeColor="Red" Visible="false" />
                    </tr>
                    <tr>
                        <td>
                            Jenis Kelamin Polis
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbJKPolis" runat="server" RepeatDirection="Horizontal" Width="200px">
                            </asp:RadioButtonList>
                        </td>
                        <asp:Label ID="lblErJkPolis" runat="server" Text="JK Polis" ForeColor="Red" Visible="false" />
                    </tr>
                    <tr bgcolor="#e1f8ff">
                        <td>
                            Usia Pemegang Polis
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtUsiaPolis" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErUsiaPolis" runat="server" Text="Usia Polis" ForeColor="Red" Visible="false" />
                    </tr>
                    <tr>
                        <td>
                            Status Perkawinan
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbStatKawin" runat="server" RepeatDirection="Horizontal"
                                Width="300px">
                            </asp:RadioButtonList>
                        </td>
                        <asp:Label ID="lblErStatKawin" runat="server" Text="Stat Kawin" ForeColor="Red" Visible="false" />
                    </tr>
                    <tr bgcolor="#e1f8ff">
                        <td>
                            Pengahasilan
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtPengahasilan" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErPenghasilan" runat="server" Text="Penghasilan" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr>
                        <td>
                            Sumber Dana
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtSumberDana" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErSumberDana" runat="server" Text="Sumber Dana" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr bgcolor="#e1f8ff">
                        <td>
                            Kecamatan
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtKecamatan" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErKecamatan" runat="server" Text="Kecamatan" ForeColor="Red" Visible="false" />
                    </tr>
                    <tr>
                        <td>
                            Pekerjaan
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtPekerjaan" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErPekerjaan" runat="server" Text="Pekerjaan" ForeColor="Red" Visible="false" />
                    </tr>
                    <tr bgcolor="#e1f8ff">
                        <td>
                            Jenis Kelamin Tertanggung
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbJkTertanggung" runat="server" RepeatDirection="Horizontal"
                                Width="200px" BackColor="Transparent">
                            </asp:RadioButtonList>
                        </td>
                        <asp:Label ID="lblErJkTertanggung" runat="server" Text="JkTertanggung" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr>
                        <td>
                            Usia tertanggung
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtUsiaTertangung" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErUsiaTertanggung" runat="server" Text="Usia Tertanggung" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr bgcolor="#e1f8ff">
                        <td>
                            Tertanggung Pempol
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtTertanggungPempol" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErTertanggungPempol" runat="server" Text="Tertanggung Pempol" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr>
                        <td>
                            Penerima Pempol
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtPenerimaPempol" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErPenerimaPempol" runat="server" Text="Penerima Pempol" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr bgcolor="#e1f8ff">
                        <td>
                            Jenis Asuransi
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtJenisAsuransi" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErJenisAsuransi" runat="server" Text="Jenis Asuransi" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr>
                        <td>
                            Masa Asuransi
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtMasaAsuransi" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErMasaAsuransi" runat="server" Text="Masa Asuransi" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr bgcolor="#e1f8ff">
                        <td>
                            Uang Pertanggungan
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtUangPertanggungan" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErUangPertanggungan" runat="server" Text="Uang Pertanggungan" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr>
                        <td>
                            Cara Pembayaran
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="txtCaraPembayaran" runat="server">
                            </asp:DropDownList>
                        </td>
                        <asp:Label ID="lblErCaraPembayaran" runat="server" Text="Cara Pembayaran" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr bgcolor="#e1f8ff">
                        <td>
                            Jenis Proses
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbJenisProses" runat="server" RepeatDirection="Horizontal"
                                Width="200px" BackColor="Transparent">
                            </asp:RadioButtonList>
                        </td>
                        <asp:Label ID="lblErJenisProses" runat="server" Text="Jenis Proses" ForeColor="Red"
                            Visible="false" />
                    </tr>
                    <tr>
                        <td>
                            Tlp
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtTlp" runat="server"></asp:TextBox>
                        </td>
                        <asp:Label ID="lblErTlp" runat="server" Text="Tlp" ForeColor="Red" Visible="false" />
                    </tr>
                </table>
                <br />
                <div id="DivSimpan" class="btnCari">
                    <%--<asp:Button ID="btnPrediksi" runat="server" Text="Prediksi" OnClick="btnPrediksi_Click"
                    CssClass="command-button primary" ></asp:Button>--%>
                    <asp:Button ID="btnPrediksi" runat="server" Text="Prediksi" OnClick="btnPrediksi_Click"
                        CssClass="command-button primary"></asp:Button>
                    <p>
                        <i class="icon-share-3 on-right"></i>Prediksi, Asuransi <small>proses menghitung metode
                            C45</small></p>
                </div>
                <br />
            </div>
        </div>
        <uc1:Msg ID="Msg" runat="server" />
        <po:Pop ID="Pop" runat="server" />
    </div>
</asp:Content>
