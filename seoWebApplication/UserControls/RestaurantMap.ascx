<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestaurantMap.ascx.cs" Inherits="seoWebApplication.UserControls.RestaurantMap" %>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
   <asp:Literal ID="mapLiteral" runat="server"></asp:Literal>
	<asp:Literal ID="mapGeoLocation" runat="server"></asp:Literal>  
<iframe width="496" height="500" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://maps.google.com/maps?q=<%=Address%>,+<%=City%>,+<%=State%>+<%=Zip%>&amp;oe=&amp;ie=UTF8&amp;hq=&amp;hnear=<%=Address%>,+<%=City%>,+<%=State%>+<%=Zip%>&amp;gl=us&amp;z=15&amp;ll=<%=geoLocation%>&amp;output=embed"></iframe>
 
 