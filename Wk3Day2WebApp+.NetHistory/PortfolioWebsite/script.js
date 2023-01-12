// Add your custom JavaScript here

// Toggle the navbar dropdown on click
$('.navbar-toggler').click(function() {
    $('.navbar-collapse').toggle();
  });
  
  // Close the navbar dropdown when a navlink is clicked
  $('.nav-item').click(function() {
    $('.navbar-collapse').hide();
  });
  
  // Add a smooth scroll effect to the navlinks
  $('a[href*="#"]').click(function() {
    // Add smooth scroll effect
    $('html, body').animate({
      scrollTop: $($(this).attr('href')).offset().top
    }, 1000);
  });
  
  // Add a fade-in effect for the intro section
  $(document).ready(function() {
    $('#intro').css('opacity', 0).animate({opacity: 1}, 2000);
  });
  