<%@ Page Title="" Language="C#" MasterPageFile="~/seoWebAppAdminEditPage.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="seoWebApplication.admin.product" %>
<%@ MasterType virtualPath="~/seoWebAppAdminEditPage.master"%>
<%@ Register Src="~/UserControls/Pictures.ascx" TagPrefix="uc1" TagName="Pictures" %>
<%@ Register Src="~/UserControls/AdminPictures.ascx" TagPrefix="uc1" TagName="AdminPictures" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   
 <div id="adminwrapper">
    <asp:Menu
        id="menuTabs"
        CssClass="menuTabs"
        StaticMenuItemStyle-CssClass="tab btn"
        StaticSelectedStyle-CssClass="selected btn"
        Orientation="Horizontal"
        OnMenuItemClick="menuTabs_MenuItemClick"
        Runat="server">
        <Items>
        <asp:MenuItem
            Text="General"
            Value="0" 
              />
              <asp:MenuItem
            Text="Product Attributes"
            Value="1" 
              />
               <asp:MenuItem
            Text="Images"
            Value="2" 
              />
               <asp:MenuItem
            Text="Category"
            Value="3" />
            
        <asp:MenuItem
            Text="SEO" 
            Value="4"/>
       
            
            <asp:MenuItem
            Text="Product Kit"
            Value="5" />
           
             <asp:MenuItem
            Text="Shopping Cart"
            Value="6" /> 
            
              <asp:MenuItem
            Text="Suppliers"
            Value="7" />
            
        </Items>
    </asp:Menu>    
    </div>
    
    
     <div class="adminwrapper">
    <asp:MultiView
        id="multiTabs"
        ActiveViewIndex="0"
        Runat="server">
        <asp:View ID="view1" runat="server">
        
        
 
<div class="group">
<table class="border">

<tr>
<td>
<label for="name">name:</label>
</td>
<td>
<asp:TextBox ID="txtname" runat = "server"></asp:TextBox></td>
<td>
 
</td>
<td>
<asp:TextBox ID="txtwebstore_id" runat = "server" Visible="False"></asp:TextBox></td>

</tr>
<tr>
<td>
<label for="description">description:</label>
</td>
<td>
<asp:TextBox ID="txtdescription" runat = "server"></asp:TextBox></td>
<td>
<label for="price">price:</label>
</td>
<td>
<asp:TextBox ID="txtprice" runat = "server"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="thumbnail">thumbnail:</label>
</td>
<td>
<asp:TextBox ID="txtthumbnail" runat = "server"></asp:TextBox></td>
<td>
<label for="image">image:</label>
</td>
<td>
<asp:TextBox ID="txtimage" runat = "server"></asp:TextBox></td>
</tr>
<tr>
<td>
<label for="promofront">promofront:</label>
</td>
<td>
<asp:CheckBox ID="chkpromofront" runat = "server"></asp:CheckBox></td>
<td>
<label for="promodept">promodept:</label>
</td>
<td>
<asp:CheckBox ID="chkpromodept" runat = "server"></asp:CheckBox></td>
</tr> 
<tr>
<td>
<label for="defaultAttribute">Show Default Attributes:</label>
</td>
<td>
<asp:CheckBox ID="chkdefaultAttribute" runat = "server"></asp:CheckBox></td>
<td>
<label for="defaultAttCat">Show Default Category Attribute:</label>
</td>
<td>
<asp:CheckBox ID="chkdefaultAttCat" runat = "server"></asp:CheckBox></td>
</tr>
</table>
   </asp:View>

   <asp:View ID="view2" runat="server">

   <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" /> 
          <asp:GridView ID="cgvAttributeValues" runat="server"  BorderColor="#CCCCCC" 
        onrowdatabound="cgvAttributeValues_RowDataBound" CssClass="wrapper">
    <AlternatingRowStyle BackColor="#CCCCCC" />
</asp:GridView>

   </asp:View>
      <asp:View ID="view3" runat="server">
      <p>
          <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
      </p>
      <p>
Image1 file name:
<asp:Label ID="Image1Label" runat="server" />
<asp:FileUpload ID="image1FileUpload" runat="server" />
<asp:Button ID="upload1Button" runat="server" Text="Upload" 
        onclick="upload1Button_Click" /><br />
<asp:Image ID="image1" runat="server" />
</p>
<p>
Image2 file name:
<asp:Label ID="Image2Label" runat="server" />
<asp:FileUpload ID="image2FileUpload" runat="server" />
<asp:Button ID="upload2Button" runat="server" Text="Upload" 
        onclick="upload2Button_Click" /><br />
<asp:Image ID="image2" runat="server" />
</p>
   </asp:View>

   <asp:View ID="view4" runat="server">
       <asp:DropDownList ID="ddlCategory" runat="server">
       </asp:DropDownList>     
    
          <asp:Button ID="btnCat" runat="server" Text="Add" onclick="btnCat_Click" />
    
          <asp:GridView ID="cgvCategory" runat="server"  BorderColor="#CCCCCC" 
          onrowdatabound="cgvCategory_RowDataBound" 
       CssClass="wrapper">
    <AlternatingRowStyle BackColor="#CCCCCC" />
</asp:GridView>
 
   </asp:View>

     <asp:View ID="view5" runat="server">
       
 
 
   </asp:View>

     <asp:View ID="view6" runat="server">
       
 
 
   </asp:View>

     <asp:View ID="view7" runat="server">
       
 <asp:Button ID="btnDeleteProductScart" runat="server" Text="Remove Products from Scart" 
           onclick="btnDeleteProductScart_Click" />  
 
   </asp:View>

   <asp:View ID="view8" runat="server">
       
 
 
   </asp:View>
    </asp:MultiView> 
    
    </div>  
       
     <!-- sample modal content -->
 
<div class="modal fade bs-example-modal-lg bs-<%=Id %>" tabindex="-1" id="myModal" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title">Modal title</h4>
      </div>
      <div class="modal-body">
        <p>One fine body&hellip;</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
    <uc1:AdminPictures runat="server" id="AdminPictures" /> 
</asp:Content>
