<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo2.ascx.cs" Inherits="seoWebApplication.UserControls.UserInfo2" %>
<table cellspacing="0" border="0" width="200px" >
<asp:LoginView ID="LoginView1" runat="server">
<AnonymousTemplate>
 
 <li>Welcome! You are not logged in.</li> 
 <li><asp:LoginStatus ID="LoginStatus1" runat="server" /></li>
 or
<asp:HyperLink runat="server" ID="registerLink"
NavigateUrl="~/Register.aspx" Text="Register"
ToolTip="Go to the registration page"/>
 
</AnonymousTemplate>
<RoleGroups>
<asp:RoleGroup Roles="Administrators">
<ContentTemplate>
 
<li><asp:LoginName ID="LoginName2" runat="server" FormatString="Hello, <b>{0}</b>!" /></li>
 
<li><asp:LoginStatus ID="LoginStatus2" runat="server" /></li>
  
<li><a href="AdminDepartments.aspx">Catalog Admin</a></li>

<li><a href="AdminShoppingCart.aspx">Cart Admin</a></li>

<li><a href="AdminOrders.aspx">Orders Admin</a></li>
 
</ContentTemplate>
</asp:RoleGroup>
<asp:RoleGroup Roles="Customers">
<ContentTemplate>
<li><asp:LoginName ID="LoginName2" runat="server" FormatString="Hello, <b>{0}</b>!" /></li>
<li><asp:LoginStatus ID="LoginStatus1" runat="server" /></li>
<li><asp:HyperLink runat="server" ID="detailsLink" NavigateUrl="~/CustomerDetails.aspx"
Text="Edit Details"
ToolTip="Edit your personal details" /></li> 
</ContentTemplate>
</asp:RoleGroup>
</RoleGroups>
</asp:LoginView>
</table>