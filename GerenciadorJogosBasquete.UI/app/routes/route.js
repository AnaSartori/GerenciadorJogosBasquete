app.config(function($routeProvider){

    $routeProvider
    .when('/', {
        templateUrl : 'app/views/home.html',
        controller  : 'HomeCtrl',
    })

    .when('/lancamento', {
        templateUrl : 'app/views/lancamento.html',
        controller  : 'LancamentoCtrl',
    })

    .when('/resultados', {
        templateUrl : 'app/views/resultados.html',
        controller  : 'ResultadosCtrl',
    })

    .otherwise ({ redirectTo: '/' });
});
