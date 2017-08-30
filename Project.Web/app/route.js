app.config(function ($routeProvider) {
    $routeProvider


         .when('/home', {
             templateUrl: '/app/pages/home.html',
             controller: 'gameCtrl as vm'
         })
    
        .when('/create', {
            templateUrl: '/app/pages/createDuel.html',
            controller: 'gameCtrl as vm'
        })
         .when('/duel', {
             templateUrl: '/app/pages/duel.html',
             controller: 'gameCtrl as vm'
         })

        .otherwise({ redirectTo: '/home' });
});






app.config(function ($locationProvider) {
    $locationProvider.hashPrefix('');
});