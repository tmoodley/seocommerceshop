<%@ Page Title="" Language="C#" MasterPageFile="~/default2.master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="seoWebApplication.account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="fb-root"></div>
<script>
    window.fbAsyncInit = function () {
        FB.init({
            appId: '221557484648265', // App ID
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true  // parse XFBML
        });

        // Additional initialization code here
        FB.Event.subscribe('auth.authResponseChange', function (response) {
            if (response.status === 'connected') {
                // the user is logged in and has authenticated your
                // app, and response.authResponse supplies
                // the user's ID, a valid access token, a signed
                // request, and the time the access token 
                // and signed request each expire
                var uid = response.authResponse.userID;
                var accessToken = response.authResponse.accessToken;
 
                    if (response.authResponse) {
                         
                        FB.api('/me', function (response) {
                            alert('Good to see you, ' + response.name + '.');
                        });
                    } else {
                        alert('User cancelled login or did not fully authorize.');
                    }
                
               
                
             

            } else if (response.status === 'not_authorized') {
                // the user is logged in to Facebook, 
                // but has not authenticated your app
            } else {
                // the user isn't logged in to Facebook.
            }
        });
    };

    

    // Load the SDK Asynchronously
    (function (d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement('script'); js.id = id; js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";
        ref.parentNode.insertBefore(js, ref);
    }(document));

  
</script>
    <asp:repeater id="Repeater1" runat="server"></asp:repeater>
    <asp:label runat="server" text="" id="lblToken"></asp:label>
    <asp:label runat="server" text="" id="lblMessage"></asp:label>
    <div class="fb-login-button" data-show-faces="true" data-width="400" data-max-rows="1"></div>
</asp:Content>
