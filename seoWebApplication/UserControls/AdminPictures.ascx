<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminPictures.ascx.cs" Inherits="seoWebApplication.UserControls.AdminPictures" %>
  
<div id="featuredProducts">  
      <a class="btn btn-default" href="/picture/create/<%=productId %>">Add New Picture</a>          
<div id="featuredProductsList" class="group" style="display: block;">
<asp:Repeater ID="list" runat="server">  
 <itemtemplate>   
            <article class="collectionProduct productOne" itemscope="" itemtype="http://schema.org/Product">
                  <a href="<%# Link.ToProduct(Eval("productFK").ToString()) %>">
                    <div class=" collectionproductimagewrapper">
                         <img width="100" border="0"
                src="<%# Eval("Url").ToString() %>"
                alt='<%# HttpUtility.HtmlEncode(Eval("Alt").ToString())%>' />
                    </div><!-- collectionProductImageWrapper -->
                    <header> 
                         <a class="btn btn-default" href="/picture/delete/<%# Eval("id").ToString() %>" >Delete</a>
                       <%--  <a class="btn btn-default"  data-toggle="modal" href="/picture/edit/<%# Eval("id").ToString() %>" data-target="#bs-<%# Eval("id").ToString() %>">Edit</a>--%>
  
                        <div class="group">

                        </div><!-- group -->
                    </header>
                </a>
            </article><!-- collectionProductFeatured -->  
      <!-- Modal -->
    <div class="modal fade bs-<%# Eval("id").ToString() %>" id="bs-<%# Eval("id").ToString() %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h4 class="modal-title" id="myModalLabel">Modal title</h4>
          </div>
          <div class="modal-body">
            ...
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button> 
          </div>
        </div>
      </div>
    </div>
</ItemTemplate>
</asp:Repeater>
</div><!-- featuredProductsList --> 
</div>
