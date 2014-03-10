<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBox.ascx.cs" Inherits="seoWebApplication.SearchBox" %>
<script language="javascript" type="text/javascript">
// <!CDATA[

function searchQueryInputField_onclick() {

}

// ]]>
</script>

<div class="form-inline">
    <asp:TextBox ID="searchTextBox" Runat="server" size="30" MaxLength="100" CssClass="input-search" Height="34px" style="margin: 2px;" placeholder="Search all products..."/>   
    <label class="ctrl-check">
        <asp:CheckBox ID="allWordsCheckBox" Runat="server" Text="" CssClass="searchAllWords" /> 
        all words
    </label>

    <asp:Button ID="goButton" runat="server" CssClass="btn box-primary" Text="Search" OnClick="goButton_Click1" />  
</div>
 
  

  
    
