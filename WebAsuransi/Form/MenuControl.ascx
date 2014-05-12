<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs" Inherits="WebAsuransi.Form.MenuControl" %>
<%@ Register TagPrefix="oem" Namespace="OboutInc.EasyMenu_Pro" Assembly="obout_EasyMenu_Pro" %>

	 <link type="text/css" href="../styles/MenuStyle/style.css" rel="stylesheet" />

	<!--// Only needed for this page's formatting //-->
	<style type="text/css">
			
			.tdText {
                font:20px Verdana;
                color:#333333;
            }

            #content {
                position:inherit !important;
	        }
		
		    .ulEM{
		        padding:0 !important;
		        list-style-image:none !important;
                list-style-position:outside !important;
                list-style-type:none !important;
		    }

		    .liEM{
		        background-image:none !important;
		        padding:0 !important;
		        list-style-image:none !important;
                list-style-position:outside !important;
                list-style-type:none !important;
                position:relative !important;
                display:block !important;
                margin:0px !important;
                vertical-align:middle !important;
                
		    }
		
			.liDiv{
		    color:#000000;
              font-family: 'Segoe UI Light_', 'Open Sans Light', Verdana, Arial, Helvetica, sans-serif;

            font-size:12px;
            font-size-adjust:none;  
            font-style:normal;
            font-variant:normal;
            font-weight:normal;
            text-decoration:none;
            padding-right:5px;
            padding-left:1px !important;
             height:30px;
             vertical-align:top;
        }
		
		ul.ulEM il:hover{
		background-color:#B2D065;
		}
		
        .liDivSuite{
        padding-right:4px;
        }
        .liDivSuite img{
        vertical-align:middle;
        border:0;
        }
        
        .liDiv img{
        vertical-align:top;
        border:0;
        }
        
        .liDiv a{
        vertical-align:top !important;
        padding-top:7px;
        padding-left:4px;
        display:block;
        height:27px;
        
        }
        
        .liDiv a:hover
        {
        vertical-align:top !important;
        background-color:#B2D065;
        color:#ffffff;
        padding-left:4px;
        display:block;
        height:27px;
        padding-top:7px;
        padding-left:4px;
       
        }
	    
	    .login{
	    background-color:Gray;
	    border-style:groove !important;
	    border-width:2px !important;
	    border-color:#eeeeee !important;
    
	    width:50px !important;
	    height:20px !important;
	    color:#ffffff !important;
	    font-size:medium !important;
	    padding:2px;
	    }
	    
	    li.menuHead{
	        color:#FF3300;
            font-family:"Segoe UI",Arial,sans-serif";
            font-size:13px;
            font-weight:normal;
            padding-top:6px !important;
            padding-left:10px !important;
            padding-bottom:4px !important;
            height:15px;
            white-space:nowrap;
	    }
	    
		
	</style>
	
	

	    <!--// The head of the menus //-->
	    
    	
	    <oem:EasyMenu id="EasymenuMain" runat="server" ShowEvent="Always" StyleFolder="styles/MenuStyle"
				    Position="Horizontal" CSSMenu="ParentMenu" CSSMenuItemContainer="ParentItemContainer" Width="280">
				    <CSSClassesCollection>
					    <oem:CSSClasses ObjectType="OboutInc.EasyMenu_Pro.MenuItem" ComponentSubMenuCellOver="ParentItemSubMenuCellOver"
						    ComponentContentCell="ParentItemContentCell" Component="ParentItem" ComponentSubMenuCell="ParentItemSubMenuCell"
						    ComponentIconCellOver="ParentItemIconCellOver" ComponentIconCell="ParentItemIconCell"
						    ComponentOver="ParentItemOver" ComponentContentCellOver="ParentItemContentCellOver"></oem:CSSClasses>
					    <oem:CSSClasses ObjectType="OboutInc.EasyMenu_Pro.MenuSeparator" ComponentSubMenuCellOver="ParentSeparatorSubMenuCellOver"
						    ComponentContentCell="ParentSeparatorContentCell" Component="ParentSeparator"
						    ComponentSubMenuCell="ParentSeparatorSubMenuCell" ComponentIconCellOver="ParentSeparatorIconCellOver"
						    ComponentIconCell="ParentSeparatorIconCell" ComponentOver="ParentSeparatorOver"
						    ComponentContentCellOver="ParentSeparatorContentCellOver"></oem:CSSClasses>
				    </CSSClassesCollection>
				    <Components>
				    <oem:MenuItem InnerHtml="Home" ID="item0" Url="WebFormHome.aspx"></oem:MenuItem>
			    <oem:MenuSeparator InnerHtml="|" ID="MenuSeparator2"></oem:MenuSeparator>
			    <oem:MenuItem InnerHtml="Minning Asuransi" ID="item1"></oem:MenuItem>
			    <oem:MenuSeparator InnerHtml="|" ID="mainMenuSeparator1"></oem:MenuSeparator>
		   <%--<oem:MenuItem InnerHtml="ASP.NET MVC Controls" ID="item2"></oem:MenuItem>
			    <oem:MenuSeparator InnerHtml="|" ID="mainMenuSeparator2"></oem:MenuSeparator>
			    <oem:MenuItem InnerHtml="Utilities" ID="item3"></oem:MenuItem>
			    <oem:MenuSeparator InnerHtml="|" ID="mainMenuSeparator3"></oem:MenuSeparator>--%>
			   
		    </Components>
			    </oem:EasyMenu>		
	    <oem:EasyMenu id="Easymenu1" runat="server" ShowEvent="MouseOver" AttachTo="item1" Align="Under" Width="" StyleFolder="styles/MenuStyle" ExpandStyle="Fade">
		    <Components>
			    <oem:MenuItem InnerHtml="" ID="menuItem11">             
                    
                    <div>
                        <table style="vertical-align: top" width="400px" cellpadding="5" cellspacing="5";>
                            <tr>
                                <td valign="top">
                                    <ul class="ulEM">
                                        <li class="liEM menuHead">Praprocessing</li>
                                        <li class="liEM">
                                            <div class="liDiv">
                                                <a href="WebFormPraprocesing.aspx">
                                                    <img src="../Resources/products/grid.gif" alt="" />
                                                   Data Cleanning dan Transformsi</a>
                                            </div>
                                        </li>
                                       <%-- <li class="liEM">
                                            <div class="liDiv">
                                                <a href="http://www.obout.com/t2">
                                                    <img src="../Resources/products/treeview.gif" alt="" />
                                                    ASP.NET TreeView</a>
                                            </div>
                                        </li>
                                        <li class="liEM">
                                            <div class="liDiv">
                                                <a href="http://www.obout.com/tm">
                                                    <img src="../Resources/products/textmenu.gif" alt="" />
                                                    ASP.NET TextMenu</a>
                                            </div>
                                        </li>
                                        <li class="liEM">
                                            <div class="liDiv">
                                                <a href="http://www.obout.com/sm3">
                                                    <img src="../Resources/products/slidemenu.gif" alt="" />
                                                    ASP.NET Slide Menu</a>
                                            </div>
                                        </li>--%>
                                        </ul>
                                </td>
                                <td valign="top">
                                    <ul class="ulEM">
                                        <li  class="liEM menuHead">Proses Minning C45 </li>
                                        <li class="liEM">
                                            <div class="liDiv">
                                                <a href="WebFormTraining.aspx">
                                                    <img src="../Resources/products/scheduler.gif" alt=""  />
                                                    Pelatihan </a>
                                            </div>
                                        </li>
                                        <li class="liEM">
                                            <div class="liDiv">
                                                <a href="WebFormMinning.aspx">
                                                    <img src="../Resources/products/combobox.gif" alt=""  />
                                                    Prediksi </a>
                                            </div>
                                        </li>
                                          <li class="liEM">
                                            <div class="liDiv">
                                                <a href="WebFormInput.aspx">
                                                    <img src="../Resources/products/combobox.gif" alt=""  />
                                                    Minning 2 </a>
                                            </div>
                                        </li>
                                    </ul>
                                </td>
                                <%--<td valign="top">
                                    <ul class="ulEM">
                                        <li class="liEM menuHead">Other Controls</li>
                                        <li class="liEM">
                                            <div class="liDiv">
                                                <a href="http://www.obout.com/Scheduler">
                                                    <img src="../Resources/products/scheduler.gif" alt=""  />
                                                    ASP.NET Scheduler </a>
                                            </div>
                                        </li>
                                        <li class="liEM">
                                            <div class="liDiv">
                                                <a href="http://www.obout.com/splitter">
                                                    <img src="../Resources/products/splitter.gif" alt=""  />
                                                    ASP.NET Splitter </a>
                                            </div>
                                        </li>
                                    </ul>
                                </td>--%>
                            </tr>
                        </table>
                        
                    </div>
                    
            </oem:MenuItem>
		    </Components>
	    </oem:EasyMenu>
	  <%--  <oem:EasyMenu id="Easymenu2" runat="server" ShowEvent="MouseOver" AttachTo="item2" Align="Under" OffsetVertical="-2" Width="" StyleFolder="styles/CustomeStyle" >
            <Components>
                <oem:MenuItem InnerHtml="" ID="menuItem21">
                    <div>
                        <oem:MenuItem InnerHtml="" ID="menuItem2">
                    <div>
                        <ul class="ulEM">
                            <li class="liEM">
                                <div class="liDiv">
                                    <a href="#">
                                        <img src="../Resources/products/button.gif" alt=""  />
                                        obout MVC Button</a>
                                </div>
                            </li>
                            <li class="liEM">
                                <div class="liDiv">
                                    <a href="#">
                                        <img src="../Resources/products/textbox.gif" alt=""  />
                                        obout MVC Textbox </a>
                                </div>
                            </li>
                            <li class="liEM">
                                <div class="liDiv">
                                    <a href="#">
                                        <img src="../Resources/products/radiobutton.gif" alt=""  />
                                        obout MVC Radio Button </a>
                                </div>
                            </li>
                            <li class="liEM">
                                <div class="liDiv">
                                    <a href="#">
                                        <img src="../Resources/products/checkbox.gif" alt=""  />
                                        obout MVC Checkbox </a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </oem:MenuItem>
                    </div>
                </oem:MenuItem>
            </Components>
	    </oem:EasyMenu>--%>
	 <%--   <oem:EasyMenu id="Easymenu3" runat="server" ShowEvent="MouseOver" AttachTo="item3" Align="Under" OffsetVertical="-2" Width="" StyleFolder="styles/CustomeStyle">
		    <Components>
                <oem:MenuItem InnerHtml="" ID="menuItem31">
                    <div>
                        <ul class="ulEM">
                            <li class="liEM">
                                <div class="liDivSuite">
                                    <a href="http://www.obout.com/sitemonitoring">
                                        <img src="../Resources/products/product.png" style="width:60px;" alt="Site Monitoring" />
                                        obout Site Monitoring</a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </oem:MenuItem>
		    </Components>
	    </oem:EasyMenu>
	   
	  --%> 