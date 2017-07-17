(function () {
  "use strict";

  //Getting existing module
  angular.module("app-trips")
    .controller("tripsController", tripController);

  function tripController() {
    var vm = this;

    vm.name = "Shawn Wildermuth";

    vm.trips = [{
      name: "US Trip",
      created: Date.now()
    }, {
      name: "World Trip",
      created: Date.now()
    }];

    vm.newTrip = {};

    vm.addTrip = function () {
      vm.trips.push({
        name: vm.newTrip.name,
        created: new Date()
      });
      vm.newTrip = {};
    };
  };
})();
