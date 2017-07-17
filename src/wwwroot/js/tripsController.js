"use strict";

//Getting existing module
app.controller("tripsController", function($scope, $http) {
  var vm = this;

  vm.loading = true;

  $http.get(hostUrl + "/trips").then(function(response) {
    vm.trips = response.data;
    vm.loading = false;
  })

  vm.newTrip = {};

  vm.addTrip = function() {
    vm.trips.push({
      name: vm.newTrip.name,
      dateCreated: new Date()
    });
    vm.newTrip = {};
  };
});
