using System.Collections.Generic;

namespace smolensk.common.Infrastructure
{
    public class MergeResult<T>
    {
        public MergeResult(IEnumerable<T> itemsToAdd, IEnumerable<T> itemsToRemove)
        {
            this.ItemsToAdd = itemsToAdd;
            this.ItemsToRemove = itemsToRemove;
        }

        public IEnumerable<T> ItemsToRemove { get; set; }
        public IEnumerable<T> ItemsToAdd { get; set; }
    }
}