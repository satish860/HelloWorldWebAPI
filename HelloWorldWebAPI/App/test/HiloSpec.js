/// <reference path="../durandal/amd/require.js" />
/// <reference path="../lib/knockout-2.2.1.debug.js" />
/// <reference path="../lib/chai.js" />
/// <reference path="../lib/mocha.js" />
/// <reference path="../lib/sinon-1.6.0.js" />

define(function (require) {
    var chai = require('lib/chai');
    var Hilo = require('viewModels/HiloUtility');
    var someotherVariable = require('lib/sinon-1.6.0')
    var app = require('app');
    var expect = chai.expect;

    describe("A Hilo Generator", function () {
        describe("A Hilo Generator", function () {
            it("should be created with the max value,Capacity and low value", function () {
                var generator = new Hilo.HiloGenerator("Todo", 1, 100);
                expect(generator.tableName).to.equal("Todo");

            });

            it("Should be possible Get the next range with HILO algorithm", function () {
                var generator = new Hilo.HiloGenerator("Todo", 1, 100);
                expect(generator.getNextIdRange()).to.equal(1);
                expect(generator.getNextIdRange()).to.equal(2);
            });
            describe("If the Capactity reached the Lower range ", function () {
                it("should call the webapi to get the next value", function () {
                    var server = sinon.fakeServer.create();
                    var generator = new Hilo.HiloGenerator("Todo", 1, 1);
                    generator.getNextIdRange();
                    expect(server.requests[0].url).to.equal('api/Hilo/Todo');
                    server.respondWith("GET", "api/Hilo/Todo", [200, { "Content-Type": "application/json" }, '{"High": 1,"Capacity": 10}']);
                    server.respond();
                    server.restore();

                });
            });


        });
    });

    describe("A Hilo Generator Dictionary", function () {
        xit("Can create a HILO generator if it is not found by calling the service", function () { });
        xit("should get the next range from the dictionary if the HiloGenerator is availble", function () { });

    });

    return {};

});