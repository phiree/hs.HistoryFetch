using hs.HistoryFetch.Games;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Logging;
using static System.TimeZoneInfo;

namespace hs.HistoryFetch.Services
{
    public class FetchService : IFetchService
    {
        ILogger<FetchService> logger;

        IRepository<Sale, int> saleRepository;
        public FetchService(ILogger<FetchService> logger, IRepository<Sale, int> saleRepository)
        {
            this.logger = logger;
            this.saleRepository = saleRepository;
        }

        public FetchService() { }
        public void FetchPZHistorySale(int gameId, DateTime date, int pageSize)
        {

        }
        public async Task<IList<Game>> FetchGames()
        {

            var req = new RequestWrapper();
            //端游
            var result_type1 = await req.Request("https://www.pzds.com/api/v2/homepage/public/game/all", new { action = new {
             gameCatalogueId=1,
             
                goodsCatalogueId=6
 
 
        } });
            Thread.Sleep(1000);
            //手游
            var result_type2 = await req.Request("https://www.pzds.com/api/v2/homepage/public/game/all", new
            {
                action = new
                {
                    gameCatalogueId = 2,
                    
                    goodsCatalogueId = 6
                }
            });
            
            var gamesClient=Newtonsoft.Json.JsonConvert.DeserializeObject< BaseResultAll < Game > >(result_type1);

            var gamesMobile = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResultAll<Game>>(result_type2);

          var games1=  gamesClient.data.Select(x => { x.ClientType = GameClientType.端游; return x; });
            var games2=gamesMobile.data.Select(x => { x.ClientType = GameClientType.手游; return x; });


            return games1.Concat(games2).ToList();
        }

        private async Task<IList<Game>> FetchGames(int gameType)
        {

            var req = new RequestWrapper();
            var result = await req.Request("https://www.pzds.com/api/v2/homepage/public/game/all",
                new { action = new { } });
            /*
             public async Task<IList<Game>> FetchGames()
        {

            var req = new RequestWrapper();
            var result = await req.Request("https://www.pzds.com/api/v2/homepage/public/game/all", new { action = new { } });

           var json=Newtonsoft.Json.JsonConvert.DeserializeObject< BaseResultAll < Game > >(result);
            return json.data;
        }
             */

            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResultAll<Game>>(result);
            return json.data;
        }
        public async Task FetchHistoryTrade(int gameId, DateTime date,int startPage=1)
        {

            int page = startPage;
            int totalPages = 9999999;
            var req = new RequestWrapper();
            var all = new List<Sale>();
            var savePath = @$"D:\code\fetcheddata\panzhi\historysale_50_perpage\";
            while (page <= totalPages)
            {
                Thread.Sleep(new Random().Next(1000,2000));
                var result = await req.Request (
                     "https://www.pzds.com/api/v2/homepage/public/transaction/page",
                     new
                     {
                         action = new
                         {
                             gameId,
                             goodsCatalogueId =6,
                             //isTop=true
                            // transactionTime,// date.ToString("yyyy-MM-dd 00:00:00")
                         },
                          page,
                         pageSize = 50
                     });
                var fetchedData = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResultPaged<Sale>>(result).data;
                var hasFetched =await HasFetchAllNewAndBreak(gameId,fetchedData.records);
                if(hasFetched) { break; }
                totalPages =fetchedData.totalPages;
                
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string fileName = $"gameId_{gameId}_page_{page}.txt";
                File.WriteAllText(savePath+"\\"+fileName,result);

              
                //all.AddRange(result.data.records);
                page++;
                logger.LogDebug($"当前游戏:{gameId},抓取进度:{page}/{totalPages}");
                
            }
          

        }
        /// <summary>
        /// 获取最新的
        /// </summary>
        /// <param name="result"></param>
        private async Task<bool> HasFetchAllNewAndBreak(int gameId,IList<Sale> records) {

            
            //existed record
            bool hasFetched = false;
            foreach(var record in records) {
               var existedSale=await saleRepository.FindAsync( x=>x.Id== record.Id&&x.GameId==gameId);
                if (existedSale != null)
                {
                    hasFetched = true;
                }
                else { 
                 saleRepository.InsertAsync(record);
                }
            }
            return hasFetched;
        }
    }
}
