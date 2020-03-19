app.controller("ResultadosCtrl", function($scope, jogoBasqueteApi) {
    $scope.title = "Resultados";

    $scope.resultados = {};

    carregarResultados();

    function carregarResultados() {
        jogoBasqueteApi.getResultados().then(
            function(response) {
                $scope.resultados = response.data.data;
            },
            function() {
                $scope.error = "Não foi possível carregar os dados!";
            }
        );
    }
});
