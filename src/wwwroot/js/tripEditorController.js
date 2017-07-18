//Getting existing module
(function() {
  "use strict";
  angular.module("app-trips")
    .controller("tripEditorController", tripEditorController);

  function tripEditorController($routeParams, $http) {
    var vm = this;

    vm.isBusy = true;
    vm.stops = [];
    vm.errorMessage = "";
    vm.tripName = $routeParams.tripName;

    $http.get("/api/trips/" + vm.tripName + "/stops")
      .then(function(response) {
        angular.copy(response.data, vm.stops);
        _showMap(vm.stops);
      }, function(err) {
        vm.errorMessage = "Failed to load stops";
      })
      .finally(function() {
        vm.isBusy = false;
      });
  }

  function _showMap(stops) {
    if (stops && stops.length > 0) {
      var mapStops = _.map(stops, function(item) {
        return {
          lat: item.latitude,
          long: item.longitude,
          info: item.name
        };
      });
      travelMap.createMap({
        stops: mapStops,
        selector: "#map",
        currentStop: 1,
        initialZoom: 3
      });
    };
  }
})();
