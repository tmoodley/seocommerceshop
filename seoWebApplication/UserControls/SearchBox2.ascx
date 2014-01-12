<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBox2.ascx.cs" Inherits="seoWebApplication.SearchBox2" %>
<script language="javascript" type="text/javascript">
// <!CDATA[

function searchQueryInputField_onclick() {

}

// ]]>
</script>

<asp:Panel ID="searchPanel" runat="server" DefaultButton="goButton">

 <div class="search">
 
<label class="fl_left">Search: </label>
<div class="input-width fl_left">
<asp:TextBox ID="searchTextBox" Runat="server" size="30"
MaxLength="100" CssClass="searchTextBox" Height="18px" style="margin: 2px;"/>
<asp:CheckBox ID="allWordsCheckBox" Runat="server"
Text="all words" CssClass="searchAllWords" />
   
 <button type="submit" class="form-button"><span>Search</span></button>
</div>

</div>
 
 
</asp:Panel>
