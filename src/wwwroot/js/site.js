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
  $("#sidebarToggle").on("click", function () {
    $sidebarAndWrapper.toggleClass("hide-sidebar");
    $sidebarAndWrapper.hasClass("hide-sidebar") ? $(this).text("Show Sidebar") : $(this).text("Hide Sidebar");
  });
})();
