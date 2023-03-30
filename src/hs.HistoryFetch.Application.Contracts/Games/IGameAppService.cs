using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace hs.HistoryFetch.Games
{
    public interface IGameAppService : ICrudAppService<GameDto, int> {
    
        Task FetchAllGamesAsync();
        Task FetchAllSales(int gameId,DateTime date,int startPage);
        Task<IList<GameDto>> GetGames(int[] gameIds); 
    }
}
