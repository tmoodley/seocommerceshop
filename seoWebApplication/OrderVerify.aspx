<%@ Page Language="C#" MasterPageFile="~/default2.Master"  AutoEventWireup="true" CodeBehind="OrderVerify.aspx.cs" Inherits="seoWebApplication.OrderVerify" %>

  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2"
ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="panel-innards">
<p>
<asp:Label ID="titleLabel" runat="server" CssClass="CatalogTitle" Text="Confirm Your Order" />
</p>
<p>
<asp:Label ID="statusLabel" runat="server" ForeColor="White" />
</p>
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="product_id" Width="100%" CellPadding="4" ForeColor="#333333" 
        GridLines="None"  >
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
    <asp:Literal ID="lblOrderPointsMsg" runat="server"></asp:Literal>
<br />
    <asp:Label ID="lblPointName" runat="server"></asp:Label>
    <asp:Label ID="lblPoints" runat="server"></asp:Label>
    <br /> 
<br />
<asp:Label ID="InfoLabel" runat="server" />
<br />
<asp:Label ID="Label1" runat="server" />
<br />
    Points To Apply to order:<asp:TextBox ID="txtPoints" runat="server" Width="61px">0</asp:TextBox>    <br />
    <asp:Button ID="Button1" runat="server" Text="Apply To Order" OnClick="Button1_Click" />
    <br />
    Applied Points: <asp:Label ID="lblPointsApplied" runat="server"></asp:Label>
    <br />
    Total Amount Due:
    <asp:Label ID="lblNewTotal" runat="server"></asp:Label>
    <br />
Shipping type:
<asp:DropDownList ID="ddlShippingDetails" runat="server" >
    <asp:ListItem Value="0">Pick Up</asp:ListItem>
    <asp:ListItem Value="5">$5 Delivery</asp:ListItem>
    </asp:DropDownList>
<br /><br />
<asp:Button ID="placeOrderButton" runat="server"
Text="Check Out" OnClick="placeOrderButton_Click" />
</p>

 
 
</div>
<div>
 

</div>
</asp:Content>

