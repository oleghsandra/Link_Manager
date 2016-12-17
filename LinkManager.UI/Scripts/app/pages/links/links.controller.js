(function (angular) {
    var linkModule = angular
        .module("linkModule")
        .controller('LinkController', ['linksService', function (linksService) {
            var vm = this;
            vm.newLinkValid = false;
            vm.addingProcces = false;
            vm.linkTypes = [];
            vm.links = [];
            vm.ownerId = 1;
            vm.onlyLiked = false;
            vm.titleFilter = '';
            vm.typeIdFilter = 1;
            vm.today = new Date();

            vm.newLink = new Link();

            vm.newLinkTypeId = 2;

            vm.newLinkValid = new Link();
            vm.updateLinkTypeId = 0;
            vm.titleLoadingSpinAvailable = false;

            vm.updateLink = {};
            vm.updateLinkTypeId = 0;
            
            activate();

            function activate() {
                var linkTypesPromise = linksService.getAllLinkTypes();
                linkTypesPromise.then(function (response) {
                    vm.linkTypes.push.apply(vm.linkTypes, response.data);
                }, errorWarning);

                var linksPromise = linksService.getLinks(vm.ownerId);
                linksPromise.then(function (response) {
                    vm.links.push.apply(vm.links, response.data);
                    for (var i = 0; i < vm.links.length; i++) {
                        vm.links[i].CreationDate = getDateFromDotNetOne(vm.links[i].CreationDate);
                    }
                }, errorWarning);
            };

            vm.updateNewModelParams = function () {
                console.log(vm.newLinkTypeId);
                vm.newLink.Type.Id = vm.newLinkTypeId;
            }

            vm.changeFavoriteValue = function(link) {
                var promise = linksService.changeLinkFavoriteValue(link);
                promise.then(function(response) {
                    link.IsFavorite = !link.IsFavorite;
                }, errorWarning);
            };

            vm.addNewLink = function () {
                if (vm.newLink.Type.Id == undefined) {
                    alert("Select type!");
                    return;
                }

                vm.addingProcces = true;

                var titleGetpromise = linksService.getTitleFromUrl(vm.newLink);
                titleGetpromise.then(function (response) {
                    vm.newLink.Title = response.data;
                    vm.newLinkValid = response.data !== '';

                    if (vm.newLink.Title === '') {
                        alert("Incorrect Url!");
                        vm.addingProcces = false;
                        return;
                    }
                    var linkClone = getLinkInstanseCopy(vm.newLink);

                    linkClone.IsFavorite = false;
                    linkClone.OwnerId = vm.ownerId;

                    linkClone.Type.Id = vm.newLinkTypeId;
                    linkClone.Type.Name = getLinkTypeNameById(linkClone.Type.Id);

                    var promise = linksService.addLink(linkClone);
                    promise.then(function (response) {
                        //Todo: Fix it! Do without reloading page.
                        location.reload();
                    }, errorWarning);
                }, errorWarning);
            }

            vm.setToUpdateLink = function (link) {
                updateLinkModal.style.display = "block";
                console.log(link);
                vm.updateLink = getLinkInstanseCopy(link);
                vm.updateLinkTypeId = link.Type.Id;
            };

            vm.updateLinks = function () {
                console.log(vm.updateLink);
                vm.updateLink.Type.Id = vm.updateLinkTypeId;

                var promise = linksService.updateLink(vm.updateLink);
                promise.then(function (response) {
                    //Fix it, becouse it is hard to test reloading...
                     location.reload();
                }, errorWarning);
            };

            vm.deleteLink = function (link) {
                var promise = linksService.deleteLink(link);
                promise.then(function (response) {
                    for (var i = 0; i < vm.links.length; i++) {
                        if (vm.links[i].Id === link.Id) {
                            vm.links.splice(i, 1);
                        }
                    }
                }, errorWarning);
            }

            function getLinkTypeNameById(id) {
                for (var i = 0; i < vm.linkTypes.length; i++) {
                    if (vm.linkTypes[i].Id == id) {
                        return vm.linkTypes[i].Name;
                    }
                }
                return -1;
            }

            function errorWarning() {
                alert("Something went wrong...");
            }

            //dotNetDateModel = /Date(xxx)/
            function getDateFromDotNetOne(dotNetDateModel) {
                var totalMilliseconds = 0;
                //dotNetModelWithoutPrefix = xxx)/
                var dotNetModelWithoutPrefix = dotNetDateModel.replace('/Date(', '');
                //totalMilliseconds = xxx
                totalMilliseconds = parseInt(dotNetModelWithoutPrefix);
                return new Date(totalMilliseconds);
            }

            function getLinkInstanseCopy(link) {
                var linkClone = {};
                var linkTypeClone = {};

                for (var key in link) {
                    linkClone[key] = link[key];
                }
                for (var key in link.Type) {
                    linkTypeClone[key] = link.Type[key];
                }

                linkClone.Type = linkTypeClone;

                return linkClone;
            }

            function Link() {
                this.Title = '';
                this.Type = {};
                this.Url = '';
            }
        }]);
})(angular);