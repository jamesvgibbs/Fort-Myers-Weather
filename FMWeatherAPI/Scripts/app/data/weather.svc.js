(function () {
    angular.module("app.data")
        .factory("weatherSvc", function ($http, $q) {
            return {
                find: findByLocation,
                getCurrent: getCurrentWeather,
                getForecast: getForecast,
                getAllWeather: getAllWeather
            }

            function getAllWeather() {
                var url = "http://localhost:51159/api/weather";

                var defer = $q.defer();

                $http.get(url)
                    .success(function (response) {
                        console.log(response);
                        defer.resolve(response);
                    })
                    .error(function (err) {
                        defer.reject(err);
                    })

                return defer.promise;
            }

            function findByLocation(location) {
                var url = "http://api.openweathermap.org/data/2.5/find?q=" + location + "&appid=44eb0952fd8867ed341dc3720f5f4e61" + "&units=imperial";

                var defer = $q.defer();

                $http.get(url)
                    .success(function (response) {
                        defer.resolve(response);
                    })
                    .error(function (err) {
                        defer.reject(err);
                    })

                return defer.promise;
            }

            function getCurrentWeather(id) {
                var defer = $q.defer();

                var url = "http://api.openweathermap.org/data/2.5/weather?id=" + id + "&appid=44eb0952fd8867ed341dc3720f5f4e61" + "&units=imperial";

                $http.get(url)
                    .success(function (response) {
                        defer.resolve(response);
                    })
                    .error(function (err) {
                        defer.reject(err);
                    })

                return defer.promise;
            }

            function getForecast(id) {
                var defer = $q.defer();

                var url = "http://api.openweathermap.org/data/2.5/forecast/daily?id=" + id + "&appid=44eb0952fd8867ed341dc3720f5f4e61" + "&units=imperial&cnt=16";

                $http.get(url)
                    .success(function (response) {
                        defer.resolve(response);
                    })
                    .error(function (err) {
                        defer.reject(err);
                    })

                return defer.promise;
            }
        });
}());