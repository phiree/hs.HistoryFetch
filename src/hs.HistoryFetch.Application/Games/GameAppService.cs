using AutoMapper;
using hs.HistoryFetch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace hs.HistoryFetch.Games
{
    public class GameAppService : CrudAppService<Games.Game, GameDto, int>, IGameAppService
    {
        IFetchService fetchService;
        IRepository<Sale, int> saleRepository;
        IRepository<Game, int> gameRepository;
       
        
        public GameAppService(IRepository<Game, int> repository, IRepository<Sale, int> saleRepository, IFetchService fetchService, IRepository<Game, int> gameRepository ) : base(repository)
        {
            this.fetchService = fetchService;
            this.saleRepository = saleRepository;
            this.gameRepository = gameRepository;
          
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
        public async Task FetchAllSales(int startGameId,  DateTime targetDate, int startPage)
        {

            


            await fetchService.FetchHistoryTrade(startGameId, targetDate,startPage);


        }
        public async Task<IList<GameDto>> GetGames(int[] gameIds)
        {
            var games = await gameRepository.GetListAsync(x =>gameIds.Contains(x.Id));

            return ObjectMapper.Map<IList<Game> ,IList<GameDto>>(games);



        }
    }




}

