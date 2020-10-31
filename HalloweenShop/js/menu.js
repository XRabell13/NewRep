(function($) {
$.fn.menumaker = function(options) {  
  var subenaroun = $(this), settings = $.extend({
  format: "dropdown",
  sticky: false
  }, options);
  return this.each(function() {
  $(this).find(".sponsiveweb").on('click', function(){
  $(this).toggleClass('menu-opened');
  var mainmenu = $(this).next('ul');
  if (mainmenu.hasClass('open')) {  
  mainmenu.slideToggle().removeClass('open');
  }
  else {
  mainmenu.slideToggle().addClass('open');
  if (settings.format === "dropdown") {
  mainmenu.find('ul').show();
  }
  }
  });
  subenaroun.find('li ul').parent().addClass('has-sub');
  
multiTg = function() {
  subenaroun.find(".has-sub").prepend('<span class="submenu-sponsiveweb"></span>');
  subenaroun.find('.submenu-sponsiveweb').on('click', function() {
  $(this).toggleClass('submenu-opened');
 
 if ($(this).siblings('ul').hasClass('open')) {
  $(this).siblings('ul').removeClass('open').slideToggle();
  }
  else {
  $(this).siblings('ul').addClass('open').slideToggle();
  }
  });
  };
  
  if (settings.format === 'multitoggle') multiTg();
  else subenaroun.addClass('dropdown');
  if (settings.sticky === true) subenaroun.css('position', 'fixed');
resizeFix = function() {
  var mediasize = 1000;
  if ($( window ).width() > mediasize) {
  subenaroun.find('ul').show();
  }
  if ($(window).width() <= mediasize) {
  subenaroun.find('ul').hide().removeClass('open');
  }
  };
  
  resizeFix();
  return $(window).on('resize', resizeFix);
  });
  };
})(jQuery);

(function($){
$(document).ready(function(){
$("#subenaroun").menumaker({
  format: "multitoggle"
});
});
})(jQuery);