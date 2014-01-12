<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeptCategoriesList.ascx.cs" Inherits="seoWebApplication.UserControls.DeptCategoriesList" %>
<div>
    <ul>
        <asp:Repeater ID="outerRep" runat="server" OnItemDataBound="outerRep_ItemDataBound">
            <ItemTemplate>
              
                <ul>
                <asp:Repeater ID="innerRep" runat="server" OnItemDataBound="innerRep_ItemDataBound">
                    <ItemTemplate>
                      <li> 
                       <%-- <asp:Label Font-Size="Medium" Font-Bold="true" ID="lblCatDesc" runat="server" Text='<%# Eval("description") %>' />--%>
                            <div id="rightbox">
                            <asp:Label Font-Size="Large" Font-Bold="true" ID="lblCategoryName" runat="server" Text='<%# Eval("name") %>' /><br />
                            <br />
                            <asp:Label ID="hlProductName" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div id="rightbox">
                            <asp:Label ID="lblDesc" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div id="pricebox">
                            <asp:Label ID="lblPrice" runat="server" Text="" />
                            <a href='<%# Link.ToProduct(Eval("product_id").ToString()) %>' class="button">
                            View
                            </a>
                            </div>
                           
                      </li>

                    </ItemTemplate>
                </asp:Repeater>
                </ul>
                </ItemTemplate>
                </asp:Repeater>
                </ul>
    </div>