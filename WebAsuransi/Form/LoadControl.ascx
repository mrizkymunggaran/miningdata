<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoadControl.ascx.cs" Inherits="WebAsuransi.Form.LoadControl" %>
<%@ Register TagPrefix="ajx" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
  <link href="../styles/Popup.css" rel="stylesheet" type="text/css" />
 

<script type="text/javascript">
             // Get the instance of PageRequestManager.
             var prm = Sys.WebForms.PageRequestManager.getInstance();
             // Add initializeRequest and endRequest
             prm.add_initializeRequest(prm_InitializeRequest);
             prm.add_endRequest(prm_EndRequest);
             
             // Called when async postback begins
             function prm_InitializeRequest(sender, args) {
                 // get the divImage and set it to visible
                 var panelProg = $get('divLoad');                 
                 panelProg.style.display = '';
              
                 // Disable button that caused a postback
                 $get(args._postBackElement.id).disabled = true;
             }

             // Called when async postback ends
             function prm_EndRequest(sender, args) {
                 // get the divImage and hide it again
                 var panelProg = $get('divLoad');                 
                 panelProg.style.display = 'none';

                 // Enable button that caused a postback
                 $get(sender._postBackSettings.sourceElement.id).disabled = false;
             }
</script>



<div id="divLoad" style=" display: none; position: fixed;	
    z-index: 2; width:100%; background-color:Gray; height:100%;	
     text-align: center;	margin-right: auto;	margin-left: auto;
     margin-top: auto;	margin-bottom: auto; top:0; bottom:0; left: 0; right:0; z-index:0;
    filter: alpha(opacity=5);
	opacity: 0.6;	right: 0;
	
	
	 ">
     
     <div style="position: absolute;   height:50%;	 background-color:White; 
     text-align: center; width:100%;	margin-right: auto;	margin-left: auto;
     	margin-bottom: auto; left: 0;	right: 0; bottom:0; top:100; z-index:1000001;
		right: 0;  ">
      <asp:Image ID="img1" runat="server" ImageUrl="~/images/progress.gif" />
            <b>  Harap tunggu sedang proses ...</b>
              
                  
     </div>
    
     

   
</div>