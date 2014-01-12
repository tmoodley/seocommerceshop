<%@ Page Language="C#" MasterPageFile="~/adminMstr.Master" AutoEventWireup="true" CodeBehind="AdminDepartments.aspx.cs" Inherits="seoWebApplication.AdminDepartments" %>

 <asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
        <title>SeoWebApp Admin: Products</title> 
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
    <asp:GridView ID="grid" runat="server" DataKeyNames="department_id" 
        AutoGenerateColumns="False" CssClass="Grid" BackColor="White" 
    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
    ForeColor="Black" GridLines="Vertical" onrowdeleted="grid_RowDeleted" 
    onrowdeleting="grid_RowDeleting" onrowediting="grid_RowEditing" 
    onrowupdating="grid_RowUpdating" Width="769px" 
    onrowcancelingedit="grid_RowCancelingEdit">
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Department Name" 
                SortExpression="name" />
            <asp:TemplateField HeaderText="Department Description" 
                SortExpression="description">
                <EditItemTemplate>
                    <asp:TextBox ID="descriptionTextBox" runat="server" 
                        Text='<%# Bind("description") %>' Height="70px" TextMode="MultiLine" 
                        Width="400px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="department_id" 
                DataNavigateUrlFormatString="AdminCategories.aspx?department_id={0}" 
                HeaderText="View Categories" Text="View Categories" />
            <asp:CommandField ShowEditButton="True" />
            <asp:ButtonField CommandName="Delete" Text="Delete" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <p>Create a new department:</p>
<p>Name:</p>
<asp:TextBox ID="newName" runat="server" Width="400px" />
<p>Description:</p>
<asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
<p><asp:Button ID="createDepartment" Text="Create Department" runat="server" 
        onclick="createDepartment_Click" /></p>
</asp:Content>