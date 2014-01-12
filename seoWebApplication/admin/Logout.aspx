<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="sharktank.Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title>Log in</title>
 
    <style type="text/css">
        #loginbox
        {
            width: 415px;
        }
        .newStyle1
        {
            font-family: "Adobe Caslon Pro Bold";
            font-size: larger;
            font-weight: bolder;
            font-style: oblique;
            font-variant: normal;
            text-transform: uppercase;
            color: #808000;
        }
        .wrapper{
            -moz-box-shadow:0px 0px 3px #aaa;
            -webkit-box-shadow:0px 0px 3px #aaa;
            box-shadow:0px 0px 3px #aaa;
            -moz-border-radius:10px;
            -webkit-border-radius:10px;
            border-radius:10px;
            border:2px solid #fff;
            background-color:#f9f9f9;
            width:600px;
            overflow:hidden;
        }
        #wrapper
        {
           
            -moz-box-shadow:0px 0px 3px #aaa;
            -webkit-box-shadow:0px 0px 3px #aaa;
            box-shadow:0px 0px 3px #aaa;
            -moz-border-radius:10px;
            -webkit-border-radius:10px;
            border-radius:10px;
            border:2px solid #fff;
            background-color:#f9f9f9;
            width:600px;
            overflow:hidden;
        }
        body{
    color:#444444;
    font-size:13px;
    background: #f2f2f2;
    font-family:"Century Gothic", Helvetica, sans-serif;
}
#loginbox form input:focus{
    -moz-box-shadow:0px 0px 3px #aaa;
    -webkit-box-shadow:0px 0px 3px #aaa;
    box-shadow:0px 0px 3px #aaa;
    background-color:#FFFEEF;
}
#loginbox form select{
    background: #ffffff;
    border: 1px solid #ddd;
    -moz-border-radius: 3px;
    -webkit-border-radius: 3px;
    border-radius: 3px;
    outline: none;
    padding: 5px;
    width: 200px;
    float:left;
}
#loginbox form p.submit{
    background:none;
    border:none;
    -moz-box-shadow:none;
    -webkit-box-shadow:none;
    box-shadow:none;
}
 
#steps form fieldset{
    border:none;
    padding-bottom:20px;
}
#steps form legend{
    text-align:center;
    background-color:#f0f0f0;
    color:#666;
    font-size:24px;
    text-shadow:1px 1px 1px #fff;
    font-weight:bold;
    float:left;
    width:590px;
    padding:5px 0px 5px 10px;
    margin:10px 0px;
    border-bottom:1px solid #fff;
    border-top:1px solid #d9d9d9;
}
#steps form p{
	display:table;
    float:left;
    clear:both;
    margin:5px 0px;
    background-color:#f4f4f4;
    border:1px solid #fff;
    width:400px;
    padding:10px;
    margin-left:100px;
    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;
    -moz-box-shadow:0px 0px 3px #aaa;
    -webkit-box-shadow:0px 0px 3px #aaa;
    box-shadow:0px 0px 3px #aaa;
}
#steps form p label{
    width:160px;
    float:left;
    text-align:right;
    margin-right:15px;
    line-height:26px;
    color:#666;
    text-shadow:1px 1px 1px #fff;
    font-weight:bold;
}

#steps form input:focus{
    -moz-box-shadow:0px 0px 3px #aaa;
    -webkit-box-shadow:0px 0px 3px #aaa;
    box-shadow:0px 0px 3px #aaa;
    background-color:#FFFEEF;
}
#steps form p.submit{
    background:none;
    border:none;
    -moz-box-shadow:none;
    -webkit-box-shadow:none;
    box-shadow:none;
}
#steps form li.submit{
    background:none;
    border:none;
    -moz-box-shadow:none;
    -webkit-box-shadow:none;
    box-shadow:none;
}
 
.button:hover {
    background:#d8d8d8;
    color:#666;
    text-shadow:1px 1px 1px #fff;
}
        .button
        {
            border:none;
	outline:none;
    -moz-border-radius: 10px;
    -webkit-border-radius: 10px;
    border-radius: 10px;
    color: #ffffff;
    display: block;
    cursor:pointer;
    margin: 0px auto;
    clear:both;
    padding: 7px 25px;
    text-shadow: 0 1px 1px #777;
    font-weight:bold;
    font-family:"Century Gothic", Helvetica, sans-serif;
    font-size:22px;
    -moz-box-shadow:0px 0px 3px #aaa;
    -webkit-box-shadow:0px 0px 3px #aaa;
    box-shadow:0px 0px 3px #aaa;
    background:#4797ED;
        }
        .newStyle2 select
        {
              background: #ffffff;
    border: 1px solid #ddd;
    -moz-border-radius: 3px;
    -webkit-border-radius: 3px;
    border-radius: 3px;
    outline: none;
    padding: 5px;
    width: 200px;
    float:left; 
        }
        .newStyle2
        {
           background: #ffffff;
    border: 1px solid #ddd;
    -moz-border-radius: 3px;
    -webkit-border-radius: 3px;
    border-radius: 3px;
    outline: none;
    padding: 5px;
    width: 200px;
    float:left;
        }
        
         .newStyle2 focus
        {
             -moz-box-shadow:0px 0px 3px #aaa;
    -webkit-box-shadow:0px 0px 3px #aaa;
    box-shadow:0px 0px 3px #aaa;
    background-color:#FFFEEF;
        }
    </style>
</head>
<body>
    
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
</body>
</html>
