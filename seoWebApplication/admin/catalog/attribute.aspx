<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditPage.Master" AutoEventWireup="true" CodeBehind="attribute.aspx.cs" Inherits="seoWebApplication.admin.attribute" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditPage.master"%>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
 <div id="wrapper">
    <asp:Menu
        id="menuTabs"
        CssClass="menuTabs"
        StaticMenuItemStyle-CssClass="tab"
        StaticSelectedStyle-CssClass="selectedTab"
        Orientation="Horizontal"
        OnMenuItemClick="menuTabs_MenuItemClick"
        Runat="server">
        <Items>
        <asp:MenuItem
            Text="Attribute"
            Value="0" 
              />
              <asp:MenuItem
            Text="Attribute Value"
            Value="1" 
              />
                
        </Items>
    </asp:Menu>    
    </div>
    
    
     <div class="wrapper">
    <asp:MultiView
        id="multiTabs"
        ActiveViewIndex="0"
        Runat="server">
        <asp:View ID="view1" runat="server">
        
        
 
<div class="group">
 <div id="wrapper">
    <table>
<tr>
<td>
<label for="AttributeID">Attribute ID:</label>
</td>
<td>
<asp:TextBox ID="txtAttributeID" runat = "server" ReadOnly="True" Enabled="False"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="Name">Name:</label>
</td>
<td>
<asp:TextBox ID="txtName" runat = "server"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="controlType_id">Control Type:</label>
</td>
<td>
    <asp:DropDownList ID="ddlControl" runat="server">
    </asp:DropDownList> 
</td>
</tr>
<tr>
<td> 
</td>
<td>
<asp:TextBox ID="txtwebstore_id" runat = "server" Enabled="False" ReadOnly="True" 
        Visible="False"></asp:TextBox></td>
</tr>

<tr>
<td>
<label for="applyToAllProducts">Apply To All Products:</label>
</td>
<td>
<asp:CheckBox ID="chkapplyToAllProducts" runat = "server"></asp:CheckBox></td>
</tr>

<tr>
<td>
<label for="applyToCategory">Apply To Category:</label>
</td>
<td>
<asp:CheckBox ID="chkapplyToCategory" runat = "server"></asp:CheckBox></td>
</tr>

<tr>
<td>
    <label for="InsertENTUserAccountId">User Account id:</label>
</td>
<td>
<asp:TextBox ID="txtInsertENTUserAccountId" runat = "server" Enabled="False" 
        ReadOnly="True"></asp:TextBox></td>
</tr>
 
</table>
    
    </div> 
    </div>
     </asp:View>

      <asp:View ID="view2" runat="server">
          <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" /> 
          <asp:GridView ID="cgvAttributeValues" runat="server"  BorderColor="#CCCCCC" 
        onrowdatabound="cgvAttributeValues_RowDataBound" CssClass="wrapper">
    <AlternatingRowStyle BackColor="#CCCCCC" />
</asp:GridView>

         </asp:View>
    </asp:MultiView> 
    </div>
    
</asp:Content>
