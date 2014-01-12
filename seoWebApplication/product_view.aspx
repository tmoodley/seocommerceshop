<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product_view.aspx.cs" Inherits="seoWebApplication.product_view" Title="Product Details Page" %>

 

<%@ Register src="/UserControls/ProductAttributes.ascx" tagname="ProductAttributes" tagprefix="uc2" %>

<%@ Register src="/UserControls/ProductAttributesRadio.ascx" tagname="ProductAttributesRadio" tagprefix="uc3" %>

<%@ Register src="/UserControls/ProductCustomAttributes.ascx" tagname="ProductCustomAttributes" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 
<div class="panel-innards">
<div class="Productgroup">
<div class="main-content">
 
<div id="steps-about-menu"> 

<fieldset class="step-about-menu">
<center>
<legend> 
  
<h1><asp:Label CssClass="CatalogTitle" ID="titleLabel" runat="server"
Text="Label"></asp:Label></h1>
 
</legend>
</center>
</fieldset>
<table class="box"> 
<tr>
<td class="aligntop">
<p>
<asp:Image ID="productImage" runat="server" Height="355px" Width="279px" />
</p>
</td>
<td class="aligntop"> 
 
<div>
<div class="label"> 
<asp:Label ID="descriptionLabel" runat="server" Text="Label"></asp:Label> 
 <input id="id" value="<%=HttpContext.Current.Request.Form["product_id"]%>" type="hidden" />   
  <input id="id2" value="add" type="hidden" /> 
<asp:Label CssClass="ProductPrice" ID="priceLabel" runat="server"
Text="&lt;b&gt;Price:&lt;/b&gt;"></asp:Label> 
    <br />  
    <uc4:ProductCustomAttributes ID="ProductCustomAttributes1" runat="server" />
    <br /> 
    <uc2:ProductAttributes ID="ProductAttributes1" runat="server" /> 
    <br />
    <uc3:ProductAttributesRadio ID="ProductAttributesRadio1" runat="server" /> 
</div>
<p> 
<a class="button" href="/ajax/product_view.aspx?id=add&id2=<%=HttpContext.Current.Request.Form["product_id"] %>">add</a>
<asp:LinkButton ID="AddToCartButton" cssclass="button" runat="server"
onclick="AddToCartButton2_Click">Add to Shopping Cart</asp:LinkButton>
</p>
</div>
</td>
 </tr> 
 </table>
  
 
</div>
</div>
</div>
</div>

 </div>
    </form>
</body>
</html>