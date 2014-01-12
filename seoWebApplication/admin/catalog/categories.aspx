<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditGrid.master" AutoEventWireup="true" CodeBehind="categories.aspx.cs" Inherits="seoWebApplication.admin.catalog.categories" %>
<%@ Register Assembly="seoWebApplication" Namespace="seoWebApplication.st.SharkTankDAL.Framework"
    TagPrefix="cc1" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditGrid.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <asp:GridView ID="cgvCategories" runat="server"  BorderColor="#CCCCCC" 
        onrowdatabound="cgvCategories_RowDataBound" CssClass="wrapper">
    <AlternatingRowStyle BackColor="#CCCCCC" />
</asp:GridView>
</asp:Content>
