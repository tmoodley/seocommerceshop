<%@ Page Language="C#" MasterPageFile="~/defaultproduct.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="seoWebApplication.Product" Title="Product Details Page" %>

<%@ Register src="UserControls/ProductRecommendations.ascx" tagname="ProductRecommendations" tagprefix="uc1" %>

<%@ Register src="UserControls/ProductAttributes.ascx" tagname="ProductAttributes" tagprefix="uc2" %>

<%@ Register src="UserControls/ProductAttributesRadio.ascx" tagname="ProductAttributesRadio" tagprefix="uc3" %>

<%@ Register src="UserControls/ProductCustomAttributes.ascx" tagname="ProductCustomAttributes" tagprefix="uc4" %>
<%@ Register Src="~/UserControls/contact.ascx" TagPrefix="uc1" TagName="contact" %>
<%@ Register Src="~/UserControls/Pictures.ascx" TagPrefix="uc1" TagName="Pictures" %>
<%@ Register Src="~/UserControls/PicturesModals.ascx" TagPrefix="uc1" TagName="PicturesModals" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <!-- Open Graph data --> 
<meta property="og:type" content="article" />
<meta property="og:title" content="<%=seoTitle + " at " + storeName%>"/>
<meta property="og:image" content="<%= "" + host + imgLogo%>"/>
<meta property="og:site_name" content="<%= "" + storeName %>"/>
<meta property="og:url" content="<%= "" + url %>" />
<meta property="og:description" content="<%= "" + seoDesc %>"/>
<meta property="og:price:amount" content="<%= "" + price %>" />
<meta property="og:price:currency" content="USD" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSoMed" runat="Server"> 
<div class="fb-like" data-href="<%= "" + fbUrl %>" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
     <div class="row-fluid"> 
        <div class="span2">
        <uc1:Pictures runat="server" id="Pictures" />
        </div> 
        <div class="span2 img-thumbnail" style="width: 550px"><div class="paperShadow shadow-left">
            <asp:Image ID="productImage" runat="server" Height="75%" Width="100%" CssClass="img-thumbnail" /></div> 
       </div> 
        <div class="span4">
            <div class="fb-like" data-href="<%= "" + url %>" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
            <div class="paperShadow shadow-bottom" style="text-align:center;">
            <h1><asp:Label CssClass="ProductTitle" ID="titleLabel" runat="server" Text="Label"></asp:Label></h1>
            </div>
            <div class="paperShadow shadow-right">
            <asp:Label ID="descriptionLabel" runat="server" Text="Label"></asp:Label> <br />
                <br />
                <br />
                   
            <right><asp:Label CssClass="ProductPrice" ID="priceLabel" runat="server" Text=""></asp:Label></right>
            <br />  
            <uc4:ProductCustomAttributes ID="ProductCustomAttributes1" runat="server" />
            <br /> 
            <uc2:ProductAttributes ID="ProductAttributes1" runat="server" /> 
            <br />
            <uc3:ProductAttributesRadio ID="ProductAttributesRadio1" runat="server" /> 
            </div>  
            
        </div>       
     </div> 
    <div class="row-fluid"> 
   
    </div>
    <uc1:PicturesModals runat="server" id="PicturesModals" />
</asp:Content>
