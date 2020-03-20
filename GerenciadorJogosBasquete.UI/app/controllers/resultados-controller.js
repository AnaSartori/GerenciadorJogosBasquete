app.controller("ResultadosCtrl", function($scope, jogoBasqueteApi) {
    $scope.title = "Resultados";
    $scope.alertMessage = "";
    $scope.errorMessage = "";
    $scope.resultados = {};

    carregarResultados();

    function carregarResultados() {
        jogoBasqueteApi.getResultados().then(
            function(response) {
                $scope.resultados = response.data.data;

                if (response.data.data.totalJogos === 0) {
                    $scope.alertMessage =
                        "Não existem jogos cadastrados até o momento! Cadastre uma nova pontuação para visualizar.";
                }

                if (!response.data.isSuccess) {
                    $scope.errorMessage = response.data.message;
                }
            },
            function(error) {
                $scope.errorMessage = "Não foi possível carregar os resultados.";
                console.log(error); //Apenas para fins de teste.
            }
        );
    }
});
