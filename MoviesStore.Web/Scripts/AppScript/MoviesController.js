app.controller("moviesCtrl", function ($http, $scope, $uibModal) {
    $scope.movie = "GADAR";
    $scope.Actors = [];
    $scope.Producers = [];
    $scope.SelectedProducer = null;
    $scope.names = ["john", "bill", "charlie", "robert", "alban", "oscar", "marie", "celine", "brad", "drew", "rebecca", "michel", "francis", "jean", "paul", "pierre", "nicolas", "alfred", "gerard", "louis", "albert", "edouard", "benoit", "guillaume", "nicolas", "joseph"];
    $scope.addNewMovie = function () {
        $uibModal.open({
            templateUrl: "/Movie/AddMovie",
            controller: "moviesCtrl"
        });
    }; 

    $scope.addNewProducer = function () {
        $uibModal.open({
            templateUrl: "/Producer/AddProducer",
            controller: "moviesCtrl"
        });
    }; 

    //After select country event
    $scope.afterSelectedActor = function (selected) {
        if (selected) {
            $scope.SelectedActor = selected.originalObject;
        }
    }
    //After select country event
    $scope.afterSelectedProducer = function (selected) {
        if (selected) {
            $scope.SelectedProducer = selected.originalObject;
        }
    }


    //Populate data from database 
    $http({
        method: 'GET',
        url: '/Actor/GetAllActors'
    }).then(function (data) {
        $scope.Actors = data.data;
    }, function () {
        alert('Error');
    });

    $http({
        method: 'GET',
        url: '/Producer/GetAllProducers'
    }).then(function (data) {
        $scope.Producers = data.data;
    }, function () {
        alert('Error');
    });

});


