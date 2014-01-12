<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoriesList.ascx.cs" Inherits="seoWebApplication.UserControls.CategoriesList" %>
<div id="custom-links">
<ul class="nav nav-stacked">
<asp:Repeater ID="list" runat="server" OnItemCreated="R1_ItemCreated">  
<ItemTemplate> 
<li id="liCatView" class="catviewwide" runat="server"> 
    <asp:HyperLink ID="catHyperLink" runat="server">HyperLink</asp:HyperLink>    
</li>
</ItemTemplate>
</asp:Repeater>
</ul>
</div> 