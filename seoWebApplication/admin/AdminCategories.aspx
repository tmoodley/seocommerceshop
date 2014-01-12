<%@ Page Language="C#" MasterPageFile="~/adminMstr.Master" AutoEventWireup="true" CodeBehind="AdminCategories.aspx.cs" Inherits="seoWebApplication.AdminCategories" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <title>SeoWebApp Admin: Categories</title> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
<asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
<span class="AdminTitle">
Admin
<br />
Categories in
<asp:HyperLink ID="deptLink" runat="server" />
</span>
</p>
<asp:GridView ID="grid" runat="server" DataKeyNames="category_id" 
        AutoGenerateColumns="False" Width="100%" 
        onrowcancelingedit="grid_RowCancelingEdit" onrowdeleting="grid_RowDeleting" 
        onrowediting="grid_RowEditing" onrowupdating="grid_RowUpdating">
    <Columns>
        <asp:BoundField DataField="name" HeaderText="Category Name" 
            SortExpression="name" />
        <asp:TemplateField HeaderText="Category Description" 
            SortExpression="description">
            <EditItemTemplate>
                <asp:TextBox ID="descriptionTextBox" runat="server" Height="70px" 
                    Text='<%# Bind("description") %>' TextMode="MultiLine" Width="400px"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("description") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
        <asp:HyperLink runat="server" ID="link" NavigateUrl='<%# "AdminProducts.aspx?department_id=" + Request.QueryString["department_id"] + "&amp;category_id=" + Eval("category_id")%>' Text="View Products">
        </asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" />
        <asp:ButtonField CommandName="Delete" Text="Delete" />
    </Columns>
</asp:GridView>
<p>Create a new category:</p>
<p>Name:</p>
<asp:TextBox ID="newName" runat="server" Width="400px" />
<p>Description:</p>
<asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
<p><asp:Button ID="createCategory" Text="Create Category" runat="server" 
        onclick="createCategory_Click" /></p>
</asp:Content>
