<%@ Page Language="C#" MasterPageFile="~/Form/Minning.Master" AutoEventWireup="true"
    CodeBehind="WebFormTraining.aspx.cs" Inherits="WebAsuransi.Form.WebFormTraining"
    Title="pelatihan" %>

<%@ Register Src="~/Form/LoadControl.ascx" TagName="load" TagPrefix="lod" %>
<%@ Register Src="~/Form/MessageBox.ascx" TagName="Msg" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" href="../styles/Grid.css" rel="stylesheet" />
    <link type="text/css" href="../styles/GlobalForm.css" rel="stylesheet" />
    <link type="text/css" href="../styles/buttonBlue.css" rel="stylesheet" />

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
                <i class="icon-stats-up"></i>Pelatihan<small class="on-right">metode c45</small>
            </h1>
            <div style="font-family: Sans-Serif;">
                <div style="padding-top: 10px; margin-right: auto; margin-left: auto; margin-top: 20px;
                    background-color: Menu;">
                    <asp:Label ID="Label1" runat="server" Text="Jumlah Data :"></asp:Label>
                    <asp:Label ID="lblData" runat="server" Text="" Font-Bold="true"></asp:Label>
                    <p style="font-size: 10px;">
                        Data yang digunakan haruslah lebih dari 1. periksa jumlah data, dan pastikan data
                        yang digunakan <b>valid</b></p>
                </div>
                <lod:load ID="progresswaiting" runat="server"></lod:load>
                <div class="btnCari">
                    <asp:Button ID="btnTraining" runat="server" Text="Proses" OnClick="btnTraining_Click"
                        CssClass="bg-amber" />
                    <p style="font-size: 10px; font-family: Sans-Serif;">
                        Proses untuk memproses menghitung metode C45, hasil pelatihan akan langsung <b>tersimpan
                        </b>dalam database</p>
                </div>
                <br />
                <asp:UpdatePanel ID="udpMsj" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <div id="DivSimpan" style="text-align: right; font-size: 9.5px; font-weight: bold"
                            runat="server" visible="false">
                            <h3>
                                <i class=" icon-download-2"></i>
                                <asp:LinkButton ID="btnExport" runat="server" Text=" Download file excel" OnClick="btnExport_Click" />
                            </h3>
                        </div>
                        <div id="DataDiv" style="margin-top: 10px; overflow: auto; border: solid 1px grey;">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                                OnRowCreated="GridView1_RowCreated" PagerSettings-PageButtonCount="5" PagerStyle-CssClass="pgr"
                                ShowFooter="true" HeaderStyle-Font-Size="12px">
                                <RowStyle BackColor="White" />
                                <AlternatingRowStyle BackColor="WhiteSmoke" />
                                <FooterStyle CssClass="GridFooterStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Node">
                                        <ItemTemplate>
                                            <div style="padding-left: 4px;">
                                                <asp:Label ID="lblNode" runat="server" Text='<%#Eval("node") %>' /></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Atribut">
                                        <ItemTemplate>
                                            <div style="padding-left: 4px;">
                                                <asp:Label ID="lblAtribut" runat="server" Text='<%#Eval("atribut") %>' /></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Katagori">
                                        <ItemTemplate>
                                            <div style="word-wrap: break-word; padding-left: 4px;">
                                                <asp:Label ID="lblKatagori" runat="server" Text='<%#Eval("katagori") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="NotSet" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jumlah Kasus">
                                        <ItemTemplate>
                                            <div style="word-wrap: break-word; text-align: center;">
                                                <asp:Label ID="lblJumKasus" runat="server" Text='<%#Eval("jumKasus") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="NotSet" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ya">
                                        <ItemTemplate>
                                            <div style="word-wrap: break-word; text-align: center;">
                                                <asp:Label ID="lblYa" runat="server" Text='<%#Eval("jumYa") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="NotSet" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tidak">
                                        <ItemTemplate>
                                            <div style="word-wrap: break-word; text-align: center;">
                                                <asp:Label ID="lblTidak" runat="server" Text='<%#Eval("jumTidak") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="NotSet" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Entropy">
                                        <ItemTemplate>
                                            <div style="word-wrap: break-word; padding-left: 4px;">
                                                <asp:Label ID="lblEntropy" runat="server" Text='<%#Eval("entropy") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="NotSet" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gain">
                                        <ItemTemplate>
                                            <div style="word-wrap: break-word; text-align: center;">
                                                <asp:Label ID="lblGain" runat="server" Text='<%#Eval("gain") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="NotSet" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Split">
                                        <ItemTemplate>
                                            <div style="word-wrap: break-word; text-align: center; azimuth">
                                                <asp:Label ID="lblSplit" runat="server" Text='<%#Eval("split") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="NotSet" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gain ratio">
                                        <ItemTemplate>
                                            <div style="word-wrap: break-word; text-align: center;">
                                                <asp:Label ID="lblGain" runat="server" Text='<%#Eval("gainRatio") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="NotSet" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prunning">
                                        <ItemTemplate>
                                            <div style="word-wrap: break-word; padding-left: 4px;">
                                                <asp:Label ID="lblGain" runat="server" Text='<%#Eval("prunning") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="NotSet" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <%-- <asp:Label ID ="Label1" runat="server" Text="Jumlah Data yang yang rusak: "></asp:Label>
                <asp:Label ID ="lblJumlahError" runat="server" Text=""></asp:Label>
                
                
  --%>
                        </div>
                        <div id="DivTabelInfo" runat="server" visible="false" style="padding-top: 10px;">
                            <div id="Div1" style="text-align: left; font-size: 9.5px; font-weight: bold" runat="server"
                                visible="true">
                                <h3>
                                    <i class=" icon-download-2"></i>
                                    <asp:LinkButton ID="btnDownloadAturan" runat="server" Text=" Download aturan" OnClick="btnDownloadAturan_Click" />
                                </h3>
                            </div>
                            <div style="width: 15%; height: 100px; float: right; margin-top: 20px; font-size: 10px;">
                                <table>
                                    <tr>
                                        <td>
                                            <h2>
                                                Jumlah Aturan/logik</h2>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblJumlahLogik" runat="server" Text="" Font-Bold="true" Font-Size="30px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="background-color: ButtonShadow; width: 80%; height: 40px; text-align: center;
                                padding-top: 15px;">
                                Aturan Logik Hasil Trainning :</div>
                            <div style="width: 80%; overflow-y: scroll; padding-top: 10px; background-color: #F5F5F5;">
                                <asp:Label ID="lblLogik" runat="server" Text="" Font-Size="11px"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnTraining" EventName="Click" />
                        <asp:PostBackTrigger ControlID="btnExport" />
                        <asp:PostBackTrigger ControlID="btnDownloadAturan" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <uc1:Msg ID="Msg" runat="server" />
</asp:Content>
