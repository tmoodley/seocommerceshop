<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuTab.ascx.cs" Inherits="seoWebApplication.UserControls.MenuTab" %>
 
<ul class="mainnav">   
 
<asp:Repeater ID="list" runat="server" OnItemDataBound="list_ItemDataBound"> 
 
<HeaderTemplate> 
</HeaderTemplate> 
<ItemTemplate> 
    <li class="active">
	 <asp:HyperLink ID="deptHyperLink" runat="server"></asp:HyperLink>		
	</li>
  
</ItemTemplate>

</asp:Repeater>
</ul>
 