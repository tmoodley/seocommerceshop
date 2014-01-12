<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="seoWebApplication.UserControls.Pager" %>
<%
    if (this.showPager)
    {
%> 
<div class="pagination align-center pagination-circle">
<ul>  
<li>
<asp:HyperLink ID="prevLink" Runat="server">«</asp:HyperLink>
</li>
<asp:Repeater ID="pagesRepeater" runat="server">
<ItemTemplate>
    <li>
    <asp:HyperLink ID="hyperlink" runat="server" Text='<%# Eval("Page") %>' NavigateUrl='<%# Eval("Url") %>' />
    </li>
</ItemTemplate>
</asp:Repeater>
<li>
<asp:HyperLink ID="nextLink" Runat="server">»</asp:HyperLink>
</li>
</ul>
</div>  
<%
    }
%>