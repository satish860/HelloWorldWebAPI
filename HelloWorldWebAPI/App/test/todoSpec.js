/// <reference path="../lib/mocha.js" />
/// <reference path="../lib/chai.js" />
/// <reference path="../durandal/app.js" />

define(function (require) {
    var chai = require('lib/chai');
    var app = require('app');
    var todoViewmodel = require('viewModels/todoViewModel');

    var expect = chai.expect;
    describe('A Todo', function () {
        it("should have a description", function () {
            expect(todoViewmodel.description()).to.equal('');
        });

        it('should be observable', function () {
           var subscription=todoViewmodel.description.subscribe(function (newValue) {
                expect(newValue).to.equal('newValue');
            });
           todoViewmodel.description('newValue');
           subscription.dispose();
        });
       
    });

    describe('when the user clicks on enter', function () {
        it('Todo should be added to the List', function () {
           var events=app.on("Todo:new").then(function (description) {
                expect(description).to.equal('newValue');
            });
            todoViewmodel.description('newValue');
            todoViewmodel.CreateTodo();
            events.off();
        });
    });

    return {
        name: "Hello"
    }
});