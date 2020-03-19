angular.module('app').factory('jogoBasqueteApi', function ($http, config){
    var _addJogo = function (lancamento) {
        return $http({
            method: "POST",
            url: config.baseUrl + "/add",
            data: lancamento
        });
    };

    var _getJogos = function () {
        return $http({
            method: "GET",
            url: config.baseUrl
        });
    };

    var _getResultados = function () {
        return $http({
            method: "GET",
            url: config.baseUrl + "/resultados"
        });
    };

    return{
        addJogo: _addJogo,
        getJogos: _getJogos,
        getResultados: _getResultados
    };
});