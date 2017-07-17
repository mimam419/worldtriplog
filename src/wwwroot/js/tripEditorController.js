"use strict";

//Getting existing module
(function() {
  angular.module("app-trips").controller("tripEditorController", ["$http", tripEditorController]);

  function tripEditorController($http) {
    var vm = this;
  }
})();
