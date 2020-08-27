// Main Nav Mobile
$(function(){
    $(".btn-menu").click(function(e){
        e.preventDefault();
        $('body').addClass("nav-open");
    });
    $(".close-nav").click(function(e){
        e.preventDefault();
        $('body').removeClass("nav-open");
    });
});
$(function(){
    $(".right-panel__btn").click(function(){
        if($('body').hasClass("nav-open-rp")){
            $('body').removeClass("nav-open-rp")
        }
        else{
            $('body').addClass("nav-open-rp");
        }
    });
    $(".close-nav-rp").click(function(e){
        e.preventDefault();
        $('body').removeClass("nav-open-rp");
    });
});
$(function(){
    $(".close-lb").click(function(){
        $('.main-layout__left').toggleClass("collapsed");
        var $this = $(this);
        $this.toggleClass('on-change');
        if($this.hasClass('on-change')){
            $this.html('&#x21E5;'); 
        } else {
            $this.html('&#x21E4;');
        }
    });
});
$(document).ready(function(){
    $(".menu-item").click(function(){
    $(this).addClass("list")
    $(this).find(".menu-list").slideToggle();
   });
 });
 $(document).ready(function() {
    $("#notification_auto").fancybox().trigger('click');
});
