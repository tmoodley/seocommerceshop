// ---------------------------------------------------------
// Cufon Replacement
// ---------------------------------------------------------
Cufon.replace('h1, h2, .error404-num', { fontFamily: 'Bebas'}); 
Cufon.replace('.logo .tagline', { fontFamily: 'James Fajardo'});
Cufon.replace('.logo h1, .logo h2', { fontFamily: 'James Fajardo', textShadow: '3px 0 rgba(0, 0, 0, .15)', });
Cufon.replace('.sf-menu a, h3', {
    fontFamily: 'Bebas', 
    hover:true,
    fontSize: '12px' 
});



 

 

$(document).ready(function(){
													 
// ---------------------------------------------------------
// Tabs
// ---------------------------------------------------------
$(".tabs").each(function(){

		$(this).find(".tab").hide();
		$(this).find(".tab-menu li:first a").addClass("active").show();
		$(this).find(".tab:first").show();

});

$(".tabs").each(function(){

		$(this).find(".tab-menu a").click(function() {

				$(this).parent().parent().find("a").removeClass("active");
				$(this).addClass("active");
				$(this).parent().parent().parent().parent().find(".tab").hide();
				var activeTab = $(this).attr("href");
				$(activeTab).fadeIn();
				return false;

		});

});


// ---------------------------------------------------------
// Toggle
// ---------------------------------------------------------

$(".toggle").each(function(){

		$(this).find(".box").hide();

});

$(".toggle").each(function(){

		$(this).find(".trigger").click(function() {

				$(this).toggleClass("active").next().stop(true, true).slideToggle("normal");

				return false;

		});

});



// ---------------------------------------------------------
// Social Icons
// ---------------------------------------------------------

jQuery(".tooltip").tooltip({ effect: 'slide', position: 'bottom center', opacity: .5 });


});