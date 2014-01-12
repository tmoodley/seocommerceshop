<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuList.ascx.cs" Inherits="seoWebApplication.UserControls.MenuList" %>
 
 
     <ul id="menu">   
        <asp:Repeater ID="outerRep" runat="server" OnItemDataBound="outerRep_ItemDataBound">
             <ItemTemplate>
             <li> 
                <asp:HyperLink ID="deptHyperLink" runat="server">HyperLink</asp:HyperLink>    
                 <asp:Literal ID="litUL" runat="server"></asp:Literal>
            
                <asp:Repeater ID="innerRep" runat="server" OnItemDataBound="innerRep_ItemDataBound">
                
                <ItemTemplate> 

                <li> 
                    <asp:HyperLink ID="catHyperLink" runat="server">HyperLink</asp:HyperLink>    
                </li>
                </ItemTemplate>
               
                </asp:Repeater>
                <asp:Literal ID="litUL2" runat="server"></asp:Literal>
                
             </li> 
             </ItemTemplate>
       </asp:Repeater>
    </ul>
 