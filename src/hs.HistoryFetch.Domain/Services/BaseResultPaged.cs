using System;
using System.Collections.Generic;
using System.Text;

namespace hs.HistoryFetch.Services
{
    public class BaseResultPaged<T> : BaseResult
    {

        public _data data { get; set; }

        public class _data
        {
            public IList<T> records { get; set; }
            public int page { get; set; }
            public int total { get; set; }
            public int totalPages { get; set; }

        }
    }

}
