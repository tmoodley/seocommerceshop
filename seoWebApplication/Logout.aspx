<%@ Page Language="C#"  MasterPageFile="~/adminMstr.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="seoWebApplication.Logout" %>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"
runat="server">
    
<center>
<div id="wrapper">
<div id="steps">
    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
  <form id="Form1" runat=server> 
      <fieldset class="step">
<legend>You have been logged out!</legend>
        <td align="middle">
            
            <asp:hyperlink id="hlLogin" runat="server" cssclass="button" 
            navigateurl="default.aspx" Width="155px">Log back in.</asp:hyperlink>
        </td>
    </p>
</fieldset>
</div>
</div>
     
       
       
                 
                     
    </form>
    </center>
</asp:content>
