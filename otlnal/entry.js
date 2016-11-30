var otnalApp = angular.module('otnalApp', []);

otnalApp.service('productService', ['$http', '$q', function($http, $q) {

    var urlBase = '/api/product';

    this.getProducts = function() {
        var deferred = $q.defer();
        $http.get(urlBase).success(function(response) {
            deferred.resolve(response);
        }).error(function(err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    };

    this.postProduct = function(product) {
        var deferred = $q.defer();
        $http.post(urlBase, product).success(function(response) {
            deferred.resolve(response);
        }).error(function(err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    };

    this.getProductTypes = function() {
        var deferred = $q.defer();
        $http.get(urlBase + '/types').success(function(response) {
            deferred.resolve(response);
        }).error(function(err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    };
}]);

otnalApp.controller('OtnalController', function OtnalController($scope, productService) {

    productService.getProducts().then(function(response) {
        response.forEach(function(item) {
            item.isEdit = false;
        });
        $scope.products = response;
    }, function(err) {
        $scope.error = err;
    });

    productService.getProductTypes().then(function(response) {
        $scope.types = response;
    });

    $scope.save = function(product) {
        productService.postProduct(product).then(function(response) {
            $scope.error = null;
            product.isEdit = false;
        }, function(err) {
            $scope.error = err;
        });
    }

    $scope.changeType=function (product) {
      
    }
});
