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
               
            </div>
      
			<div class="row-fluid print-hide">
				<div class="span12">
                    <div class="span5">
                    </div>
                    <div class="span3">
                      <uc2:Pager ID="Pager1" runat="server" />  
                    </div>
					<div class="span4">
                    </div>
				</div>
			</div> 
		     
     
  <asp:Repeater ID="list" runat="server" OnItemCreated="R1_ItemCreated">   
     <itemtemplate>   
         <asp:Literal ID="lblDivStart" runat="server"></asp:Literal>
     <li class="span3">
		<div class="thumbnail dark"> 
				<span class="label label-info price"><%# Eval("price", "{0:c}") %></span> 
					<a href="<%# Link.ToProduct(Eval("product_id").ToString()) %>">
                    <img width="225" border="0"
                    src="<%# Link.ToProductImage(Eval("thumbnail").ToString()) %>"
                    alt='<%# HttpUtility.HtmlEncode(Eval("name").ToString())%>' class="product-image" />
                    </a>
			 
			<div class="caption">
				<a href="<%# Link.ToProduct(Eval("product_id").ToString()) %>">
                <%# HttpUtility.HtmlEncode(Eval("name").ToString()) %>
                </a>
                <div class="description-block">
                <%# HttpUtility.HtmlEncode(Eval("description").ToString()) %>         
                </div> 
			</div>
                <a href='<%# Link.ToProduct(Eval("product_id").ToString()) %>' class="btn btn-block">Details</a>
		</div>
	</li>  
         <asp:Literal ID="lblDivEnd" runat="server"></asp:Literal>
    </itemtemplate>
        
    </asp:Repeater>
    
          
            
        </div>
    </div>
</asp:Content>
 