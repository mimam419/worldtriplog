"use strict";

//Getting existing module
(function() {
  angular.module("app-trips").controller("tripsController", ["$http", tripsController]);

  function tripsController($http) {
    var vm = this;

    vm.loading = true;

    $http.get(hostUrl + "/trips").then(function(response) {
      vm.trips = response.data;
      vm.loading = false;
      console.log(response);
    });

    vm.newTrip = {};

    vm.addTrip = function() {
      vm.newTrip.dateCreated = new Date();
      $http.post(hostUrl + "/trips/add", vm.newTrip).then(function(response) {
        if (response.status = 200) {
          vm.trips.push(vm.newTrip);
          vm.newTrip = {};
        }
      });
    };
  };
})();
