(function () {
    var name = "app.shell",
        requires = ["ngRoute"];

    angular.module(name, requires)
        .config(function ($routeProvider) {
            $routeProvider
                .when("/search", {
                    templateUrl: "scripts/app/search/search.html",
                    controller: "Search"
                })
                .when("/weather/:id", {
                    templateUrl: "scripts/app/weather/weather.html",
                    controller: "Weather"
                })
                .when("/forecast/:id", {
                    templateUrl: "scripts/app/forecast/forecast.html",
                    controller: "Forecast"
                })
            .otherwise({
                redirectTo: "/search"
            })
        })
})();