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
    vm.newStop = {};

    vm.tripUrl = "/api/trips/" + vm.tripName + "/stops";

    $http.get(vm.tripUrl)
      .then(function(response) {
        angular.copy(response.data, vm.stops);
        _showMap(vm.stops);
      }, function(err) {
        vm.errorMessage = "Failed to load stops";
      })
      .finally(function() {
        vm.isBusy = false;
      });

    vm.addStop = function() {
      vm.isBusy = true;

      $http.post(vm.tripUrl + "/add", vm.newStop)
        .then(function(response) {
          vm.stops.push(response.data);
          _showMap(vm.stops);
          vm.newStop = {};
        }, function(err) {
          vm.errorMessage = "Failed to add new stop";
        })
        .finally(function() {
          vm.isBUsy = false;
        });
    }
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
