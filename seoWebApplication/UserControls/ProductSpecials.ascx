<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSpecials.ascx.cs" Inherits="seoWebApplication.UserControls.ProductSpecials" %>
<div class="row-fluid">
	<div class="span12">
		<ul class="thumbnails product-list-inline-small">	 
<asp:repeater ID="list" runat="server">
<ItemTemplate>
	<li class="span4">
    <div class="thumbnail">
    <a href="<%# seoWebApplication.Linkor.ToProduct(Eval("product_id").ToString()) %>">
        <img width="100" border="0"
src="<%# seoWebApplication.Linkor.ToProductImage(Eval("thumbnail").ToString()) %>"
alt='<%# HttpUtility.HtmlEncode(Eval("name").ToString())%>' />

    </a>
    <div class="caption">
	    <a href="<%# seoWebApplication.Linkor.ToProduct(Eval("product_id").ToString()) %>"><%# HttpUtility.HtmlEncode(Eval("name").ToString())%></a>
	    <p><span class="label label-important price pull-right">USD$ <%# Eval("price", "{0:c}") %></span></p>
    </div>
    </div>
    </li> 
</ItemTemplate>
</asp:repeater>
        </ul>
	</div>
</div>
