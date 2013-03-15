/// <reference path="../lib/knockout-2.2.1.debug.js" />
/// <reference path="../lib/jquery-1.9.1.js" />
/// <reference path="../durandal/events.js" />


define(function (require) {
    var app = require('app');
    var ToDoModel = function (description, completed) {
        this.desscription = ko.observable(description);
        this.completed = ko.observable(completed);
    };

    var todoList = ko.observableArray([]);

    var createToDoList = function (description) {
        todoList.push(new ToDoModel(description, false));
    }

    app.on("Todo:new").then(createToDoList);

    return {
        TodoList:todoList
    };
});