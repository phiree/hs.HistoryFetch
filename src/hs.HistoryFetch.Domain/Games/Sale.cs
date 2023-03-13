using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace hs.HistoryFetch.Games
{
    public  class Sale: IEntity<int>
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GoodsNo { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime TransactionTime { get; set; }
        public string SimpleMessage { get; set; }
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime OnStandTime { get; set; }

        public    int  Id { get;  set; }

        public object[] GetKeys()
        {
            return new object[] { Id };
        }

        
    }
}
