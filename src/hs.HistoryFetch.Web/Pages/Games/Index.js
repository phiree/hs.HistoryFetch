$(function () {
    abp.log.debug('Index.js initialized!');

 
});
function fetchALlGames() {
    hs.historyFetch.games.game.fetchAllGames().done(function (result) {
        alert("ok")
    });
   
}
function fetchALlSales() {
    var gameId = $("#gameId").val();// document.getElementById("gameId")
    var days = $("#days").val();
    var startPage = $("#startPage").val();

    hs.historyFetch.controllers.game.fetchSaledFromPanzi({ gameId: gameId, days: days, startPage: startPage })
        .done(function (result) {
        $("#result").text(result);
    });
}
