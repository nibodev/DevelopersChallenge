app.service(
    '$gameSvc',
    function ($http) {

        var services = {};

        services.consultTeam = function () {
            return $http.get("/Game/GetTeams");
        }


        services.duels = function () {
            return $http.get("/Game/GetDuels");
        }


        services.create = function (model) {
            return $http.post("/Game/Create", model);
        }

        services.finalize = function (model) {
            return $http.post("/Game/AddDeleted", model);
        }


        return services;
    });
