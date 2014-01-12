<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditPage.Master" AutoEventWireup="true" CodeBehind="point.aspx.cs" Inherits="seoWebApplication.admin.settings.point" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<div id="adminwrapper">
<table> 
<tr>
<td>
<label for="webstore_id">webstore_id:</label>
</td>
<td>
<asp:TextBox ID="txtwebstore_id" runat = "server"></asp:TextBox></td>
<td>
<label for="Name">Name:</label>
</td>
<td>
<asp:TextBox ID="txtName" runat = "server"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="ConversionRate">ConversionRate:</label>
</td>
<td>
<asp:TextBox ID="txtConversionRate" runat = "server"></asp:TextBox></td>
<td>
<label for="Point">Point:</label>
</td>
<td>
<asp:TextBox ID="txtPoint" runat = "server"></asp:TextBox>
This text is shown next to the number of reward points on pages such as product details pages, order details pages, etc.

</td>
</tr>
<tr>
<td>
<label for="Percentage">Percentage:</label>

</td>
<td>
<asp:TextBox ID="txtPercentage" runat = "server"></asp:TextBox>
Indicates how points translate into dollars. 100% means that each point equals one dollar. 150% means that each point translates into 1.5 dollars. 20% indicates that each point is equal to $0.20. And so on.
</td>
<td>
<label for="Active">Active:</label>
</td>
<td>
<asp:CheckBox ID="chkActive" runat = "server"></asp:CheckBox></td>
</tr> 
</table>
</div>
</asp:Content>

