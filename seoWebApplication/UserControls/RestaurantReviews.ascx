<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestaurantReviews.ascx.cs" Inherits="seoWebApplication.UserControls.RestaurantReviews" %>
<div class="menuCategory">
    
        <asp:Repeater ID="outerRep" runat="server" OnItemDataBound="outerRep_ItemDataBound">
            <ItemTemplate>
                <asp:PlaceHolder ID="outerattrPlaceHolder" runat="server"></asp:PlaceHolder>
                <asp:Repeater ID="innerRep" runat="server" OnItemDataBound="innerRep_ItemDataBound">
                    <ItemTemplate>
                      
                            <asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
                      
                    </ItemTemplate>
                </asp:Repeater>
                </ul>
                </ItemTemplate>
                </asp:Repeater>
                 
    </div>