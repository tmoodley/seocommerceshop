<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditGrid.master" AutoEventWireup="true" CodeBehind="departments.aspx.cs" Inherits="seoWebApplication.admin.catalog.departments" %>

<%@ Register Assembly="seoWebApplication" Namespace="seoWebApplication.st.SharkTankDAL.Framework"
    TagPrefix="cc1" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditGrid.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <asp:GridView ID="cgvDepartments" runat="server"  BorderColor="#CCCCCC" 
        onrowdatabound="cgvDepartments_RowDataBound" CssClass="wrapper">
    <AlternatingRowStyle BackColor="#CCCCCC" />
</asp:GridView> 
</asp:Content>
