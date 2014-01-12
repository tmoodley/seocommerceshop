<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditPage.Master" AutoEventWireup="true" CodeBehind="productAttributeValue.aspx.cs" Inherits="seoWebApplication.admin.productAttributeValue" %>

 
 
 
<%@ MasterType virtualPath="~/seoWebAppAdminEditPage.master"%>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
 <table>
<tr>
<td>
    &nbsp;</td>
<td>
<asp:TextBox ID="txtProductAttributeValueId" runat = "server" ReadOnly="True" 
        Visible="False"></asp:TextBox></td>
 
<td>
&nbsp;</td>
<td>
<asp:TextBox ID="txtproduct_id" runat = "server" ReadOnly="True" Visible="False"></asp:TextBox></td>
 
<td>
&nbsp;</td>
<td>
<asp:TextBox ID="txtwebstore_id" runat = "server" ReadOnly="True" Visible="False"></asp:TextBox></td>
</tr>

<tr>
<td>
<label for="AttributeValueID">AttributeValueID:</label>
</td>
<td> 
    <asp:DropDownList ID="ddlAtt" runat="server" AutoPostBack="True" 
        AppendDataBoundItems="True">
    </asp:DropDownList>

    <asp:DropDownList ID="ddlAttributes" runat="server">
    </asp:DropDownList>

</td>
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
    <label for="InsertENTUserAccountId">User Account Id:</label>
</td>
<td>
<asp:TextBox ID="txtInsertENTUserAccountId" runat = "server" ReadOnly="True"></asp:TextBox></td>
</tr>
 
</table>
    
</asp:Content>
