function () {
    'use strict';
 
    angular
        .module('app')
        .filter('utcToLocal', Filter);
 
    function Filter($filter) {
        return function (utcDateString, format) {
            if (!utcDateString) {
                return;
            }
 
            if (utcDateString.indexOf('Z') === -1 && utcDateString.indexOf('+') === -1) {
                utcDateString += 'Z';
            }
 
            return $filter('date')(utcDateString, format);
        };
    }
})();