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
    public  class Game: IEntity<int>
    {
        public string Name { get; set; }
        public string pcIconUrl { get; set; }
        public GameClientType ClientType { get; set; }
        public    int  Id { get;  set; }

        

        public object[] GetKeys()
        {
            return new object[] { Id };
        }
    }
    public enum GameClientType { 
    端游=1,
    手游
    }
}
