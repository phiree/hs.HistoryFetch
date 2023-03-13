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
    debugger;
    hs.historyFetch.games.game.fetchAllSales({ gameId: gameId, days: days }).done(function (result) {
        alert("ok")
    });
}
