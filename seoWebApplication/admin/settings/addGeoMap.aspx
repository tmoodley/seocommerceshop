<%@ Page Title="" Language="C#" MasterPageFile="~/adminMstr.Master" AutoEventWireup="true" CodeBehind="addGeoMap.aspx.cs" Inherits="seoWebApplication.admin.settings.addGeoMap" %>
<%@ MasterType virtualPath="~/adminMstr.master"%>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/jscript/style.css">
	
	
	<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
		<script type="text/javascript" src="/jscript/jquery-1.4.2.min.js"></script>
	<script type="text/javascript" src="/jscript/polygon.min.js"></script>
	
	<script type="text/javascript">
	    $(function () {
	        //create map
	        var singapoerCenter = new google.maps.LatLng(29.611534, -98.459268);
	        var myOptions = {
	            zoom: 15,
	            center: singapoerCenter,
	            mapTypeId: google.maps.MapTypeId.ROADMAP
	        }
	        map = new google.maps.Map(document.getElementById('main-map'), myOptions);

	        var creator = new PolygonCreator(map);

	        //reset
	        $('#reset').click(function () {
	            creator.destroy();
	            creator = null;

	            creator = new PolygonCreator(map);
	            $('#ctl00_ContentPlaceHolder1_txtlocations').empty();
	        });


	        //show paths
	        $('#showData').click(function () {
	            $('#ctl00_ContentPlaceHolder1_txtlocations').empty();
	            if (null == creator.showData()) {
	                $('#ctl00_ContentPlaceHolder1_txtlocations').append('Please first create a polygon');

	            } else {
	                $('#ctl00_ContentPlaceHolder1_txtlocations').append(creator.showData());

	            }
	        });

	        //show color
	        $('#showColor').click(function () {
	            $('#txtlocations').empty();
	            if (null == creator.showData()) {
	                $('#ctl00_ContentPlaceHolder1_txtlocations').append('Please first create a polygon');
	            } else {
	                $('#ctl00_ContentPlaceHolder1_txtlocations').append(creator.showColor());
	            }
	        });
	    });	
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header">
		<ul>
			<li class="title">
				Choose your delivery zone 
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
		<input id="reset" value="Reset" type="button" class="navi"/>
		<input id="showData"  value="Show Paths (class function) " type="button" class="navi"/>
		<input id="showColor"  value="Show Color (class function) " type="button" class="navi"/>
        <asp:TextBox ID="txtlocations" runat="server" Height="114px" Width="217px" 
                TextMode="MultiLine"></asp:TextBox>

            <asp:Button ID="btnAddCord" runat="server" Text="Add Coordinates" 
            onclick="btnAddCord_Click" />
            &nbsp;</div>
</asp:Content>
