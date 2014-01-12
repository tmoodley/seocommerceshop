<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuSubList.ascx.cs" Inherits="seoWebApplication.UserControls.MenuSubList" %>
 <%@ Register src="CategoriesList.ascx" tagname="CategoriesList" tagprefix="uc1" %>
 <div id="mainmenu">
     
<asp:DataList ID="list" runat="server" Width="200px" OnItemDataBound="list_ItemDataBound" >
<HeaderStyle CssClass="custom-links-header" />
<HeaderTemplate>
  
</HeaderTemplate> 
<ItemTemplate> 
<li> 
    <asp:HyperLink ID="catHyperLink" runat="server">HyperLink</asp:HyperLink>    
</li>
</ItemTemplate>

</asp:DataList>
</div> 