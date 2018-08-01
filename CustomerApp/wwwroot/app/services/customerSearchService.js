app.factory('customerSearchService', function ($http) {

    var urlBase = 'api/customer/search';
    var dataFactory = {};

    dataFactory.search = function (searchRequest) {
        return $http.post(urlBase, searchRequest);
    }

    return dataFactory;
});