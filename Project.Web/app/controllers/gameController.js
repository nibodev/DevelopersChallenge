app.controller(
    'gameCtrl',
    function ($gameSvc, $routeParams) {
        var vm = this;

        vm.consultTeams = function () {

            $gameSvc.consultTeam()
             .then(function (result) {
                 vm.team = result.data;
             })
             .catch(function (e) {
                 console.log(e.data);
             });
        }

        vm.create = function () {

            vm.mensagem = {};

            vm.model.TeamFirstId = vm.model.TeamFirstId.TeamId
            vm.model.TeamSecondId = vm.model.TeamSecondId.TeamId

            $gameSvc.create(vm.model)
            .then(function () {

                vm.mensagem = "Duelo cadastrado com sucesso!";
                vm.consultTeams();
            })
             .catch(function (e) {
                 console.log(e.data);
             });
        }

        //List of Duels
        vm.duels = function () {

            $gameSvc.duels()
             .then(function (result) {
                 vm.team = result.data;
             })
             .catch(function (e) {
                 console.log(e.data);
             });
        }

        //Finish game
        vm.finalize = function () {
            model = {};

            model.TeamId = vm.model.Team.Team
            model.TeamRelationshipId = vm.model.Team.TeamRelation


            $gameSvc.finalize(model)
             .then(function () {
                 vm.duels(); //Atualizando a Lista de Duelos
             })
             .catch(function (e) {
                 console.log(e.data);
             });
        }

    });