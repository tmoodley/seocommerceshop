<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditPage.Master" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="seoWebApplication.admin.catalog.department" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
<table>  
<tr>
<td><asp:TextBox ID="txtwebstore_id" runat = "server" ReadOnly="True" 
        Visible="False"></asp:TextBox>
<label for="Descri Visible="False" ption">Description:</label>
</td>
<td>
<asp:TextBox ID="txtDescription" runat = "server" Width="286px"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="Name">Name:</label>
</td>
<td>
<asp:TextBox ID="txtName" runat = "server" Width="195px"></asp:TextBox></td>
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
