<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditGrid.master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="seoWebApplication.admin.products" %>

<%@ Register Assembly="seoWebApplication" Namespace="seoWebApplication.st.SharkTankDAL.Framework"
    TagPrefix="cc1" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditGrid.master"%>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 
 <asp:GridView ID="cgvProducts" runat="server"  BorderColor="#CCCCCC" 
        onrowdatabound="cgvProducts_RowDataBound" CssClass="wrapper">
    <AlternatingRowStyle BackColor="#CCCCCC" />
</asp:GridView> 
 
</asp:Content>
