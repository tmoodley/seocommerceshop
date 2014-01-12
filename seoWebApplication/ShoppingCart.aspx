<%@ Page Language="C#" MasterPageFile="~/default2.Master"  AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="seoWebApplication.ShoppingCart" %>

<%@ Register src="UserControls/ProductRecommendations.ascx" tagname="ProductRecommendations" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2"
ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="panel-innards">
<p>
<asp:Label ID="titleLabel" runat="server" Text="Your Shopping Cart" CssClass="CatalogTitle" />
</p>
<p>
<asp:Label ID="statusLabel" runat="server" ForeColor="White" />
</p>
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="product_id" Width="100%" CellPadding="4" ForeColor="#333333" 
        GridLines="None" onrowdeleting="grid_RowDeleting">
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
        <asp:BoundField DataField="name" HeaderText="Product Name" ReadOnly="True" 
            SortExpression="name" />
        <asp:BoundField DataField="price" DataFormatString="{0:c}" HeaderText="Price" 
            ReadOnly="True" SortExpression="price" />
        <asp:BoundField DataField="attributes" HeaderText="Attributes" ReadOnly="True" 
            SortExpression="attributes" />
        <asp:TemplateField HeaderText="Quantity">
         
<ItemTemplate>
<asp:TextBox ID="editQuantity" runat="server" CssClass="GridEditingRow"
Width="24px" MaxLength="2" Text='<%#Eval("quantity")%>' />
</ItemTemplate>
 
        </asp:TemplateField>
        <asp:BoundField DataField="subtotal" DataFormatString="{0:c}" 
            HeaderText="Subtotal" ReadOnly="True" SortExpression="subtotal" />
        <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
    </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<p align="right" class="shoppingcart">
<span>Total amount: </span>
<asp:Label ID="totalAmountLabel" runat="server" Text="Label" />
</p>
<p align="right" class="shoppingcart">
<asp:Button ID="updateButton" runat="server" Text="Update Quantities" 
        onclick="updateButton_Click" />
        <asp:Button ID="checkoutButton" runat="server"
Text="Proceed to Checkout" onclick="checkoutButton_Click" />
</p>
</div>
<div>

    <uc1:ProductRecommendations ID="ProductRecommendations1" runat="server" />

</div>
</asp:Content>

