app.controller("LancamentoCtrl", function($scope, jogoBasqueteApi) {
    $scope.title = "Lançar Pontos";
    $scope.lancamento = {};

    $scope.lancamento.DataJogo = new Date();
    $scope.lancamento.QtdPontos = 0;

    $scope.lancarPontos = function() {
        jogoBasqueteApi.addJogo($scope.lancamento).then(
            function(response){
                console.log("Sucesso!");
                $scope.lancamento= {};
            },
            function(error){
                console.log("Erro: " + error);
                $scope.lancamento= {};
            }
        );
    };
});