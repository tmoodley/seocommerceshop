<%@ Page Language="C#" MasterPageFile="~/seowebapp.Master" Title="Shade 4 Sale: Opps" %>
 
<script runat="server">
protected void Page_Load(object sender, EventArgs e)
{
// set the 500 status code
Response.Status = "500 Internal Server Error";
}
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Looking for Shade?</h1>
<p>Your request generated an internal error!</p>
<p>We apologize for the inconvenience. The error has been reported and will
be fixed as soon as possible. Thank you!</p>
<p>Please visit our
<asp:HyperLink ID="HyperLink1" runat="server" Target="~/" Text="catalog" />,
or contact us at support@shade4sale.com!
</p>
<p>The <b>Shade4sale</b> team</p>
</asp:Content>
 