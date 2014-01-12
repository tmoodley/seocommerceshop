<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CuisineList.ascx.cs" Inherits="seoWebApplication.UserControls.CuisineList" %>
<%@ Register src="CategoriesList.ascx" tagname="CategoriesList" tagprefix="uc1" %>
 <div id="custom-links">     
<asp:DataList ID="list" runat="server" Width="200px" OnItemDataBound="list_ItemDataBound" >
<HeaderStyle CssClass="custom-links-header" />
<HeaderTemplate>
<div id="custom-links-header">Options</div>  
</HeaderTemplate> 
<ItemTemplate> 
<li> 
    <asp:HyperLink ID="cuisineHyperLink" runat="server">HyperLink</asp:HyperLink>    
</li>
</ItemTemplate>
</asp:DataList>
</div> 