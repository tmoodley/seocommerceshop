<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsList.ascx.cs" Inherits="seoWebApplication.UserControls.ProductsList" %>
<%@ Register src="Pager.ascx" tagname="Pager" tagprefix="uc1" %>
<uc1:Pager ID="topPager" runat="server" Visible="False" />
<asp:DataList ID="list" runat="server" RepeatColumns="2"
CssClass="ProductList">
<ItemTemplate>
<h3 class="ProductTitle">
<a href="<%# Link.ToProduct(Eval("product_id").ToString()) %>">
<%# HttpUtility.HtmlEncode(Eval("name").ToString()) %>
</a>
</h3>
<a href="<%# Link.ToProduct(Eval("product_id").ToString()) %>">
<img width="100" border="0"
src="<%# Link.ToProductImage(Eval("thumbnail").ToString()) %>"
alt='<%# HttpUtility.HtmlEncode(Eval("name").ToString())%>' />
</a>
<%# HttpUtility.HtmlEncode(Eval("description").ToString()) %>
<p>
Price:
<%# Eval("price", "{0:c}") %>
</p>
</ItemTemplate>
</asp:DataList>
<uc1:Pager ID="bottomPager" runat="server" Visible="False" />
