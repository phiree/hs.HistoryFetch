using hs.HistoryFetch.Games;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace hs.HistoryFetch.Services
{
    public interface IFetchService: IDomainService
    {
        Task<IList<Game>> FetchGames();
       
        Task<IList<Sale>> FetchHistoryTrade(int gameId, DateTime date);
    }
}