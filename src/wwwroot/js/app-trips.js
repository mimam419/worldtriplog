  //Creating a module
  (function() {
    "use strict";

    angular.module("app-trips", ["ngRoute"])
      .config(function($routeProvider) {
        $routeProvider.when("/", {
          controller: "tripsController",
          controllerAs: "vm",
          templateUrl: "../views/tripsView.html"
        });

        $routeProvider.when("/editor", {
          controller: "tripEditorController",
          controllerAs: "vm",
          templateUrl: "../views/tripEditorView.html"
        });

        $routeProvider.otherwise({
          redirectTo: "/"
        });
      });
  })();
