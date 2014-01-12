<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditPage.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="seoWebApplication.admin.settings.admin" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
<table>
<tr>
<td>
<label for="UserAccountId">UserAccountId:</label>
</td>
<td>
<asp:TextBox ID="txtUserAccountId" runat = "server"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="IsActive">IsActive:</label>
</td>
<td>
<asp:CheckBox ID="chkIsActive" runat = "server"></asp:CheckBox></td>
<td>
<label for="AccountName">AccountName:</label>
</td>
<td>
<asp:TextBox ID="txtAccountName" runat = "server"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="FirstName">FirstName:</label>
</td>
<td>
<asp:TextBox ID="txtFirstName" runat = "server"></asp:TextBox></td>
<td>
<label for="LastName">LastName:</label>
</td>
<td>
<asp:TextBox ID="txtLastName" runat = "server"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="Email">Email:</label>
</td>
<td>
<asp:TextBox ID="txtEmail" runat = "server"></asp:TextBox></td>
<td>
<label for="Password">Password:</label>
</td>
<td>
<asp:TextBox ID="txtPassword" runat = "server"></asp:TextBox></td>
</tr>
<tr> 
<td>
<asp:TextBox ID="txtwebstore_id" runat = "server" Visible="False"></asp:TextBox></td>
</tr>
<tr> 
<td>
<asp:TextBox ID="txtInsertENTUserAccountId" runat = "server" Visible="False"></asp:TextBox></td>
</tr> 
</table>
</asp:Content>
