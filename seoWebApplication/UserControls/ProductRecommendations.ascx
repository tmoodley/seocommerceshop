<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductRecommendations.ascx.cs" Inherits="seoWebApplication.UserControls.ProductRecommendations" %>
 
<asp:Repeater ID="repeaterList" runat="server">
<HeaderTemplate><H2>We also recommend:</H2></HeaderTemplate>
 
<ItemTemplate> 
 
 <li>
<a href='<%# Link.ToProduct(Eval("product_id").ToString())%>'><font color='#ff0000'></font>
    
<%# Eval("name") %>
</a>
 
<%# Eval("description") %>
 </li>
  
</ItemTemplate>
 
</asp:Repeater>

 