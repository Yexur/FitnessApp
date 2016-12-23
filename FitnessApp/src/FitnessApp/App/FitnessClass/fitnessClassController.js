(function () {
    'use strict';

    angular
        .module('app')
        .controller('fitnessClassController', fitnessClassController);

    fitnessClassController.$inject = ['$scope']; 

    function fitnessClassController($scope) {
        $scope.title = 'fitnessClassController';

        activate();

        function activate() { }
    }
})();
