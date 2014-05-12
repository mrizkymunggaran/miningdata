<%@ Page Language="C#" MasterPageFile="~/Form/Minning.Master" AutoEventWireup="true" CodeBehind="WebFormHome.aspx.cs" Inherits="WebAsuransi.Form.WebFormHome" Title="Home" %>
<%@ Register Src="~/Form/ImageLoader.ascx" TagName="img" TagPrefix="mg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            
     <div style="margin-top:50px;">
    <div class="page">
        <div class="page-region">
            <div class="page-region-content">
                <h1>
                    <i class="icon-home fg-darker smaller"></i>
                    Beranda<small class="on-right">/Cara penggunaan</small>
                </h1>

                <p class="description">
                   informasi dan tata cara penggunaan web minning prediksi asuransi
                </p>
                <div>
                
                <mg:img ID="Img1" runat="Server">
    
                         </mg:img>

                   
                </div>

                <h3 id="_basic">PENJELASAN sistem</h3>
                <p class="description">
                    Metro UI CSS provides carousel component. You must use next <code>html</code> definition to create <code>carousel</code>:
                </p>
                 <h3 id="_usage">PETUNJUK penggunaan</h3>
                <p class="description">
                    To activate carousel with data-api you can add attribute <code>data-role="carousel"</code> to component.
                </p>
                  </div>

              
</div>
</div>
</asp:Content>
