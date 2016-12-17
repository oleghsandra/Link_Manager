/// <reference path="../libs/angular.js" />
/// <reference path="../libs/angular-mocks.js" />
/// <reference path="../jasmine/jasmine.js" />
/// <reference path="../app/pages/links/links.module.js" />
/// <reference path="../app/pages/links/links.controller.js" />
/// <reference path="../app/pages/links/links.service.js" />

describe("Link Manager Tests ->", function () {

    var linkManagerFactory, httpBackend, LinkController, $controller;
    var mockLinks = [
            { Id: 1001, Title: 'https://www.youtube.com/', Date: '15 December 2016' },
            { Id: 1002, Title: 'https://www.google.com.ua/', Date: '16 December 2016' },
            { Id: 1003, Title: 'http://www.henrihietala.fi/running-jasmine-unit-tests-in-your-visual-studio-online-build/', Date: '01 June 2014' },
            { Id: 1004, Title: 'https://www.youtube.com/watch?v=W1p6T_KXLyI', Date: '02 December 2016' }
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
            .expectGET('/Link/GetLinks')
            .respond(200, mockLinks);

        linkController = $controller('LinkController', {});

        httpBackend.flush();
    }));

    it('Get links', function () {
        expect(linkController.links.length).toBe(4);
    });

    it('Add link', function () {
        var linkToAdd = { Id: 1001, Title: 'https://www.youtube.com/', Date: '09 December 2016' };
        var resultLink = null;

        httpBackend
            .expectPOST('/Link/AddLink', linkToAdd)
            .respond(200, linkToAdd);

        linkManagerFactory.addLink(linkToAdd).then(function (response) {
            resultLink = response.data;
        });

        httpBackend.flush();

        expect(linkToAdd).toEqual(resultLink);
    });

    it('Remove link', function () {
        var linkToRemove = { Id: 1002, Title: 'https://www.google.com.ua/', Date: '08 December 2016' };

        httpBackend
           .expectPOST('/Link/DeleteLink', linkToRemove)
           .respond(200, '');

        linkController.remove(linkToRemove);

        httpBackend.flush();

        expect(linkController.links.length).toBe(3);
    });

    it('Update link', function () {
        var indxOfEditElement = 1;
        var newTitle = 'http://www.newTitle.ua/';
        linkController.indexOfEditElement = indxOfEditElement;

        httpBackend
            .expectPOST("/Link/UpdateLink", linkController.links[indxOfEditElement])
            .respond(200, '');

        linkController.saveEditing(newTitle);

        httpBackend.flush();

        expect(linkController.links[indxOfEditElement].Title.toString()).toEqual(newTitle.toString());
    });
});