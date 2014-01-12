<%@ Page Language="C#" MasterPageFile="~/default2.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="seoWebApplication.Catalog" Title="MyDinner2Go: Online Ordering" %>

<%@ Register Src="UserControls/ProductsList.ascx" TagName="ProductsList" TagPrefix="uc1" %>
<%@ Register Src="UserControls/Pager.ascx" TagName="Pager" TagPrefix="uc2" %>

<%@ Register Src="UserControls/DeptCategoriesList.ascx" TagName="DeptCategoriesList" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">
    <div class="panel-body">
        <div class="panel-innards">
            <div class="panel-header">
                <div class="standardPageTitle">
                    <asp:Label ID="catalogTitleLabel" CssClass="CatalogTitle"
                        runat="server" />
                </div>
                <div class="standardPageDesc">
                    <asp:Label ID="catalogDescriptionLabel" CssClass="CatalogDescription"
                        runat="server" />
                </div>
                <div class="standardPageDesc"> 
                <uc2:Pager ID="Pager1" runat="server" /> 
                </div>
            </div>
            <div class="column12">
<div class="row-mix">
     
  <asp:Repeater ID="list" runat="server">  
     <itemtemplate>  
     <div class="span3">
     
     <div class="image_block">
     <a href="<%# Link.ToProduct(Eval("product_id").ToString()) %>">
     <img width="225" border="0"
     src="<%# Link.ToProductImage(Eval("thumbnail").ToString()) %>"
     alt='<%# HttpUtility.HtmlEncode(Eval("name").ToString())%>' class="product-image" />
     </a>
     </div>
     <div class="header_block">
    <h2><a href="<%# Link.ToProduct(Eval("product_id").ToString()) %>">
    <%# HttpUtility.HtmlEncode(Eval("name").ToString()) %>
    </a></h2> 
    </div>

     <div class="price-block">
         <%# Eval("price", "{0:c}") %>
     </div> 

    <div class="description-block">
    <%# HttpUtility.HtmlEncode(Eval("description").ToString()) %>         
    </div> 
    <div class="details-block">
    <a href='<%# Link.ToProduct(Eval("product_id").ToString()) %>' class="button">Details</a>
    </div>

    </div>         
    </itemtemplate>
    </asp:Repeater>
  
</div>
</div>
            <div class="standardPageDesc"> 
                <uc2:Pager ID="Pager2" runat="server" /> 
            </div>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Menu Categories</h3>



    <div class="panel-body">
        <div class="panel-innards">
            <div class="panel-header">
                <div class="standardPageTitle">
                    <asp:Label ID="catalogTitleLabel" CssClass="CatalogTitle"
                        runat="server" />
                </div>
                <div class="standardPageDesc">
                    <asp:Label ID="catalogDescriptionLabel" CssClass="CatalogDescription"
                        runat="server" />
                </div>

            </div>

            <uc3:DeptCategoriesList ID="DeptCategoriesList1" runat="server" />

        </div>
    </div>


</asp:Content>--%>
