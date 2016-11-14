(function (angular) {
    angular
        .module('linkModule')
        .service('linksService', function($http) {
            var service = {
                getAllLinkTypes: getAllLinkTypes,
                changeLinkFavoriteValue: changeLinkFavoriteValue,
                getLinks: getLinks,
                addLink: addLink,
                updateLink: updateLink,
                deleteLink: deleteLink,
                getTitleFromUrl: getTitleFromUrl
            };

            return service;

            function getTitleFromUrl(link) {
                var promise = $http.post("/Link/GetWebSiteTitle", link);
                return promise;
            }

            function getAllLinkTypes() {
                var promise = $http.get("/Link/GetAllLinkTypes");
                return promise;
            }

            function changeLinkFavoriteValue(link) {
                var promise = $http.post("/Link/ChangeLinkFavoriteValue", link);
                return promise;
            };

            function getLinks(ownerId) {
                var promise = $http.get("/Link/GetLinks", ownerId);
                return promise;
            };

            function addLink(link) {
                var promise = $http.post("/Link/AddLink", link);
                return promise;
            };

            function updateLink(link) {
                var promise = $http.post("/Link/UpdateLink", link);
                return promise;
            };

            function deleteLink(link) {
                var promise = $http.post("/Link/DeleteLink", link);
                return promise;
            }
        });
})(angular);