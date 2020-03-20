app.controller("LancamentoCtrl", function($scope, jogoBasqueteApi) {
    $scope.title = "Lançar Pontos";
    $scope.lancamento = {};
    $scope.successMessage = '';
    $scope.errorMessage = '';

    $scope.lancamento.DataJogo = new Date();
    $scope.lancamento.QtdPontos = 0;

    $scope.lancarPontos = function() {
        jogoBasqueteApi.addJogo($scope.lancamento).then(
            function(response){               
                $scope.lancamento= {};

                if (response.data.isSuccess) {
                    $scope.successMessage = "Novo lançamento de pontos realizado com sucesso!";
                }
                else{
                    $scope.errorMessage = response.data.message;
                }
            },
            function(error){
                $scope.errorMessage = "Ocorreu um erro ao lançar os pontos da partida."
            }
        );
    };
});