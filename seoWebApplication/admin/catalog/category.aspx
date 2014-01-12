<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditPage.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="seoWebApplication.admin.catalog.category" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
<table> 
<tr>
<td>
<label for="department_id">Department:</label>
</td>
<td>
    <asp:DropDownList ID="ddlDepartments" runat="server">
    </asp:DropDownList> 
</td> 
</tr>
<tr>
<td>
<asp:TextBox ID="txtwebstore_id" runat = "server" Visible="False"></asp:TextBox> 
<label for="name">Name:</label>
</td> 
<td>
<asp:TextBox ID="txtname" runat = "server" Width="268px"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="description">Description:</label>
</td>
<td>
<asp:TextBox ID="txtdescription" runat = "server" Width="264px"></asp:TextBox></td>
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
