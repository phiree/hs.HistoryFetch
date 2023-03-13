using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace hs.HistoryFetch.Games
{
    public  class GameDto:EntityDto<int>
    {
        public string Name { get; set; }
        public string pcIconUrl { get; set; }
    }
}
