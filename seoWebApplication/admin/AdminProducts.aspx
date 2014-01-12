<%@ Page Language="C#" MasterPageFile="~/adminMstr.Master" AutoEventWireup="true" CodeBehind="AdminProducts.aspx.cs" Inherits="seoWebApplication.AdminProducts" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>SeoWebApp Admin: Products in</title> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
<asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
</p>
 <span class="AdminTitle">
Admin
<br />
Back to
<asp:HyperLink ID="catLink" runat="server" />
</span>
<asp:GridView ID="grid" runat="server" DataKeyNames="product_id" 
        AutoGenerateColumns="False" Width="100%" 
        onrowcancelingedit="grid_RowCancelingEdit" onrowediting="grid_RowEditing" 
        onrowupdating="grid_RowUpdating">
    <Columns>
        <asp:ImageField DataImageUrlField="Thumbnail" 
            DataImageUrlFormatString="ProductImages/{0}" HeaderText="Product Image" 
            ReadOnly="True">
        </asp:ImageField>
        <asp:TemplateField HeaderText="Product Name" SortExpression="Name">
            <EditItemTemplate>
                <asp:TextBox ID="nameTextBox" runat="server" CssClass="GridEditingRow" 
                    Text='<%# Bind("Name") %>' Width="97%"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Product Description" 
            SortExpression="Description">
            <EditItemTemplate>
               <asp:TextBox ID="descriptionTextBox" runat="server"
Text='<%# Bind("Description") %>' Height="100px" Width="97%"
CssClass="GridEditingRow" TextMode="MultiLine" />
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Price" SortExpression="Price">
            <EditItemTemplate>
               <asp:TextBox ID="priceTextBox" runat="server" Width="45px" Text='<%# String.Format("{0:0.00}", Eval("Price")) %>'>
                </asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# String.Format("{0:0.00}", Eval("Price")) %>'>
                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Thumb File" SortExpression="thumbnail">
            <EditItemTemplate>
                <asp:TextBox ID="thumbTextBox" runat="server" Text='<%# Bind("thumbnail") %>' 
                    Width="80px"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("thumbnail") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Image File" SortExpression="image">
            <EditItemTemplate>
                <asp:TextBox ID="imageTextBox" runat="server" Text='<%# Bind("image") %>' 
                    Width="80px"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("image") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CheckBoxField DataField="promodept" HeaderText="Dept. prom." 
            SortExpression="promodept" />
        <asp:CheckBoxField DataField="promofront" HeaderText="Cat. prom." 
            SortExpression="promofront" />
        <asp:TemplateField>
        <ItemTemplate>
<asp:HyperLink
Runat="server" Text="Select"
NavigateUrl='<%# "AdminProductDetails.aspx?department_id=" +
Request.QueryString["department_id"] + "&amp;category_id=" +
Request.QueryString["category_id"] + "&amp;product_id=" +
Eval("product_id") %>'
ID="HyperLink1">
</asp:HyperLink>
</ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" />
    </Columns>
</asp:GridView>

<p>Create a new product and assign it to this category:</p>
<p>
<span class="WideLabel">Name:</span>
<asp:TextBox ID="newName" runat="server" Width="400px" />
</p>
<p>
<span class="WideLabel">Description:</span>
<asp:TextBox ID="newDescription" runat="server" Width="400px"
Height="70px" TextMode="MultiLine" />
</p>
<p>
<span class="WideLabel">Price:</span>
<asp:TextBox ID="newPrice" runat="server" Width="400px">0.00</asp:TextBox>
</p>
<p>
<span class="WideLabel">Thumbnail file:</span>
<asp:TextBox ID="newThumbnail" runat="server" Width="400px">Generic1.png</asp:TextBox>
</p>
<p>
<span class="WideLabel">Image file:</span>
<asp:TextBox ID="newImage" runat="server" Width="400px">Generic2.png</asp:TextBox>
</p>
<p>
<span class="widelabel">Dept. promo:</span>
<asp:CheckBox ID="newPromoDept" runat="server" />
</p>
<p>
<span class="widelabel">Front promo:</span>
<asp:CheckBox ID="newPromoFront" runat="server" />
</p>
<asp:Button ID="createProduct" runat="server" Text="Create Product" 
        onclick="createProduct_Click" />
</asp:Content>