app.controller("customerSearchController", ['$scope', 'customerSearchService', function ($scope, customerSearchService) {


    $scope.$watch('searchTerm', function () {
        $scope.customers = [];
        $scope.resultCount = 0;
        $scope.pages = [];

        $scope.changePage = function(page){
            var searchRequestData = {
                searchTerm: $scope.searchTerm,
                pageSize: 20,
                pageNumber: page,
            };

            customerSearchService.search(searchRequestData)
                .then(function (response) {
                    $scope.customers = response.data.results;
                    $scope.resultCount = response.data.resultCount;

                    console.log(response.data);
                });
        }

        if ($scope.searchTerm && $scope.searchTerm.length >= 3) {
  
            var searchRequestData = {
                searchTerm: $scope.searchTerm,
                pageSize: 20,
                pageNumber: 1,
            };

            customerSearchService.search(searchRequestData)
                .then(function (response) {
                    $scope.customers = response.data.results;
                    $scope.resultCount = response.data.resultCount;

                    for (var i = 0; i < response.data.pageCount; i++) {
                        $scope.pages.push(i + 1);
                    }
                    console.log(response.data);
                });
        }
    });
}]);