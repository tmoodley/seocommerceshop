<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditGrid.master" AutoEventWireup="true" CodeBehind="attributes.aspx.cs" Inherits="seoWebApplication.admin.settings.attributes" %>
<%@ Register Assembly="seoWebApplication" Namespace="seoWebApplication.st.SharkTankDAL.Framework"
    TagPrefix="cc1" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditGrid.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <asp:GridView ID="cgvAttributes" runat="server"  BorderColor="#CCCCCC" 
        onrowdatabound="cgvAttributes_RowDataBound" CssClass="wrapper">
    <AlternatingRowStyle BackColor="#CCCCCC" />
</asp:GridView>
</asp:Content>
