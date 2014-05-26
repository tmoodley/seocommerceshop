<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuList.ascx.cs" Inherits="seoWebApplication.UserControls.MenuList" %>
 
 
 
        <asp:Repeater ID="outerRep" runat="server" OnItemDataBound="outerRep_ItemDataBound">
             <ItemTemplate> 
             <li class="dropdown"> 
                  <a id="drop4" role="button" data-toggle="dropdown" href="#">  <asp:Literal ID="litText" runat="server"></asp:Literal>   <b class="caret"></b></a>					
					 <ul class="dropdown-menu">  
                           
                <asp:Repeater ID="innerRep" runat="server" OnItemDataBound="innerRep_ItemDataBound">
                
                <ItemTemplate>  
                     <li>
                                  <asp:HyperLink ID="catHyperLink" runat="server">HyperLink</asp:HyperLink>  
                          
                </li>
                </ItemTemplate>
               
                </asp:Repeater>
                            
                       </ul>  
             </li>   
             </ItemTemplate>
       </asp:Repeater>
    
 