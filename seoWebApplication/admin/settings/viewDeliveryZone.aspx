<%@ Page Title="" Language="C#" MasterPageFile="~/adminMstr.Master" AutoEventWireup="true" CodeBehind="viewDeliveryZone.aspx.cs" Inherits="seoWebApplication.admin.settings.viewDeliveryZone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/jscript/style.css">
	
	
	<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
		<script type="text/javascript" src="/jscript/jquery-1.4.2.min.js"></script>
	<script type="text/javascript" src="/jscript/polygon.min.js"></script>
    <asp:Literal ID="mapLiteral" runat="server"></asp:Literal>
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
		<ul>
			<li class="title">
				Delivery zone 
			</li>
            <li class="title">
			</li>
            <li class="title">
			</li>
			 
         
			 
	

			
		</ul>

	   <p>
		   <span class="instruction">Instruction:</span>
		Left click on the map to create markers, when last marker meets first marker, it will form a polygon.
		Right click on the polygon to change its color.
		</p>
	</div>
	<div id="main-map">
	</div>
	<div id="side"> 
            <asp:Button ID="btnAddCord" runat="server" Text="Set Coordinates" 
                onclick="btnAddCord_Click" />
            &nbsp;</div>
</asp:Content>

