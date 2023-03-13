$(function () {
    abp.log.debug('Index.js initialized!');

 
});
function fetchALlGames() {
    hs.historyFetch.games.game.fetchAllGames().done(function (result) {
        alert("ok")
    });
}
