<%@ Page Title="" Language="C#" MasterPageFile="~/seowebappSans.Master" AutoEventWireup="true" CodeBehind="shippinginfo.aspx.cs" Inherits="seoWebApplication.shippinginfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="panel-innards">
<div class="group">
<h1>Shipping Information</h1>
<div id=wrapper-login> 
	  <p>U.S. UPS Ground</p> 
		<p><b>Standard Processing Time:</b> 1 business day</p>  
      </div>
	 
	<div id=wrapper-login> 
	  <div>U.S. UPS 2-Day</div>

	  <div style="height: 48px;">
		<p><b>Standard Processing Time:</b> 1 business day<br>
		<b>Transit Time:</b> 2 Business Days<br>
		</p>
	  </div>
	</div>

	<div id=wrapper-login> 
	  <div>U.S. PO Box / Hawaii / Alaska</div>
	  <div style="height: 0px;">
		<p><b>Standard Processing Time:</b> 1 - 5 business days</p>
<p><b>Hawaii Transit Time:</b> 7 - 10 business days</p>
<p><b>Alaska Transit Time:</b> 4 - 6 business days</p>

<p><b>PO Box Transit Time:</b> 1 - 7 business days</p>
	  </div>
	</div>
 <div id=wrapper-login> 
	  <div>U.S. Military / APO</div>
	  <div>
		<p><b>Standard Processing Time:</b> 1 - 5 business days</p>

<p><b>Transit Time:</b> 1 - 2 weeks</p>
           
	  </div>
      </div>
	 
	 <div id=wrapper-login> 
	  <div>USPS Air International</div>
	  <div style="height: 0px;">
		<p><b>Standard Processing Time:</b> 1 - 5 business days</p>

      <p><b>Transit Time:</b> 2 - 4 weeks</p>
	  </div>
      </div>
	 
 <div id=wrapper-login> 
<p>
	*Standard Processing Time reflects the handling of most orders. Under special circumstances, the processing time may be longer.<br>
	*Business Days are Monday - Friday and do not include most major holidays.
</p>
 </div>
 </div>
 </div>

</asp:Content>
