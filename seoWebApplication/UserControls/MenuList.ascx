<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuList.ascx.cs" Inherits="seoWebApplication.UserControls.MenuList" %>
 
 
     <ul class="mainnavddl">   
        <asp:Repeater ID="outerRep" runat="server" OnItemDataBound="outerRep_ItemDataBound">
             <ItemTemplate> 
                 <li class="dropdown active">					
						<a href="javascript:;" class="btn" data-toggle="dropdown">                             
							<span> 
                               <asp:Literal ID="litText" runat="server"></asp:Literal>  
                            </span> 
						</a>	    
					
						<ul class="dropdown-menu">  
                           
                <asp:Repeater ID="innerRep" runat="server" OnItemDataBound="innerRep_ItemDataBound">
                
                <ItemTemplate>  
                     <li>
                                  <asp:HyperLink ID="catHyperLink" runat="server">HyperLink</asp:HyperLink>  
                          
                </li>
                </ItemTemplate>
               
                </asp:Repeater>
                            </li> 
                       </ul> 				
					
                     
                
             </ItemTemplate>
       </asp:Repeater>
    </ul>
 