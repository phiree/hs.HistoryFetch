using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace hs.HistoryFetch.Services;

public class ListComparer<T,Key>
    where T : IEntity<Key>

{
    IEnumerable<T> oldList; IEnumerable<T> newList;

    public ListComparer(IEnumerable<T> oldList, IEnumerable<T> newList)
    {
        this.newList = newList;
        this.oldList = oldList;
    }

    public ComapreResult Compare()
    {

      
        var inserts = newList.Except(oldList, new EntityComparer());
        var updates = newList.Intersect(oldList, new EntityComparer());
        var deletes = oldList.Except(newList, new EntityComparer());

        return new ComapreResult { Inserts = inserts, Updates = updates, Deletes = deletes };
    }

    public class ComapreResult
    {
        public IEnumerable<T> Inserts { get; set; }
        public IEnumerable<T> Updates { get; set; }
        public IEnumerable<T> Deletes { get; set; }
    }
    public class EntityComparer  :IEqualityComparer<T>
       

    {


        public bool Equals(T x, T y)
        {
            return x.Id.Equals(y.Id);
            throw new NotImplementedException();
        }



        public int GetHashCode([DisallowNull] T obj)
        {
            return obj.Id.GetHashCode();
            throw new NotImplementedException();
        }
    }
}
