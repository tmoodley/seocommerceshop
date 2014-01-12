<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditPage.Master" AutoEventWireup="true" CodeBehind="attributeValue.aspx.cs" Inherits="seoWebApplication.admin.catalog.attributeValue" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
<table>
<tr>
<td>
    &nbsp;</td>
<td>
<asp:TextBox ID="txtAttributeValueID" runat = "server" ReadOnly="True" 
        Visible="False"></asp:TextBox></td>
</tr>
<tr>
<td>
    &nbsp;</td>
<td>
<asp:TextBox ID="txtAttributeID" runat = "server" ReadOnly="True" Visible="False"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="Value">Value:</label>
</td>
<td>
<asp:TextBox ID="txtValue" runat = "server"></asp:TextBox></td>
</tr>
<tr>
<td>
    &nbsp;</td>
<td>
<asp:TextBox ID="txtwebstore_id" runat = "server" ReadOnly="True" Visible="False"></asp:TextBox></td>
</tr>
<tr>
<td>
    <label for="InsertENTUserAccountId">User Account Id:</label>
</td>
<td>
<asp:TextBox ID="txtInsertENTUserAccountId" runat = "server" ReadOnly="True"></asp:TextBox></td>
</tr> 
</table>
</asp:Content>
