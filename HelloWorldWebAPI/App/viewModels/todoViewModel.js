/// <reference path="../lib/knockout-2.2.1.js" />
/// <reference path="../durandal/amd/require.js" />
/// <reference path="../durandal/app.js" />

define(function (require) {
    var app = require('app');
    return {
        description: ko.observable(""),
        CreateTodo: function () {
            app.trigger("Todo:new", this.description());
        }
    };
});