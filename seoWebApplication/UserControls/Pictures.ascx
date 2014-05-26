<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pictures.ascx.cs" Inherits="seoWebApplication.UserControls.Pictures" %>
 
<div id="featuredProducts"> 

<div id="featuredProductsList" class="group" style="display: block;">
    
<asp:Repeater ID="list" runat="server">  
 <itemtemplate>   
            <article class="collectionProduct productOne" itemscope="" itemtype="http://schema.org/Product">
                   <a data-toggle="modal" href="#" data-target=".bs-<%# Eval("id").ToString() %>">
                    <div class=" collectionproductimagewrapper">
                         <div id="productimage">
                             <img width="100" border="0"
                    src="<%# Eval("Url").ToString() %>"
                    alt='<%# HttpUtility.HtmlEncode(Eval("Alt").ToString())%>' />
                         </div>
                    </div><!-- collectionProductImageWrapper -->
                    <header> 
                        <button class="btn btn-primary" data-toggle="modal" data-target=".bs-<%# Eval("id").ToString() %>"><div itemprop="name"><%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %></div></button>
                        <div class="group">

                        </div><!-- group -->
                    </header>
                </a>
            </article><!-- collectionProductFeatured -->   
</ItemTemplate>
</asp:Repeater>
    
</div><!-- featuredProductsList --> 
</div> 
<script src="../js/navigator.init.js"></script>
