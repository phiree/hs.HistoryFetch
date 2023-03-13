using System.Collections.Generic;

namespace hs.HistoryFetch.Services
{
    public class BaseResultAll<T> : BaseResult 
    {
        public List<T> data { get; set; }
    }

}
