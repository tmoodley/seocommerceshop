<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PicturesModals.ascx.cs" Inherits="seoWebApplication.UserControls.PicturesModals" %>
 
<div> 

<div id="featuredProductsList" class="group" style="display: block;">
    
<asp:Repeater ID="list" runat="server">  
 <itemtemplate>  
     <!-- Small modal --> 
    <div class="modal fade bs-<%# Eval("id").ToString() %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h4 class="modal-title" id="myModalLabel"><%# HttpUtility.HtmlEncode(Eval("Name").ToString())%></h4>
          </div>
          <div class="modal-body">
           <center><img src="<%# Eval("Url").ToString() %>" alt='<%# HttpUtility.HtmlEncode(Eval("Alt").ToString())%>' class="img-thumbnail" /></center>
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
