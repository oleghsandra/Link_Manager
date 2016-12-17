/// <reference path="../libs/angular.js" />
/// <reference path="../libs/angular-mocks.js" />
/// <reference path="../jasmine/jasmine.js" />
/// <reference path="../app/pages/links/links.module.js" />
/// <reference path="../app/pages/links/links.controller.js" />
/// <reference path="../app/pages/links/links.service.js" />

describe("Link Manager Tests", function () {

    var linkManagerFactory, httpBackend, LinkController, $controller;
    var mockLinks = [
            { Id: 1, Url: 'https://www.vk.com/', CreationDate: '15 December 2016' },
            { Id: 2, Url: 'https://www.google.com.ua/', CreationDate: '16 December 2016', Type: { Id: 2, Name: 'Study' }},
            { Id: 3, Url: 'https://cloudinary.com/users/login', CreationDate: '01 June 2014' },
            { Id: 4, Url: 'https://www.youtube.com', CreationDate: '02 December 2016' }
    ];
    var mockLinkTypes = [
           { Id: 1, Name: 'Study' },
           { Id: 2, Name: 'Sport' },
           { Id: 3, Name: 'Cooking' }
    ];

    beforeEach(module('linkModule'));

    afterEach(function () {
        httpBackend.verifyNoOutstandingExpectation();
        httpBackend.verifyNoOutstandingRequest();
    });

    beforeEach(inject(function ($httpBackend, linksService, _$controller_) {
        $controller = _$controller_
        httpBackend = $httpBackend;
        linkManagerFactory = linksService;

        httpBackend
            .expectGET('/Link/GetAllLinkTypes')
            .respond(200, mockLinkTypes);

        httpBackend
            .expectGET('/Link/GetLinks')
            .respond(200, mockLinks);


        linkController = $controller('LinkController', {});

        httpBackend.flush();
    }));

    it('Get link types', function () {
        expect(linkController.linkTypes.length).toBe(3);
    });

    it('Get links', function () {
        expect(linkController.links.length).toBe(4);
    });

    it('Add link', function () {
        var newLink = { Id: 5, Title: 'https://www.testurl.com/', Date: '12 December 2016' };
        var responseLink = null;

        httpBackend
            .expectPOST('/Link/AddLink', newLink)
            .respond(200, newLink);

        linkManagerFactory.addLink(newLink).then(function (response) {
            responseLink = response.data;
        });

        httpBackend.flush();

        expect(newLink).toEqual(responseLink);
    });
    
    it('Update link', function () {
        linkController.updateLinkTypeId = 1;
        var index = 1;
        linkController.updateLink =  { Id: 2, Url: 'https://www.google.com.ua/', CreationDate: '16 December 2016', Type: { Id: 2, Name: 'Study' }};
        var newUrl = "TestUrl";
        linkController.updateLink.Url = newUrl;

        httpBackend
            .expectPOST("/Link/UpdateLink", linkController.updateLink)
            .respond(200, '');

        //TODO: Fix it, becouse location.reload code is available in controller
        linkController.updateLinks();

        httpBackend.flush();

        expect(linkController.updateLink.Url.toString()).toEqual(newUrl.toString());
    });

    it('Delete link', function () {
        var linkToDelete = { Id: 1, Url: 'https://www.vk.com/', CreationDate: '15 December 2016' };

        httpBackend
           .expectPOST('/Link/DeleteLink', linkToDelete)
           .respond(200, '');

        linkController.deleteLink(linkToDelete);

        httpBackend.flush();

        expect(linkController.links.length).toBe(3);
    });
});