<%@ Page Language="C#" MasterPageFile="~/default2.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="seoWebApplication.Search" %>
<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>
<%@ Register src="UserControls/Pager.ascx" tagname="Pager" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"
runat="server">
<div class="panel-body">
<div class="panel-innards">
<div class="panel-header">
<div class="standardPageTitle">
<asp:Label ID="catalogTitleLabel" CssClass="CatalogTitle"
runat="server" />
</div>
<div class="standardPageDesc">
<asp:Label ID="catalogDescriptionLabel" CssClass="CatalogDescription"
runat="server" />
</div>
<div class="standardPageDesc">
<uc2:Pager ID="Pager1" runat="server" />
</div>
</div>
    <asp:DataList ID="list" runat="server" RepeatColumns="4"
CssClass="ProductList" onitemdatabound="list_ItemDataBound" >
<ItemTemplate>
<div class="brief-wrap">
<div class="brief-name">
<h3>
<a href="<%# Link.ToProduct(Eval("product_id").ToString()) %>">
<%# HttpUtility.HtmlEncode(Eval("name").ToString()) %>
</a>
</h3>
</div>
 
<div class="brief-image">
<a href="<%# Link.ToProduct(Eval("product_id").ToString()) %>">
<img width="100" border="0"
src="<%# Link.ToProductImage(Eval("thumbnail").ToString()) %>"
alt='<%# HttpUtility.HtmlEncode(Eval("name").ToString())%>' />
</a>
<p>
<div class="brief-sellprice"> 
    Price:
<%# Eval("price", "{0:c}") %>
</p>
</div>
    <p>
 <%# HttpUtility.HtmlEncode(Eval("description").ToString()) %></p>
 
 
</div>
 
<div class="attributeBox">
<asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
</div> 
</div>
</ItemTemplate>
</asp:DataList>
 <div class="standardPageDesc">
 <uc2:Pager ID="Pager2" runat="server" />
 </div>
 </div>
  </div>
</asp:Content>