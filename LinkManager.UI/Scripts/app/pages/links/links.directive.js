(function () {
    var app = angular.module('linkModule');

    app.directive('linkType', function () {
        return {
            restrict: 'E',
            templateUrl: '/AngularViews/Link/LinkType.html'
        };
    });

    app.directive('linkFavoriteValue', function () {
        return {
            restrict: 'E',
            templateUrl: '/AngularViews/Link/LinkFavoriteValue.html'
        };
    });

    app.directive('linkTypeSelector', function () {
        return {
            restrict: 'E',
            templateUrl: '/AngularViews/Link/LinkTypeSelector.html'
        };
    });

    app.directive('linkUpdateModal', function () {
        return {
            restrict: 'E',
            templateUrl: '/AngularViews/Link/LinkUpdateModal.html',
            controller: function () {
                // Get the modal
                this.updateLinkModal = document.getElementById('updateLinkModal');

                this.closeUpdateLinkModal = function () {
                    updateLinkModal.style.display = "none";
                }

                // When the user clicks anywhere outside of the updateLinkModal, close it
                window.onclick = function (event) {
                    if (event.target == updateLinkModal) {
                        updateLinkModal.style.display = "none";
                    }
                }
        },
        controllerAs: 'updateLinkModal'
        };
    });

})();