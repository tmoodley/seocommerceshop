<%@ Page Language="C#" MasterPageFile="~/default2.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="seoWebApplication._Default" Title="Shoppers Paradise Zim" %>
 
<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>
<%@ Register src="UserControls/Pager.ascx" tagname="Pager" tagprefix="uc2" %>  
<%@ Register src="UserControls/AccordianRestaurantHours.ascx" tagname="AccordianRestaurantHours" tagprefix="uc4" %>
<%@ Register src="UserControls/RestaurantMap.ascx" tagname="RestaurantMap" tagprefix="uc3" %>
<%@ Register Src="~/UserControls/RestaurantReviews.ascx" TagPrefix="uc1" TagName="RestaurantReviews" %>
<%@ Register Src="~/UserControls/RestaurantReviewStars.ascx" TagPrefix="uc1" TagName="RestaurantReviewStars" %>
<%@ Register Src="~/UserControls/ProductsList.ascx" TagPrefix="uc2" TagName="ProductsList" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="paperShadow shadow-bottom">
<h1>Welcome to ShoppersParadiseZim.Com</h1>
<p>ShoppersParadiseZim.Com is grocery supply store based in Harare Zimbabwe, our goal is to provide you with quality products.</p>
<asp:Label ID="catalogTitleLabel" CssClass="CatalogTitle" runat="server" />
</div>
<div class="paperShadow shadow-bottom">
<asp:Label ID="catalogDescriptionLabel" CssClass="CatalogDescription" runat="server" />
<div class="column12">
<div class="row-mix">
     
    <asp:Repeater ID="list" runat="server">  
     <itemtemplate>  
     <div class="span3">
     
     <div class="image_block">
     <a href="<%# Link.ToProduct(Eval("product_id").ToString()) %>">
     <img width="225" border="0"
     src="<%# Link.ToProductImage(Eval("thumbnail").ToString()) %>"
     alt='<%# HttpUtility.HtmlEncode(Eval("name").ToString())%>' class="product-image" />
     </a>
     </div>
     <div class="header_block">
    <h2><a href="<%# Link.ToProduct(Eval("product_id").ToString()) %>">
    <%# HttpUtility.HtmlEncode(Eval("name").ToString()) %>
    </a></h2> 
    </div>

     <div class="price-block">
         <%# Eval("price", "{0:c}") %>
     </div> 

    <div class="description-block">
    <%# HttpUtility.HtmlEncode(Eval("description").ToString()) %>         
    </div> 
    <div class="details-block">
    <a href='<%# Link.ToProduct(Eval("product_id").ToString()) %>' class="button">Details</a>
    </div>

    </div>         
    </itemtemplate>
    </asp:Repeater>
  
</div>
</div>
</div>
 
</asp:Content>