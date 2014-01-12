<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="AdminOrderDetails.aspx.cs" Inherits="seoWebApplication.AdminOrderDetails" EnableViewState="false"%>

 <asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
<span class="AdminTitle">shade 4 sale Admin
<br />
Order Details </span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
<asp:Label ID="orderIdLabel" runat="server" Text="Order #000" CssClass="AdminTitle"></asp:Label>  
<br />   
<span class="WideLabel">Total Amount:</span>
<asp:Label ID="totalAmountLabel" runat="server" CssClass="ProductPrice" />
<br />
<span class="WideLabel">Date Created:</span> 
<asp:TextBox ID="dateCreatedTextBox" runat="server" Width="400px"></asp:TextBox>
<br />
<span class="WideLabel">Date Shipped:</span>
<asp:TextBox ID="dateShippedTextBox" runat="server" Width="400px"></asp:TextBox>
<br />
<span class="WideLabel">Status:</span>
Verified
<asp:CheckBox ID="verifiedCheck" runat="server" />
Completed
<asp:CheckBox ID="completedCheck" runat="server" />
Canceled
<asp:CheckBox ID="canceledCheck" runat="server" />
<br />
<span class="WideLabel">Comments:</span>
<asp:TextBox ID="commentsTextBox" runat="server" Width="400px"></asp:TextBox>
<br />
<span class="WideLabel">Customer Name:</span>
<asp:TextBox ID="customerNameTextBox" runat="server" Width="400px"></asp:TextBox>
<br />
<span class="WideLabel">Address:</span>
<asp:TextBox ID="shippingAddressTextBox" runat="server" Width="400px"></asp:TextBox>
<br />
<span class="WideLabel">Customer Email:</span>c
<asp:TextBox ID="customerEmailTextBox" runat="server" Width="400px"></asp:TextBox>
<br />
<asp:Button ID="editButton" runat="server" Text="Edit" Width="100px" 
        onclick="editButton_Click"/>
<asp:Button ID="updateButton" runat="server" Text="Update" Width="100px" 
        onclick="updateButton_Click"/>
<asp:Button ID="cancelButton" runat="server" Text="Cancel" Width="100px" 
        onclick="cancelButton_Click"/>
<br />
<asp:Button ID="markVerifiedButton" runat="server" Text="Mark Order as Verified" 
        Width="305px" onclick="markVerifiedButton_Click"/>
<br />
<asp:Button ID="markCompletedButton" runat="server" Text="Mark Order as Completed" 
        Width="305px" onclick="markCompletedButton_Click"/>
<br />
<asp:Button ID="markCanceledButton" runat="server" Text="Mark Order as Canceled" 
        Width="305px" onclick="markCanceledButton_Click"/>
<br />
<asp:Label ID="Label1" runat="server" Text="The order contains these items:"></asp:Label>
<br />
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:BoundField DataField="product_id" HeaderText="Product_ID" ReadOnly="True" 
            SortExpression="product_id" />
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" 
            ReadOnly="True" SortExpression="ProductName" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" 
            SortExpression="Quantity" />
        <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" ReadOnly="True" 
            SortExpression="UnitCost" />
        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ReadOnly="True" 
            SortExpression="Subtotal" />
    </Columns>
    
</asp:GridView>
<br />
</asp:Content>