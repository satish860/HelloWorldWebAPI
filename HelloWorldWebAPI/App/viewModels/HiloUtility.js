/// <reference path="../durandal/amd/require.js" />
/// <reference path="../lib/jquery-1.9.1.js" />
/// <reference path="../lib/jquery-1.9.1.intellisense.js" />


define(function (require) {

    var HiloGenerator = function (tableName, maxValue, capacity) {
        this.tableName = tableName;
        this.maxValue = maxValue;
        this.capacity = capacity;
        this.minValue = 0;
        this.getNextIdRange = function () {
            var nextMinvalue = this.minValue + 1;
            if (nextMinvalue === this.capacity) {
                jQuery.ajax({
                    url: "api/Hilo/" + this.tableName
                }).always(function () {
                    console.log("I am called");
                }).success(function (data) {
                    console.log(data);
                });
            }
            return ((this.maxValue - 1) * capacity + (++this.minValue));

        }
    };

    return {
        HiloGenerator: HiloGenerator
    }
});