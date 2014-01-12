<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="seoWebApplication.AdminOrders" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
     <span class="AdminTitle">
     Shade4sale Admin
<br />
     Orders
</span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat=
"Server">
    Show the most recent
<asp:TextBox ID="recentCountTextBox" runat="server" MaxLength="4" Width="40px" Text="20" />
    records
<asp:Button ID="byRecentGo" runat="server" Text="Go" CausesValidation="False" 
    onclick="byRecentGo_Click" /><br />
    Show all records created between
<asp:TextBox ID="startDateTextBox" runat="server" Width="72px" />
    and
<asp:TextBox ID="endDateTextBox" runat="server" Width="72px" />
<asp:Button ID="byDateGo" runat="server" Text="Go" onclick="byDateGo_Click" />
<br />
    Show all unverified, uncanceled orders
<asp:Button ID="unverfiedGo" runat="server" Text="Go" CausesValidation="False" 
    onclick="unverfiedGo_Click" />
<br />
    Show all verified, uncompleted orders
<asp:Button ID="uncompletedGo" runat="server" Text="Go" 
    CausesValidation="False" onclick="uncompletedGo_Click" />
<br />
    <asp:Label ID="errorLabel" runat="server" Text="Label"></asp:Label>
    <asp:RangeValidator ID="startDateValidator" runat="server" 
    ErrorMessage="Invalid start date" ControlToValidate="startDateTextBox" 
    Display="None" MaximumValue="1/1/2015" MinimumValue="1/1/1999" Type="Date"></asp:RangeValidator>
    <asp:RangeValidator ID="endDateValidator" runat="server" 
    ControlToValidate="endDateTextBox" Display="None" 
    ErrorMessage="Invalid end date" MaximumValue="1/1/2015" MinimumValue="1/1/1999" 
    Type="Date"></asp:RangeValidator>
    <br />
<asp:CompareValidator ID="compareDatesValidator" runat="server" 
    ControlToCompare="endDateTextBox" ControlToValidate="startDateTextBox" 
    Display="None" ErrorMessage="Start date should be more recent" 
    Operator="LessThan" Type="Date"></asp:CompareValidator>
<asp:ValidationSummary ID="validationSummary" runat="server" 
    CssClass="AdminError" HeaderText="Data validation errors:" />
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="OrderID" onselectedindexchanged="grid_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="OrderID" HeaderText="Order ID" ReadOnly="True" 
            SortExpression="OrderID" />
        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" 
            ReadOnly="True" SortExpression="DateCreated" />
        <asp:BoundField DataField="DateShipped" HeaderText="Date Shipped" 
            ReadOnly="True" SortExpression="DateShipped" />
        <asp:CheckBoxField DataField="Verified" HeaderText="Verified" ReadOnly="True" 
            SortExpression="Verified" />
        <asp:CheckBoxField DataField="Completed" HeaderText="Completed" ReadOnly="True" 
            SortExpression="Completed" />
        <asp:CheckBoxField DataField="Canceled" HeaderText="Canceled" ReadOnly="True" 
            SortExpression="Canceled" />
        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" 
            ReadOnly="True" SortExpression="CustomerName" />
        <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Select" 
            ShowHeader="True" Text="Select" />
    </Columns>
</asp:GridView>
<br />
</asp:Content>