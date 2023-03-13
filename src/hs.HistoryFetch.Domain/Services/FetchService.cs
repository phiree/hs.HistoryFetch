using hs.HistoryFetch.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.TimeZoneInfo;

namespace hs.HistoryFetch.Services
{
    public class FetchService : IFetchService
    {
        public FetchService() { }
        public void FetchPZHistorySale(int gameId, DateTime date, int pageSize)
        {

        }
        public async Task<IList<Game>> FetchGames()
        {
            var req = new RequestWrapper();
            var result = await req.Request<BaseResultAll<Game>>("https://www.pzds.com/api/v2/homepage/public/game/all", new { action = new { } });


            return result.data;
        }
        public async Task<IList<Sale>> FetchHistoryTrade(int gameId, DateTime date)
        {

            int page = 1;
            int totalPages = 1;
            var req = new RequestWrapper();
            var all = new List<Sale>();
            while (page >= totalPages)
            {
                var result = await req.Request<BaseResultPaged<Sale>>(
                     "https://www.pzds.com/api/v2/homepage/public/transaction/page",
                     new
                     {
                         action = new
                         {
                             gameId,
                             goodsCatalogueId = 6,
                             transactionTime = date.ToString("yyyy-MM-dd 00:00:00")
                         },
                         page = page,
                         pageSize = 10
                     });
                totalPages = result.data.totalPages;
                all.AddRange(result.data.records);
                page++;
            }
            return all;

        }
    }
}
