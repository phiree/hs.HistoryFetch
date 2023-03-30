using hs.HistoryFetch.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace hs.HistoryFetch.Controllers
{
    public class GameController : HistoryFetchController
    {
        IGameAppService _gameAppService;

        public GameController(IGameAppService gameAppService)
        {
            _gameAppService = gameAppService;
        }


        [HttpPost]
        [Route("long-running-task")]
        public async Task<ActionResult> Run()
        {
            Response.StatusCode = 200;
            Response.ContentType = "text/event-stream";
            Response.ContentLength = 10;

            var sw = new StreamWriter(Response.Body);

            for (var i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                await sw.WriteAsync("1");
                await sw.FlushAsync();
            }
            return Ok();
        }
        [HttpGet("FetchSaledFromPanzi")]

        public async Task<ActionResult> FetchSaledFromPanzi(FetchSaleDto fetchSaleDto)
        {


            int days = fetchSaleDto.Days;


            Response.ContentType = "text/event-stream";

            var sw = new StreamWriter(Response.Body);

            IEnumerable<GameDto> games;

            var allGames = await _gameAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            games = allGames.Items;



            //for (int i = 0; i <= days; i++)

            for (int j = 0; j < games.Count(); j++)
            {
                var game = games.OrderBy(x => x.Id).ElementAt(j);
                if (game.Id < Convert.ToInt32(fetchSaleDto.StartGameId))
                { continue; }

               

                //var targetDate = DateTime.Now.AddDays(i * -1);
                await _gameAppService.FetchAllSales(game.Id, DateTime.UnixEpoch, fetchSaleDto.StartPage);




            }
            return Ok();


        }


    }
}
