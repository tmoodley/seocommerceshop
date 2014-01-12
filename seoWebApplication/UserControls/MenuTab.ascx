<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuTab.ascx.cs" Inherits="seoWebApplication.UserControls.MenuTab" %>
 
<ul class="glossymenu">   
 
<asp:Repeater ID="list" runat="server" OnItemDataBound="list_ItemDataBound"> 
 
<HeaderTemplate> 
</HeaderTemplate> 
<ItemTemplate> 
    <asp:Label ID="lblTop" runat="server" Text=""></asp:Label> 
    <asp:HyperLink ID="deptHyperLink" runat="server"></asp:HyperLink>
    <asp:Label ID="lblBottom" runat="server" Text=""></asp:Label>  
</ItemTemplate>

</asp:Repeater>
</ul>
 