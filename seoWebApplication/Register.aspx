<%@ Page Language="C#" MasterPageFile="~/default2.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="seoWebApplication.Register" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<center>
<div>
<div id="steps">
<div class="returning-account"> 
<h2>Your Personal Details</h2>
</div>
 
       <div class="login-account">   
       <div class="log-inner"> 
       <div class="register">
       <ul>
  <li><h2>
    <asp:Label class="label" ID="lblErrors" runat="server" Text=""></asp:Label>
   </h2></li>
  
 
<li><h2>
<label for="pName" class="label">First Name<font color='#ff0000'>*</font></label>
    <asp:TextBox ID="txtfname" runat="server" MaxLength="40" CssClass="textBox"></asp:TextBox>
  
</h2></li>
<li><h2> 
<label for="pName" class="label">Last Name<font color='#ff0000'>*</font></label> 
<asp:TextBox ID="txtlname" runat = "server" MaxLength="40" CssClass="textBox"></asp:TextBox>
 
</h2></li>
<li><h2>
<label class="label" for="pName"> Address<font color='#ff0000'>*</font></label>
 <asp:TextBox ID="txtaddress1" runat = "server" MaxLength="40" CssClass="textBox"></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="pName"> Address 2<font color='#ff0000'>*</font></label>
<asp:TextBox ID="txtaddress2" runat = "server" MaxLength="40" CssClass="textBox"></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="pName">City<font color='#ff0000'>*</font></label>
<asp:TextBox ID="txtcity" runat = "server" MaxLength="40" CssClass="textBox"></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="pName">State<font color='#ff0000'>*</font></label>
                               <asp:DropDownList ID="ddlRegion" runat="server" CssClass="stateselect">
                                
								 
								
									<asp:ListItem   value="AL"> 
									Alabama</asp:ListItem>
									
									<asp:ListItem   value="AK"> 
									Alaska</asp:ListItem>
									
									<asp:ListItem   value="AB"> 
									Alberta (Canada)</asp:ListItem>
									
									<asp:ListItem   value="AZ"> 
									Arizona</asp:ListItem>
									
									<asp:ListItem   value="AR"> 
									Arkansas</asp:ListItem>
									
									<asp:ListItem   value="AA"> 
									Armed Forces (the) Americas</asp:ListItem>
									
									<asp:ListItem   value="AE"> 
									Armed Forces Europe</asp:ListItem>
									
									<asp:ListItem   value="AP"> 
									Armed Forces Pacific</asp:ListItem>
									
									<asp:ListItem   value="BC"> 
									British Columbia (Canada)</asp:ListItem>
									
									<asp:ListItem   value="BVI"> 
									British Virgin Islands</asp:ListItem>
									
									<asp:ListItem   value="CA"> 
									California</asp:ListItem>
									
									<asp:ListItem   value="CO"> 
									Colorado</asp:ListItem>
									
									<asp:ListItem   value="CT"> 
									Connecticut</asp:ListItem>
									
									<asp:ListItem   value="DE"> 
									Delaware</asp:ListItem>
									
									<asp:ListItem   value="FL"> 
									Florida</asp:ListItem>
									
									<asp:ListItem   value="GA"> 
									Georgia</asp:ListItem>
									
									<asp:ListItem   value="GU"> 
									Guam</asp:ListItem>
									
									<asp:ListItem   value="HI"> 
									Hawaii</asp:ListItem>
									
									<asp:ListItem   value="ID"> 
									Idaho</asp:ListItem>
									
									<asp:ListItem   value="IL"> 
									Illinois</asp:ListItem>
									
									<asp:ListItem   value="IN"> 
									Indiana</asp:ListItem>
									
									<asp:ListItem   value="IA"> 
									Iowa</asp:ListItem>
									
									<asp:ListItem   value="KS"> 
									Kansas</asp:ListItem>
									
									<asp:ListItem   value="KY"> 
									Kentucky</asp:ListItem>
									
									<asp:ListItem   value="LA"> 
									Louisiana</asp:ListItem>
									
									<asp:ListItem   value="ME"> 
									Maine</asp:ListItem>
									
									<asp:ListItem   value="MB"> 
									Manitoba (Canada)</asp:ListItem>
									
									<asp:ListItem   value="MP"> 
									Mariana Islands</asp:ListItem>
									
									<asp:ListItem   value="MPI"> 
									Mariana Islands (Pacific)</asp:ListItem>
									
									<asp:ListItem   value="MD"> 
									Maryland</asp:ListItem>
									
									<asp:ListItem   value="MA"> 
									Massachusetts</asp:ListItem>
									
									<asp:ListItem   value="MI"> 
									Michigan</asp:ListItem>
									
									<asp:ListItem   value="MN"> 
									Minnesota</asp:ListItem>
									
									<asp:ListItem   value="MS"> 
									Mississippi</asp:ListItem>
									
									<asp:ListItem   value="MO"> 
									Missouri</asp:ListItem>
									
									<asp:ListItem   value="MT"> 
									Montana</asp:ListItem>
									
									<asp:ListItem   value="NE"> 
									Nebraska</asp:ListItem>
									
									<asp:ListItem   value="NV"> 
									Nevada</asp:ListItem>
									
									<asp:ListItem   value="NB"> 
									New Brunswick (Canada)</asp:ListItem>
									
									<asp:ListItem   value="NH"> 
									New Hampshire</asp:ListItem>
									
									<asp:ListItem   value="NJ"> 
									New Jersey</asp:ListItem>
									
									<asp:ListItem   value="NM"> 
									New Mexico</asp:ListItem>
									
									<asp:ListItem   value="NY"> 
									New York</asp:ListItem>
									
									<asp:ListItem   value="NF"> 
									Newfoundland (Canada)</asp:ListItem>
									
									<asp:ListItem   value="NC"> 
									North Carolina</asp:ListItem>
									
									<asp:ListItem   value="ND"> 
									North Dakota</asp:ListItem>
									
									<asp:ListItem   value="NT"> 
									Northwest Territories (Canada)</asp:ListItem>
									
									<asp:ListItem   value="NS"> 
									Nova Scotia (Canada)</asp:ListItem>
									
									<asp:ListItem   value="NU"> 
									Nunavut (Canada)</asp:ListItem>
									
									<asp:ListItem   value="OH"> 
									Ohio</asp:ListItem>
									
									<asp:ListItem   value="OK"> 
									Oklahoma</asp:ListItem>
									
									<asp:ListItem   value="ON"> 
									Ontario (Canada)</asp:ListItem>
									
									<asp:ListItem   value="OR"> 
									Oregon</asp:ListItem>
									
									<asp:ListItem   value="PA"> 
									Pennsylvania</asp:ListItem>
									
									<asp:ListItem   value="PE"> 
									Prince Edward Island (Canada)</asp:ListItem>
									
									<asp:ListItem   value="PR"> 
									Puerto Rico</asp:ListItem>
									
									<asp:ListItem   value="QC"> 
									Quebec (Canada)</asp:ListItem>
									
									<asp:ListItem   value="RI"> 
									Rhode Island</asp:ListItem>
									
									<asp:ListItem   value="SK"> 
									Saskatchewan (Canada)</asp:ListItem>
									
									<asp:ListItem   value="SC"> 
									South Carolina</asp:ListItem>
									
									<asp:ListItem   value="SD"> 
									South Dakota</asp:ListItem>
									
									<asp:ListItem   value="TN"> 
									Tennessee</asp:ListItem>
									
									<asp:ListItem   value="TX"> 
									Texas</asp:ListItem>
									
									<asp:ListItem   value="UT"> 
									Utah</asp:ListItem>
									
									<asp:ListItem   value="VT"> 
									Vermont</asp:ListItem>
									
									<asp:ListItem   value="USVI"> 
									VI U.S. Virgin Islands</asp:ListItem>
									
									<asp:ListItem   value="VA"> 
									Virginia</asp:ListItem>
									
									<asp:ListItem   value="WA"> 
									Washington</asp:ListItem>
									
									<asp:ListItem   value="DC"> 
									Washington, D.C.</asp:ListItem>
									
									<asp:ListItem   value="WV"> 
									West Virginia</asp:ListItem>
									
									<asp:ListItem   value="WI"> 
									Wisconsin</asp:ListItem>
									
									<asp:ListItem   value="WY"> 
									Wyoming</asp:ListItem>
									
									<asp:ListItem   value="YT"> 
									Yukon Territory (Canada)</asp:ListItem>
									
							 
							
                               </asp:DropDownList>
</h2></li>

<li><h2>
<label class="label" for="pName">Zip<font color='#ff0000'>*</font></label>
<asp:TextBox ID="txtzip" runat = "server" CssClass="textBox"></asp:TextBox>
</h2></li>
<li><h2> 
<label class="label" for="Telephone">Country</label>
                                   
<asp:DropDownList ID="ddlCountries" runat="server" CssClass="countryselect">

                                        <asp:ListItem  value="US" >UNITED STATES</asp:ListItem>

										<asp:ListItem  value="UM" >UNITED STATES MINOR OUTLYING ISLANDS</asp:ListItem>

                                        <asp:ListItem  value="AF" >AFGHANISTAN</asp:ListItem>

										<asp:ListItem  value="AL" >ALBANIA</asp:ListItem>

										<asp:ListItem  value="DZ" >ALGERIA</asp:ListItem>

										<asp:ListItem  value="AS" >AMERICAN SAMOA</asp:ListItem>

										<asp:ListItem  value="AD" >ANDORRA</asp:ListItem>

										<asp:ListItem  value="AO" >ANGOLA</asp:ListItem>

										<asp:ListItem  value="AI" >ANGUILLA</asp:ListItem>

										<asp:ListItem  value="AQ" >ANTARCTICA</asp:ListItem>

										<asp:ListItem  value="AG" >ANTIGUA AND BARBUDA</asp:ListItem>

										<asp:ListItem  value="AR" >ARGENTINA</asp:ListItem>

										<asp:ListItem  value="AM" >ARMENIA</asp:ListItem>

										<asp:ListItem  value="AW" >ARUBA</asp:ListItem>

										<asp:ListItem  value="AU" >AUSTRALIA</asp:ListItem>

										<asp:ListItem  value="AT" >AUSTRIA</asp:ListItem>

										<asp:ListItem  value="AZ" >AZERBAIJAN</asp:ListItem>

										<asp:ListItem  value="BS" >BAHAMAS</asp:ListItem>

										<asp:ListItem  value="BH" >BAHRAIN</asp:ListItem>

										<asp:ListItem  value="BD" >BANGLADESH</asp:ListItem>

										<asp:ListItem  value="BB" >BARBADOS</asp:ListItem>

										<asp:ListItem  value="BY" >BELARUS</asp:ListItem>

										<asp:ListItem  value="BE" >BELGIUM</asp:ListItem>

										<asp:ListItem  value="BZ" >BELIZE</asp:ListItem>

										<asp:ListItem  value="BJ" >BENIN</asp:ListItem>

										<asp:ListItem  value="BM" >BERMUDA</asp:ListItem>

										<asp:ListItem  value="BT" >BHUTAN</asp:ListItem>

										<asp:ListItem  value="BO" >BOLIVIA</asp:ListItem>

										<asp:ListItem  value="BA" >BOSNIA HERCEGOVINA</asp:ListItem>

										<asp:ListItem  value="BW" >BOTSWANA</asp:ListItem>

										<asp:ListItem  value="BV" >BOUVET ISLAND</asp:ListItem>

										<asp:ListItem  value="BR" >BRAZIL</asp:ListItem>

										<asp:ListItem  value="IO" >BRITISH INDIAN OCEAN TERRITORY</asp:ListItem>

										<asp:ListItem  value="BN" >BRUNEI DARUSSALAM</asp:ListItem>

										<asp:ListItem  value="BG" >BULGARIA</asp:ListItem>

										<asp:ListItem  value="BF" >BURKINA FASO</asp:ListItem>

										<asp:ListItem  value="BI" >BURUNDI</asp:ListItem>

										<asp:ListItem  value="KH" >CAMBODIA</asp:ListItem>

										<asp:ListItem  value="CM" >CAMEROON</asp:ListItem>

										<asp:ListItem  value="CA" >CANADA</asp:ListItem>

										<asp:ListItem  value="CV" >CAPE VERDE</asp:ListItem>

										<asp:ListItem  value="KY" >CAYMAN ISLANDS</asp:ListItem>

										<asp:ListItem  value="CF" >CENTRAL AFRICAN REPUBLIC</asp:ListItem>

										<asp:ListItem  value="TD" >CHAD</asp:ListItem>

										<asp:ListItem  value="CL" >CHILE</asp:ListItem>

										<asp:ListItem  value="CN" >CHINA</asp:ListItem>

										<asp:ListItem  value="CX" >CHRISTMAS ISLAND</asp:ListItem>

										<asp:ListItem  value="CC" >COCOS (KEELING) ISLANDS</asp:ListItem>

										<asp:ListItem  value="CO" >COLOMBIA</asp:ListItem>

										<asp:ListItem  value="KM" >COMOROS</asp:ListItem>

										<asp:ListItem  value="CG" >CONGO</asp:ListItem>

										<asp:ListItem  value="CK" >COOK ISLANDS</asp:ListItem>

										<asp:ListItem  value="CR" >COSTA RICA</asp:ListItem>

										<asp:ListItem  value="CI" >COTE D'IVOIRE</asp:ListItem>

										<asp:ListItem  value="HR" >CROATIA</asp:ListItem>

										<asp:ListItem  value="CU" >CUBA</asp:ListItem>

										<asp:ListItem  value="CY" >CYPRUS</asp:ListItem>

										<asp:ListItem  value="CZ" >CZECH REPUBLIC</asp:ListItem>

										<asp:ListItem  value="CS" >CZECHOSLOVAKIA</asp:ListItem>

										<asp:ListItem  value="DK" >DENMARK</asp:ListItem>

										<asp:ListItem  value="DJ" >DJIBOUTI</asp:ListItem>

										<asp:ListItem  value="DM" >DOMINICA</asp:ListItem>

										<asp:ListItem  value="DO" >DOMINICAN REPUBLIC</asp:ListItem>

										<asp:ListItem  value="TP" >EAST TIMOR</asp:ListItem>

										<asp:ListItem  value="EC" >ECUADOR</asp:ListItem>

										<asp:ListItem  value="EG" >EGYPT</asp:ListItem>

										<asp:ListItem  value="SV" >EL SALVADOR</asp:ListItem>

										<asp:ListItem  value="GQ" >EQUATORIAL GUINEA</asp:ListItem>

										<asp:ListItem  value="EE" >ESTONIA</asp:ListItem>

										<asp:ListItem  value="ET" >ETHIOPIA</asp:ListItem>

										<asp:ListItem  value="FK" >FALKLAND ISLANDS (MALVINAS)</asp:ListItem>

										<asp:ListItem  value="FO" >FAROE ISLANDS</asp:ListItem>

										<asp:ListItem  value="FJ" >FIJI</asp:ListItem>

										<asp:ListItem  value="FI" >FINLAND</asp:ListItem>

										<asp:ListItem  value="FR" >FRANCE</asp:ListItem>

										<asp:ListItem  value="GF" >FRENCH GUIANA</asp:ListItem>

										<asp:ListItem  value="PF" >FRENCH POLYNESIA</asp:ListItem>

										<asp:ListItem  value="TF" >FRENCH SOUTHERN TERRITORIES</asp:ListItem>

										<asp:ListItem  value="GA" >GABON</asp:ListItem>

										<asp:ListItem  value="GM" >GAMBIA</asp:ListItem>

										<asp:ListItem  value="GE" >GEORGIA</asp:ListItem>

										<asp:ListItem  value="DE" >GERMANY</asp:ListItem>

										<asp:ListItem  value="GH" >GHANA</asp:ListItem>

										<asp:ListItem  value="GI" >GIBRALTAR</asp:ListItem>

										<asp:ListItem  value="GR" >GREECE</asp:ListItem>

										<asp:ListItem  value="GL" >GREENLAND</asp:ListItem>

										<asp:ListItem  value="GD" >GRENADA</asp:ListItem>

										<asp:ListItem  value="GP" >GUADELOUPE</asp:ListItem>

										<asp:ListItem  value="GU" >GUAM</asp:ListItem>

										<asp:ListItem  value="GT" >GUATEMALA</asp:ListItem>

										<asp:ListItem  value="GN" >GUINEA</asp:ListItem>

										<asp:ListItem  value="GW" >GUINEA-BISSAU</asp:ListItem>

										<asp:ListItem  value="GY" >GUYANA</asp:ListItem>

										<asp:ListItem  value="HT" >HAITI</asp:ListItem>

										<asp:ListItem  value="HM" >HEARD AND MC DONALD ISLANDS</asp:ListItem>

										<asp:ListItem  value="HN" >HONDURAS</asp:ListItem>

										<asp:ListItem  value="HK" >HONG KONG</asp:ListItem>

										<asp:ListItem  value="HU" >HUNGARY</asp:ListItem>

										<asp:ListItem  value="IS" >ICELAND</asp:ListItem>

										<asp:ListItem  value="IN" >INDIA</asp:ListItem>

										<asp:ListItem  value="ID" >INDONESIA</asp:ListItem>

										<asp:ListItem  value="IR" >IRAN (ISLAMIC REPUBLIC OF)</asp:ListItem>

										<asp:ListItem  value="IQ" >IRAQ</asp:ListItem>

										<asp:ListItem  value="IE" >IRELAND</asp:ListItem>

										<asp:ListItem  value="IL" >ISRAEL</asp:ListItem>

										<asp:ListItem  value="IT" >ITALY</asp:ListItem>

										<asp:ListItem  value="JM" >JAMAICA</asp:ListItem>

										<asp:ListItem  value="JP" >JAPAN</asp:ListItem>

										<asp:ListItem  value="JO" >JORDAN</asp:ListItem>

										<asp:ListItem  value="KZ" >KAZAKHSTAN</asp:ListItem>

										<asp:ListItem  value="KE" >KENYA</asp:ListItem>

										<asp:ListItem  value="KI" >KIRIBATI</asp:ListItem>

										<asp:ListItem  value="KP" >KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF</asp:ListItem>

										<asp:ListItem  value="KR" >KOREA, REPUBLIC OF</asp:ListItem>

										<asp:ListItem  value="KW" >KUWAIT</asp:ListItem>

										<asp:ListItem  value="KG" >KYRGYZSTAN</asp:ListItem>

										<asp:ListItem  value="LA" >LAO PEOPLE'S DEMOCRATIC REPUBLIC</asp:ListItem>

										<asp:ListItem  value="LV" >LATVIA</asp:ListItem>

										<asp:ListItem  value="LB" >LEBANON</asp:ListItem>

										<asp:ListItem  value="LS" >LESOTHO</asp:ListItem>

										<asp:ListItem  value="LR" >LIBERIA</asp:ListItem>

										<asp:ListItem  value="LY" >LIBYAN ARAB JAMAHIRIYA</asp:ListItem>

										<asp:ListItem  value="LI" >LIECHTENSTEIN</asp:ListItem>

										<asp:ListItem  value="LT" >LITHUANIA</asp:ListItem>

										<asp:ListItem  value="LU" >LUXEMBOURG</asp:ListItem>

										<asp:ListItem  value="MO" >MACAU</asp:ListItem>

										<asp:ListItem  value="MG" >MADAGASCAR</asp:ListItem>

										<asp:ListItem  value="MW" >MALAWI</asp:ListItem>

										<asp:ListItem  value="MY" >MALAYSIA</asp:ListItem>

										<asp:ListItem  value="MV" >MALDIVES</asp:ListItem>

										<asp:ListItem  value="ML" >MALI</asp:ListItem>

										<asp:ListItem  value="MT" >MALTA</asp:ListItem>

										<asp:ListItem  value="MH" >MARSHALL ISLANDS</asp:ListItem>

										<asp:ListItem  value="MQ" >MARTINIQUE</asp:ListItem>

										<asp:ListItem  value="MR" >MAURITANIA</asp:ListItem>

										<asp:ListItem  value="MU" >MAURITIUS</asp:ListItem>

										<asp:ListItem  value="MX" >MEXICO</asp:ListItem>

										<asp:ListItem  value="FM" >MICRONESIA</asp:ListItem>

										<asp:ListItem  value="MD" >MOLDOVA, REPUBLIC OF</asp:ListItem>

										<asp:ListItem  value="MC" >MONACO</asp:ListItem>

										<asp:ListItem  value="MN" >MONGOLIA</asp:ListItem>

										<asp:ListItem  value="MS" >MONTSERRAT</asp:ListItem>

										<asp:ListItem  value="MA" >MOROCCO</asp:ListItem>

										<asp:ListItem  value="MZ" >MOZAMBIQUE</asp:ListItem>

										<asp:ListItem  value="MM" >MYANMAR</asp:ListItem>

										<asp:ListItem  value="NA" >NAMIBIA</asp:ListItem>

										<asp:ListItem  value="NR" >NAURU</asp:ListItem>

										<asp:ListItem  value="NP" >NEPAL</asp:ListItem>

										<asp:ListItem  value="NL" >NETHERLANDS</asp:ListItem>

										<asp:ListItem  value="AN" >NETHERLANDS ANTILLES</asp:ListItem>

										<asp:ListItem  value="NT" >NEUTRAL ZONE</asp:ListItem>

										<asp:ListItem  value="NC" >NEW CALEDONIA</asp:ListItem>

										<asp:ListItem  value="NZ" >NEW ZEALAND</asp:ListItem>

										<asp:ListItem  value="NI" >NICARAGUA</asp:ListItem>

										<asp:ListItem  value="NE" >NIGER</asp:ListItem>

										<asp:ListItem  value="NG" >NIGERIA</asp:ListItem>

										<asp:ListItem  value="NU" >NIUE</asp:ListItem>

										<asp:ListItem  value="NF" >NORFOLK ISLAND</asp:ListItem>

										<asp:ListItem  value="MP" >NORTHERN MARIANA ISLANDS</asp:ListItem>

										<asp:ListItem  value="NO" >NORWAY</asp:ListItem>

										<asp:ListItem  value="OM" >OMAN</asp:ListItem>

										<asp:ListItem  value="PK" >PAKISTAN</asp:ListItem>

										<asp:ListItem  value="PW" >PALAU</asp:ListItem>

										<asp:ListItem  value="PA" >PANAMA</asp:ListItem>

										<asp:ListItem  value="PG" >PAPUA NEW GUINEA</asp:ListItem>

										<asp:ListItem  value="PY" >PARAGUAY</asp:ListItem>

										<asp:ListItem  value="PE" >PERU</asp:ListItem>

										<asp:ListItem  value="PH" >PHILIPPINES</asp:ListItem>

										<asp:ListItem  value="PN" >PITCAIRN</asp:ListItem>

										<asp:ListItem  value="PL" >POLAND</asp:ListItem>

										<asp:ListItem  value="PT" >PORTUGAL</asp:ListItem>

										<asp:ListItem  value="PR" >PUERTO RICO</asp:ListItem>

										<asp:ListItem  value="QA" >QATAR</asp:ListItem>

										<asp:ListItem  value="RE" >REUNION</asp:ListItem>

										<asp:ListItem  value="RO" >ROMANIA</asp:ListItem>

										<asp:ListItem  value="RU" >RUSSIAN FEDERATION</asp:ListItem>

										<asp:ListItem  value="RW" >RWANDA</asp:ListItem>

										<asp:ListItem  value="KN" >SAINT KITTS AND NEVIS</asp:ListItem>

										<asp:ListItem  value="LC" >SAINT LUCIA</asp:ListItem>

										<asp:ListItem  value="VC" >SAINT VINCENT AND THE GRENADINES</asp:ListItem>

										<asp:ListItem  value="WS" >SAMOA</asp:ListItem>

										<asp:ListItem  value="SM" >SAN MARINO</asp:ListItem>

										<asp:ListItem  value="ST" >SAO TOME AND PRINCIPE</asp:ListItem>

										<asp:ListItem  value="SA" >SAUDI ARABIA</asp:ListItem>

										<asp:ListItem  value="SN" >SENEGAL</asp:ListItem>

										<asp:ListItem  value="SC" >SEYCHELLES</asp:ListItem>

										<asp:ListItem  value="SL" >SIERRA LEONE</asp:ListItem>

										<asp:ListItem  value="SG" >SINGAPORE</asp:ListItem>

										<asp:ListItem  value="SK" >SLOVAKIA</asp:ListItem>

										<asp:ListItem  value="SI" >SLOVENIA</asp:ListItem>

										<asp:ListItem  value="SB" >SOLOMON ISLANDS</asp:ListItem>

										<asp:ListItem  value="SO" >SOMALIA</asp:ListItem>

										<asp:ListItem  value="ZA" >SOUTH AFRICA</asp:ListItem>

										<asp:ListItem  value="ES" >SPAIN</asp:ListItem>

										<asp:ListItem  value="LK" >SRI LANKA</asp:ListItem>

										<asp:ListItem  value="SH" >ST. HELENA</asp:ListItem>

										<asp:ListItem  value="PM" >ST. PIERRE AND MIQUELON</asp:ListItem>

										<asp:ListItem  value="SD" >SUDAN</asp:ListItem>

										<asp:ListItem  value="SR" >SURINAME</asp:ListItem>

										<asp:ListItem  value="SJ" >SVALBARD AND JAN MAYEN ISLANDS</asp:ListItem>

										<asp:ListItem  value="SZ" >SWAZILAND</asp:ListItem>

										<asp:ListItem  value="SE" >SWEDEN</asp:ListItem>

										<asp:ListItem  value="CH" >SWITZERLAND</asp:ListItem>

										<asp:ListItem  value="SY" >SYRIAN ARAB REPUBLIC</asp:ListItem>

										<asp:ListItem  value="TW" >TAIWAN, PROVINCE OF CHINA</asp:ListItem>

										<asp:ListItem  value="TJ" >TAJIKISTAN</asp:ListItem>

										<asp:ListItem  value="TZ" >TANZANIA, UNITED REPUBLIC OF</asp:ListItem>

										<asp:ListItem  value="TH" >THAILAND</asp:ListItem>

										<asp:ListItem  value="TG" >TOGO</asp:ListItem>

										<asp:ListItem  value="TK" >TOKELAU</asp:ListItem>

										<asp:ListItem  value="TO" >TONGA</asp:ListItem>

										<asp:ListItem  value="TT" >TRINIDAD AND TOBAGO</asp:ListItem>

										<asp:ListItem  value="TN" >TUNISIA</asp:ListItem>

										<asp:ListItem  value="TR" >TURKEY</asp:ListItem>

										<asp:ListItem  value="TM" >TURKMENISTAN</asp:ListItem>

										<asp:ListItem  value="TC" >TURKS AND CAICOS ISLANDS</asp:ListItem>

										<asp:ListItem  value="TV" >TUVALU</asp:ListItem>

										<asp:ListItem  value="UG" >UGANDA</asp:ListItem>

										<asp:ListItem  value="UA" >UKRAINE</asp:ListItem>

										<asp:ListItem  value="AE" >UNITED ARAB EMIRATES</asp:ListItem>

										<asp:ListItem  value="GB" >UNITED KINGDOM</asp:ListItem>										

										<asp:ListItem  value="UY" >URUGUAY</asp:ListItem>

										<asp:ListItem  value="SU" >USSR</asp:ListItem>

										<asp:ListItem  value="UZ" >UZBEKISTAN</asp:ListItem>

										<asp:ListItem  value="VU" >VANUATU</asp:ListItem>

										<asp:ListItem  value="VA" >VATICAN CITY STATE (HOLY SEE)</asp:ListItem>

										<asp:ListItem  value="VE" >VENEZUELA</asp:ListItem>

										<asp:ListItem  value="VN" >VIET NAM</asp:ListItem>

										<asp:ListItem  value="VG" >VIRGIN ISLANDS (BRITISH)</asp:ListItem>

										<asp:ListItem  value="VI" >VIRGIN ISLANDS (U.S.)</asp:ListItem>

										<asp:ListItem  value="WF" >WALLIS AND FUTUNA ISLANDS</asp:ListItem>

										<asp:ListItem  value="EH" >WESTERN SAHARA</asp:ListItem>

										<asp:ListItem  value="YE" >YEMEN, REPUBLIC OF</asp:ListItem>

										<asp:ListItem  value="YU" >YUGOSLAVIA</asp:ListItem>

										<asp:ListItem  value="ZR" >ZAIRE</asp:ListItem>

										<asp:ListItem  value="ZM" >ZAMBIA</asp:ListItem>

										<asp:ListItem  value="ZW" >ZIMBABWE</asp:ListItem>
                                      </asp:DropDownList>
 
</h2></li>
<li><h2>
<label class="label" for="Telephone">Telephone</label>
<asp:TextBox ID="txtdayPhone" runat = "server" MaxLength="40" CssClass="textBox" ></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="Telephone">Eve phone</label>                                   
<asp:TextBox ID="txtevePhone" runat = "server" MaxLength="40" CssClass="textBox" ></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="Telephone">Cell phone</label>                                   
<asp:TextBox ID="txtcellPhone" runat = "server"  MaxLength="40" CssClass="textBox"></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="Telephone">Email</label>                                   
<asp:TextBox ID="txtemail" runat = "server" MaxLength="40" CssClass="textBox"></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="Telephone">Re-enter Email</label>                                   
<asp:TextBox ID="txtusername" runat = "server" MaxLength="40" CssClass="textBox"></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="Telephone">Password</label>
<asp:TextBox ID="txtpassword" runat = "server" MaxLength="40" CssClass="textBox"></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="Telephone">Re-enter Password</label>
<asp:TextBox ID="txtpassword0" runat = "server" MaxLength="40" CssClass="textBox"></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="Telephone">Secret Question</label>
<asp:DropDownList ID="ddlSecret" runat="server" CssClass="countryselect">
                                                                                        <asp:ListItem   value="What is your school's mascot?">What is your school's mascot?</asp:ListItem>
                                            <asp:ListItem   value="What is the name of your favorite pet?">What is the name of your favorite pet?</asp:ListItem>
                                            <asp:ListItem   value="In what city were you born?">In what city were you born?</asp:ListItem>
                                            <asp:ListItem   value="What high school did you attend?">What high school did you attend?</asp:ListItem>
                                            <asp:ListItem   value="What is your favorite movie?">What is your favorite movie?</asp:ListItem>
                                            <asp:ListItem   value="What is your mother's maiden name?">What is your mother's maiden name?</asp:ListItem>
                                            <asp:ListItem   value="What street did you grow up on?">What street did you grow up on?</asp:ListItem>
                                            <asp:ListItem   value="What was the make of your first car?">What was the make of your first car?</asp:ListItem>
                                            <asp:ListItem   value="When is your anniversary?">When is your anniversary?</asp:ListItem>
                                            <asp:ListItem   value="What is your favorite color?">What is your favorite color?</asp:ListItem>
                                            <asp:ListItem   value="What was your favorite place to visit as a child?">What was your favorite place to visit as a child?</asp:ListItem>
                                            </asp:DropDownList>
</h2></li>
<li><h2>
<label class="label" for="pName">Secret Answer</label>
    <asp:TextBox 
    ID="txtSecretAnswer" runat="server" Width="294px" Height="50px" 
    TextMode="MultiLine" CssClass="countryselect"></asp:TextBox>
</h2></li>
<li><h2>
<label class="label" for="Telephone">	Would you like to join our Monthly Mailing list for discounts and promotions?:<asp:CheckBox ID="chkSendMail" runat="server" Checked="True" />*</label>                                   
</h2></li>
<li><h2>
 <asp:Button ID="Button1" runat="server" class="button"  Text="Continue &gt;&gt;" 
        onclick="SaveButton_Click" />
</h2></li>
</ul>     
</div>  
</div>       
                        
  </div>
  </div>

  </div>
</center>


 
 
</asp:Content>

