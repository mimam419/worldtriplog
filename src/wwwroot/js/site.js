(function () {
  // var ele = $("#username");
  // ele.text("Shawn Wildermuth");

  // var main = $("#main");
  // main.on("mouseenter", function () {
  //   main.style = "background-color: #888;";
  // });

  // main.on("mouseleave", function () {
  //   main.style = '';
  // });

  // var menuItems = $("ul.menu li a");
  // menuItems.on("click", function () {
  //   alert("He is leaving " + $(this).text());
  // })
  var $sidebarAndWrapper = $("#sidebar,#wrapper");
  var $sidebarIcon = $("#sidebarToggle i.fa");

  $("#sidebarToggle").on("click", function () {
    $sidebarAndWrapper.toggleClass("hide-sidebar");
    if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
      $sidebarIcon.removeClass("fa-angle-left");
      $sidebarIcon.addClass("fa-angle-right");
    } else {
      $sidebarIcon.addClass("fa-angle-left");
      $sidebarIcon.removeClass("fa-angle-right");
    }
  });
})();
