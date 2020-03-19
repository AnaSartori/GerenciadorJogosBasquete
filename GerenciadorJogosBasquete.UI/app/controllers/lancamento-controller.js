app.controller("LancamentoCtrl", function($scope, jogoBasqueteApi) {
    $scope.title = "Lançar Pontos";
    $scope.jogos = [];
    $scope.data = new Date();
    $scope.lancamento = {};

    $scope.lancamento.DataJogo = new Date();
    $scope.lancamento.QtdPontos = 0;

    
    // var date = new Date($scope.data.getYear(), $scope.data.getMonth(), $scope.data.getDay());

    $scope.lancarPontos = function() {      
        console.log("teste");
        jogoBasqueteApi.addJogo($scope.lancamento).then(function(){
            console.log('Sucesso!');
            $scope.lancamento = {};
        },
        function(error){
            console.log(error);
        });
    };
});
