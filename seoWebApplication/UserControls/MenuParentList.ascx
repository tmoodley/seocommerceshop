<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuParentList.ascx.cs" Inherits="seoWebApplication.UserControls.MenuParentList" %>
 
 <div id="mainmenu">
     
<asp:DataList ID="list" runat="server" Width="200px" OnItemDataBound="list_ItemDataBound" >
<HeaderStyle CssClass="custom-links-header" />
<HeaderTemplate>
 
</HeaderTemplate> 
<ItemTemplate> 
<li> 
    <asp:HyperLink ID="deptHyperLink" runat="server">HyperLink</asp:HyperLink>    
</li>
</ItemTemplate>

</asp:DataList>
</div> 