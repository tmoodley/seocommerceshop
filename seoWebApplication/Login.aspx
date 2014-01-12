 <%@ Page Language="C#" MasterPageFile="~/default2.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="seoWebApplication.Login" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"
runat="server">
     <center>
         
 
<table>
<caption><h2>Returning Customer</h2></caption>
<tr>
    <td><label class="label" for="login-username">Email</label></td>
    <td><asp:textbox id="m_textboxUserName" tabindex="4" runat="server" 
                    columns="12" Width="152px" CssClass="textbox"></asp:textbox></td>
</tr>  
 <tr>
    <td><label class="label" for="login-password">Password</label></td>
    <td><asp:textbox id="m_textboxPassword" runat="server" columns="12" 
                    textmode="Password" Width="152px" CssClass="textbox"></asp:textbox></td>
</tr>  
 <tr>
    <td><asp:Label ID="lblInfo" runat="server" Text=""></asp:Label></td>
    <td><a id="forgotLink" href="#">Forgot your password?</a></td>
</tr> 
 
 <tr>
    <td></td>
    <td><asp:button id="button" runat="server" text="LOG IN" 
                        cssclass="button" onclick="OnLogin"></asp:button></td>
</tr>  
</table> 
  
    </center>
</asp:content>
 