<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageLoader.ascx.cs" Inherits="WebAsuransi.Form.ImageLoader" %>

<link rel="stylesheet" type="text/css" href="../styles/head.css"/>
	  <script language="javascript" src="../jquery/jquery-1.4.js"></script>
	  <script language="javascript" src="../jquery/headline.js"></script>
    <script type="text/javascript"> 
      $(document).ready(function(){
	  		// untuk permulaan, tampilkan content nomor 1 '#slideAwal'
	  		bukaContent($('#slideAwal'),'div1');			
	    });
	  </script>	

<div id="divTrigger">
      <a href="javascript:;" onClick="bukaContent(this,'div1')" id="slideAwal">1</a>
      <a href="javascript:;" onClick="bukaContent(this,'div2')">2</a>
      <a href="javascript:;" onClick="bukaContent(this,'div3')">3</a>
      <a href="javascript:;" onClick="bukaContent(this,'div4')">4</a>
    </div>

    <div id="divContent">
      <div id="div1">
 	     <span class="title">Spy Next Door</span>
 	     <img src="../cssmui/images/1.jpg" align="right" width="50%" /> 
         </div>
      <div id="div2">
 	     <span class="title">Confucius</span>
 	     <img src="../cssmui/images/3.jpg" align="right" width="50%"/> 
        </div>
      <div id="div3">
 	     <span class="title">Ketika Cinta Bertasbih</span>
 	     <img src="../cssmui/images/2.jpg" align="right"width="50%" /> 
 	       </div>
      <div id="div4">
 	     <span class="title">My Name is Khan</span>
 	     <img src="../cssmui/images/4.jpg" align="right" width="50%" />
   <%--     Film dimulai saat seorang anak, Rizwan Khan (Tanay Chheda), seorang muslim yang mengidap sindrom Asperger, hidup bersama ibunya (Zarina Wahab) di wilayah Borivali di Mumbai...
--%>      </div>
    </div>