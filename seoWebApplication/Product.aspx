<%@ Page Language="C#" MasterPageFile="~/default2.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="seoWebApplication.Product" Title="Product Details Page" %>

<%@ Register src="UserControls/ProductRecommendations.ascx" tagname="ProductRecommendations" tagprefix="uc1" %>

<%@ Register src="UserControls/ProductAttributes.ascx" tagname="ProductAttributes" tagprefix="uc2" %>

<%@ Register src="UserControls/ProductAttributesRadio.ascx" tagname="ProductAttributesRadio" tagprefix="uc3" %>

<%@ Register src="UserControls/ProductCustomAttributes.ascx" tagname="ProductCustomAttributes" tagprefix="uc4" %>

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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 

<div class="column5">
     <div class="row-fluid">
        <div class="span5">
            <div class="paperShadow shadow-bottom" style="text-align:center;">
            <h1><asp:Label CssClass="ProductTitle" ID="titleLabel" runat="server" Text="Label"></asp:Label></h1>
            </div> 
        </div>
    </div>
    <div class="row-fluid">
        <div class="span2"><div class="paperShadow shadow-left"><asp:Image ID="productImage" runat="server" Height="75%" Width="100%" /></div></div>
        <div class="span3">
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
            <div class="fb-like" data-href="<%= "" + url %>" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
        </div> 
    </div>
</div>
  

 

  

 


 
 
 
 

</asp:Content>
