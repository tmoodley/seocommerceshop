<%@ Page Language="C#" MasterPageFile="~/adminMstr.Master" AutoEventWireup="true" CodeBehind="AdminProductDetails.aspx.cs" Inherits="seoWebApplication.AdminProductDetails" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"> 
   <title>SeoWebApp Admin: Categories</title>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<span class="AdminTitle">
Admin
<br />
Back to
<asp:HyperLink ID="catLink" runat="server" />
</span>
<asp:Label CssClass="AdminTitle" ID="productNameLabel" runat="server" />
<p>
<asp:Label ID="statusLabel" CssClass="AdminError" runat="server" />
</p>
<p>
Product belongs to these categories:
<asp:Label ID="categoriesLabel" runat="server" />
</p>
<p>
Remove product from this category:
<asp:DropDownList ID="categoriesListRemove" runat="server" />
<asp:Button ID="removeButton" runat="server" Text="Remove" OnClick="removeButton_Click" />
<asp:Button ID="deleteButton" runat="server" Text="DELETE FROM CATALOG" OnClick="deleteButton_Click" />
</p>
<p>
Assign product to this category:
<asp:DropDownList ID="categoriesListAssign" runat="server" />
<asp:Button ID="assignButton" runat="server" Text="Assign" OnClick="assignButton_Click" />
<p>
Move product to this category:
<asp:DropDownList ID="categoriesListMove" runat="server" />
<asp:Button ID="moveButton" runat="server" Text="Move" OnClick="moveButton_Click" />
</p>
<p>
Image1 file name:
<asp:Label ID="Image1Label" runat="server" />
<asp:FileUpload ID="image1FileUpload" runat="server" />
<asp:Button ID="upload1Button" runat="server" Text="Upload" 
        onclick="upload1Button_Click" /><br />
<asp:Image ID="image1" runat="server" />
</p>
<p>
Image2 file name:
<asp:Label ID="Image2Label" runat="server" />
<asp:FileUpload ID="image2FileUpload" runat="server" />
<asp:Button ID="upload2Button" runat="server" Text="Upload" 
        onclick="upload2Button_Click" /><br />
<asp:Image ID="image2" runat="server" />
</p>
</asp:Content>
