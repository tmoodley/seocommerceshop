 <%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeBehind="OrderTest.aspx.cs" Inherits="seoWebApplication.OrderTest" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
<span class="AdminTitle">SeoWebApp Customer Order Access Test</span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" Runat="Server">
Order number:
<asp:TextBox runat="server" ID="orderIDBox" />
<br />
<asp:Button runat="server" ID="goButton" Text="Go" onclick="goButton_Click" />
<br /><br />
<asp:Label runat="server" ID="resultLabel" />
<br /><br />
<strong>Custo<asp:Label runat="server" ID="addressLabel" />
    mer address:</strong>
<br />
<br /><br />
<strong>Customer credit card:</strong>
<br />
<asp:Label runat="server" ID="creditCardLabel" />
<br /><br />
<strong>Order details:</strong>
<br />
<asp:Label runat="server" ID="orderLabel" />
</asp:Content>
