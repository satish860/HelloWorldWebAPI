/// <reference path="../lib/mocha.js" />
/// <reference path="../lib/chai.js" />
/// <reference path="../lib/knockout-2.2.1.debug.js" />

define(function (require) {
    var chai = require('lib/chai');
    var todoViewmodel = require('viewModels/todoListViewModel');
    var app = require('app');
    var expect = chai.expect;

    describe("A TodoList ViewModel", function () {
        it("should be possible to add a new TodoModel with description", function () {
            todoViewmodel.TodoList([]);
            var events = app.trigger("Todo:new", "Hello this is my first todo");
            events.off();
            expect(todoViewmodel.TodoList().length).to.equal(1);
        });

        xit("should be possible to make the Todo as Completed", function () { });

        xit("should be possible to make the todo to show all the todo", function () { });

        xit("should be possible to show only the finished todo", function () { });
    });

    xdescribe("A ToDoList", function () {
        xit("can be reterived from the server", function () { });

        xit("A todo can be added to the list in the server", function () { });

        xit("A todo can be updated to completed in the server", function () { });

    });
});