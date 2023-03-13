using hs.HistoryFetch.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hs.HistoryFetch
{
    public class HistoryFetchMapperProfile : AutoMapper.Profile
    {
        public HistoryFetchMapperProfile()
        {
            CreateMap<Games.Game, GameDto>();
        }

    }
}
