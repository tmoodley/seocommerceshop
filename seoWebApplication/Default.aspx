<%@ Page Language="C#" MasterPageFile="~/default2.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="seoWebApplication._Default" Title="Shoppers Paradise Zim" %>
 
<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>
<%@ Register src="UserControls/Pager.ascx" tagname="Pager" tagprefix="uc2" %>  
<%@ Register src="UserControls/AccordianRestaurantHours.ascx" tagname="AccordianRestaurantHours" tagprefix="uc4" %>
<%@ Register src="UserControls/RestaurantMap.ascx" tagname="RestaurantMap" tagprefix="uc3" %>
<%@ Register Src="~/UserControls/RestaurantReviews.ascx" TagPrefix="uc1" TagName="RestaurantReviews" %>
<%@ Register Src="~/UserControls/RestaurantReviewStars.ascx" TagPrefix="uc1" TagName="RestaurantReviewStars" %>
<%@ Register Src="~/UserControls/ProductsList.ascx" TagPrefix="uc2" TagName="ProductsList" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"> 
<meta property="og:title" content="<%=seoTitle + " at " + storeName%>"/>
<meta property="og:image" content="<%= "" + host + imgLogo%>"/>
<meta property="og:site_name" content="<%= "" + storeName %>"/>
<meta property="og:url" content="<%= "" + url %>" />
<meta property="og:description" content="<%= "" + seoDesc %>"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSoMed" runat="Server"> 
<div class="fb-like" data-href="<%= "" + fbUrl %>" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="paperShadow"> 
<asp:Label ID="catalogTitleLabel" CssClass="CatalogTitle" runat="server" />
</div>

<asp:Label ID="catalogDescriptionLabel" CssClass="CatalogDescription" runat="server" /> 
<div class='row-fluid'><div class='span12'><ul class='thumbnails product-list-inline-large'>
    <asp:Repeater ID="list" runat="server">   
     <itemtemplate>   
         <asp:Literal ID="lblDivStart" runat="server"></asp:Literal>
     <li class="span3">
		<div class="thumbnail dark"> 
				<span class="label label-info price"><%# Eval("price", "{0:c}") %></span> 
					<a href="<%# seoWebApplication.Linkor.ToProduct(Eval("product_id").ToString()) %>">
                    <img width="225" border="0"
                    src="<%# seoWebApplication.Linkor.ToProductImage(Eval("thumbnail").ToString()) %>"
                    alt='<%# HttpUtility.HtmlEncode(Eval("name").ToString())%>' class="product-image" />
                    </a>
			 
			<div class="caption">
				<a href="<%# seoWebApplication.Linkor.ToProduct(Eval("product_id").ToString()) %>">
                <%# HttpUtility.HtmlEncode(Eval("name").ToString()) %>
                </a>
                <div class="description-block">
                <%# HttpUtility.HtmlEncode(Eval("description").ToString()) %>         
                </div> 
			</div>
                <a href='<%# seoWebApplication.Linkor.ToProduct(Eval("product_id").ToString()) %>' class="btn btn-block">Details</a>
		</div>
	</li>  
         <asp:Literal ID="lblDivEnd" runat="server"></asp:Literal>
    </itemtemplate>
        
    </asp:Repeater> 
 </ul></div></div>   
</asp:Content>