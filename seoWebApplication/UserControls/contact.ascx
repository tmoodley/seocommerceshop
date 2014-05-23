<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contact.ascx.cs" Inherits="seoWebApplication.UserControls.contact" %>
<div class="col21">
      <div class="module secondary">
         <h3>Check Availability</h3> 
            <div class="helper-text float-right"><span>*Required</span></div>
            <label>Comments</label>
            <div class="input">
               <textarea name="comments"></textarea>
            </div>
            <div class="row">
               <div class="col9">
                 <label>First name*</label>
                  <div class="input">
                     <input type="text" name="firstName" class="firstName" value="">
                  </div>
                  <span class="inline-alert invisible"><span>Enter your first name.</span></span>
               </div>
               
               <div class="col9">
                  <label for="lastName">Last name*</label>
                  <div class="input">
                     <input type="text" name="lastName" class="lastName" value="">
                  </div>
                  <span class="inline-alert invisible"><span>Enter your last name.</span></span>
               </div>
               <div class="row-end"></div>
            </div>
            <label for="email">Email*</label>
            <div class="input">
               <input type="email" name="email" class="js-email" value="">
            </div>
            <span class="inline-alert invisible"><span>Enter your email address.</span></span>
            <div class="row">
               <div class="col9">
                  <label for="phone">Phone*</label>
                  <div class="input">
                     <input type="tel" name="phone" class="js-phone" value="">
                  </div>
                  <span class="inline-alert invisible"><span>Enter your phone number.</span></span>
               </div>
                
                 
              </div>
              
              
                <a href="javascript:void(0)" name="&amp;lid=email-the-dealer" class="button float-right submit" onclick="s_objectID=&quot;Check Availability_3&quot;;return this.s_oc?this.s_oc(e):true">Check Availability</a>
              
              <div class="clearfix"></div>
              
            <br>
             
      </div>
      <!-- Module Ends Here -->
   </div>