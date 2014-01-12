<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentsList.ascx.cs" Inherits="seoWebApplication.UserControls.DepartmentsList" %>
<%@ Register src="CategoriesList.ascx" tagname="CategoriesList" tagprefix="uc1" %>
<div id="custom-links"> 
<ul class="nav nav-stacked">
    <li>
    <a href="/">Home</a>
    </li>  
<asp:Repeater ID="list" runat="server" OnItemCreated="R1_ItemCreated">  
 <itemtemplate>   
  <li id="liProdView" class="prodviewwide" runat="server">
  <asp:HyperLink ID="deptHyperLink" runat="server">HyperLink</asp:HyperLink>  
 </li>  
</itemtemplate>
</asp:Repeater> 
</ul>
</div> 