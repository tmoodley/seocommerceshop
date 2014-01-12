<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestaurantHours.ascx.cs" Inherits="seoWebApplication.UserControls.RestaurantHours" %>

 <center> 
   <div>
   <div><h5><asp:Label ID="lblName" runat="server" Text=""></asp:Label></h5>
      <h5> <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></h5>
   </div>
   
  <div id="accordion"> 
  <div>
   <h5>Monday Hours</h5> 
  </div>
   <table>  
            <%if (ckMonday.Checked)
            {%>
            <tr><td>Monday Breakfast: </td><td><asp:CheckBox ID="ckMonday" runat="server" Enabled="False" /> <asp:Label ID="lblMonBreakfastHrs" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Monday Breakfast: </td><td>Closed</td></tr>
            <%}
            if (ckMonLunch.Checked)
            { %>
            <tr><td>Monday Lunch:</td><td> <asp:CheckBox ID="ckMonLunch" runat="server" Enabled="False"></asp:CheckBox> <asp:Label ID="lblMonLunchHrs" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Monday Lunch: </td><td>Closed</td></tr>
            <%}
            if (ckMonDinner.Checked)
            { %>
            <tr><td>Monday Dinner:</td><td> <asp:CheckBox ID="ckMonDinner" runat="server" Enabled="False"></asp:CheckBox>  <asp:Label ID="lblMonDinner" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Monday Dinner: </td><td>Closed</td></tr>
            <%} %>
    </table>
    </div> 
   <div class="box">  
   <div><h5>Tuesday Hours</h5></div>
   <table>
            <%if (ckTueBreakfast.Checked)
            {%>  
            <tr><td>Tuesday Breakfast:</td><td> <asp:CheckBox ID="ckTueBreakfast" runat="server" Enabled="False" />  <asp:Label ID="lblTueBreakFast" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Tuesday BreakFast: </td><td>Closed</td></tr>
            <%}
                if (ckTueLunch.Checked)
            {%> 
            <tr><td>Tuesday Lunch:</td><td> <asp:CheckBox ID="ckTueLunch" runat="server" Enabled="False"></asp:CheckBox>  <asp:Label ID="lblTueLunch" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Tuesday Lunch: </td><td>Closed</td></tr>
            <%}
                if (ckTueDinner.Checked)
            {%> 
            <tr><td>Tuesday Dinner:</td><td> <asp:CheckBox ID="ckTueDinner" runat="server" Enabled="False"></asp:CheckBox>  <asp:Label ID="lblTueDinner" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Tuesday Dinner: </td><td>Closed</td></tr>
            <%}%>
   </table>  
   </div>
  
   
   <div class="box">  
   <div> <h5>Wednesday Hours </h5></div>
   <table> 
            <%if (ckWedBreakfast.Checked)
            {%>  
            <tr><td>Wednesday Breakfast:</td><td> <asp:CheckBox ID="ckWedBreakfast" runat="server" Enabled="False" />  <asp:Label ID="lblWedBreakfast" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Wednesday Breakfast: </td><td>Closed</td></tr>
            <%}
                if (ckWedLunch.Checked)
            {%> 
            <tr><td> Wednesday Lunch:</td><td> <asp:CheckBox ID="ckWedLunch" runat="server" Enabled="False"></asp:CheckBox>  <asp:Label ID="lblWedLunch" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Wednesday Lunch: </td><td>Closed</td></tr>
            <%}
            if (ckWedDinner.Checked)
            {%> 
            <tr><td>Wednesday Dinner:</td><td> <asp:CheckBox ID="ckWedDinner" runat="server" Enabled="False"></asp:CheckBox> <asp:Label ID="lblWedDinner" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Wednesday Dinner: </td><td>Closed</td></tr>
            <%}%>
    </table>
   </div>

   
   <div class="box"> 
   <div> <h5>Thursday Hours</h5></div> 
   <table>  
            <%if (ckThrBreakfast.Checked)
            {%> 
            <tr><td>Thursday Breakfast:</td><td>  <asp:CheckBox ID="ckThrBreakfast" runat="server" Enabled="False" /> <asp:Label ID="lblThrBreakfast" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Thursday Breakfast: </td><td>Closed</td></tr>
            <%} 
            if (ckThrLunch.Checked)
            {%> 
            <tr><td>Thursday Lunch:</td><td> <asp:CheckBox ID="ckThrLunch" runat="server" Enabled="False"></asp:CheckBox> <asp:Label ID="lblThrLunch" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Thursday Lunch: </td><td>Closed</td></tr>
            <%} 
            if (ckThrDinner.Checked)
            {%> 
            <tr><td>Thursday Dinner:</td><td> <asp:CheckBox ID="ckThrDinner" runat="server" Enabled="False"></asp:CheckBox> <asp:Label ID="lblThrDinner" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Thursday Lunch: </td><td>Closed</td></tr>
            <%}%>
   </table>
   </div>
    
   
   <div class="box">
   <div> <h5>Friday Hours</h5></div>  
   <table>   
            <% if (ckFriBreakfast.Checked)
            {%> 
            <tr><td>Friday Breakfast:</td><td>  <asp:CheckBox ID="ckFriBreakfast" runat="server" Enabled="False" />  <asp:Label ID="lblFriBreakfast" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Friday Breakfast: </td><td>Closed</td></tr>
            <%} 
            if (ckFriLunch.Checked)
            {%>
            <tr><td>Friday Lunch:</td><td> <asp:CheckBox ID="ckFriLunch" runat="server" Enabled="False"></asp:CheckBox>  <asp:Label ID="lblFriLunch" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Friday Lunch: </td><td>Closed</td></tr>
            <%} 
            if (ckFriDinner.Checked)
            {%>
            <tr><td>Friday Dinner:</td><td> <asp:CheckBox ID="ckFriDinner" runat="server" Enabled="False"></asp:CheckBox> <asp:Label ID="lblFriDinner" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Friday Dinner: </td><td>Closed</td></tr>
            <%} %>
   </table>
   </div>
   
   <div class="box">  
   <div> <h5>Saturday Hours</h5> </div>
   <table>   
            <% if (ckSatBreakfast.Checked)
            {%>
            <tr><td>Saturday Breakfast:</td><td> <asp:CheckBox ID="ckSatBreakfast" runat="server" Enabled="False" /> <asp:Label ID="lblSatBreakfast" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Saturday Breakfast: </td><td>Closed</td></tr>
            <%} 
       
            if (ckSatLunch.Checked)
            {%>
            <tr><td>Saturday Lunch:</td><td><asp:CheckBox ID="ckSatLunch" runat="server" Enabled="False"></asp:CheckBox> <asp:Label ID="lblSatLunch" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Saturday Lunch: </td><td>Closed</td></tr>
            <%}  
            if (ckSatDinner.Checked)
            {%>
            <tr><td>Saturday Dinner:</td><td><asp:CheckBox ID="ckSatDinner" runat="server" Enabled="False"></asp:CheckBox> <asp:Label ID="lblSatDinner" runat="server" Text=""></asp:Label></td></tr>
            <%}
            else
            { %>
            <tr><td>Saturday Dinner: </td><td>Closed</td></tr>
            <%} %>
   </table>
   </div>

   
   <div class="box">  
   <div> <h5>Sunday Hours</h5> </div>
   <table>   
    <%  if (ckSunBreakfast.Checked)
              {%>
       <tr><td>Sunday Breakfast:</td><td> <asp:CheckBox ID="ckSunBreakfast" runat="server" Enabled="False" /> <asp:Label ID="lblSunBreakfast" runat="server" Text=""></asp:Label></td></tr>
            <%}  
            else
            { %>
            <tr><td>Sunday Breakfast: </td><td>Closed</td></tr>
            <%}  
            if (ckSunLunch.Checked)
            {%>
            <tr><td>Sunday Lunch:</td><td><asp:CheckBox ID="ckSunLunch" runat="server" Enabled="False"></asp:CheckBox> <asp:Label ID="lblSunLunch" runat="server" Text=""></asp:Label></td></tr>
            <%} else
            { %>
            <tr><td>Sunday Lunch: </td><td>Closed</td></tr>
            <%} 
            if (ckSunDinner.Checked)
              {%>
            <tr><td>Sunday Dinner:</td><td><asp:CheckBox ID="ckSunDinner" runat="server" Enabled="False"></asp:CheckBox> <asp:Label ID="lblSunDinner" runat="server" Text=""></asp:Label></td></tr>
            <%} else
            { %>
            <tr><td>Sunday Dinner: </td><td>Closed</td></tr>
            <%} %>
   </table>
   </div>
   </div>
   </center>
