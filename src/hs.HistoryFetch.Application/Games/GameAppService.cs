using hs.HistoryFetch.Services;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace hs.HistoryFetch.Games
{
    public class GameAppService : CrudAppService<Games.Game, GameDto, int>, IGameAppService
    {
        IFetchService fetchService;
        IRepository<Sale, int> saleRepository;
        public GameAppService(IRepository<Game, int> repository,IRepository<Sale,int> saleRepository, IFetchService fetchService) : base(repository)
        {
            this.fetchService = fetchService;
            this.saleRepository = saleRepository;
        }

        public async Task FetchAllGamesAsync()
        {
            var existedGames = await Repository.GetListAsync();

            var games = await fetchService.FetchGames();

            var compareResult = new ListComparer<Game, int>(existedGames, games).Compare();


            await Repository.InsertManyAsync(compareResult.Inserts);


            foreach (Game game in compareResult.Updates)
            {
                var newGame = games.Single(x => x.Id == game.Id);
                game.Name = newGame.Name;
                game.pcIconUrl = newGame.pcIconUrl;
            }
            await Repository.UpdateManyAsync(existedGames);
            await Repository.DeleteManyAsync(compareResult.Deletes);
        }
        public async Task FetchAllSales(int days, int[] gameIds)
        {

            foreach (var gameId in gameIds)
            {
                var targetDate = DateTime.Now.AddDays(-1 * days);
                for (var date = DateTime.Now; date <= targetDate; date.AddDays(-1))
                {
                    var sales= await   fetchService.FetchHistoryTrade(gameId, date);

                }
            }
        }


    }
}
