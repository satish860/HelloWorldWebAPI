/// <reference path="durandal/amd/require.js" />

require.config({
    baseUrl: 'App/durandal',
    paths:{
        durandal: 'durandal',
        test:'../test',
        lib: '../lib',
        viewModels:'../viewModels'

    }
});

require(['require','lib/chai','lib/mocha'], function (require) {
    mocha.setup('bdd');
    require(['test/todospec', 'test/todoListSpec','test/HiloSpec'], function (todo) {
        console.log(todo.name)
        mocha.run();
    });
});