 //Mobile Menu
$(document).ready(function(){
    
    if($(window).outerWidth() <= 711 ){
        $('.mobile-menu').slideUp('slow');
    }
    
    $('#mobile-icon').click(function(){
        $('.mobile-menu').slideToggle('slow');
    });
    
    if($(window).outerWidth() <= 711 ){
        $('.mobile-menu li a').click(function(){
            $('.mobile-menu').slideUp('slow');
        });
        
    }
     
});

//Owl Carousel

$(document).ready(function() {
 
  $("#owl-demo").owlCarousel({
 
      navigation : true, // Show next and prev buttons
      slideSpeed : 300,
      paginationSpeed : 400,
      singleItem:true,
      autoPlay:true,
      stopOnHover:true,
      pagination:false,
      navigationText:['','']

  });
    
    $('.owl-next').append('<span class="fa fa-angle-right"></span>');
    $('.owl-prev').append('<span class="fa fa-angle-left"></span>');
    
});



 