using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace hs.HistoryFetch.Games
{
    public  class FetchSaleDto
    {
        [CanBeNull]
        
        public string StartGameId { get; set; }
        public int Days { get; set; }
        public int StartPage { get; set; } = 1;
        public string ExcludeGameId { get; set; }
    }
}
