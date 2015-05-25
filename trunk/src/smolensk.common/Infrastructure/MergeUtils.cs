using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.common.Infrastructure
{
    public static class MergeUtils
    {
        public static MergeResult<T> Merge<T>(IEnumerable<T> currentCollection, IEnumerable<T> newCollection)
        {
            if (newCollection.Count() > 0)
            {
                ICollection<T> itemsToAdd = new List<T>();
                ICollection<T> itemsToRemove = new List<T>();

                foreach (var currentEntry in currentCollection)
                {
                    if (!newCollection.Contains(currentEntry))
                        itemsToRemove.Add(currentEntry);
                }

                foreach (var newEntry in newCollection)
                {
                    if (!currentCollection.Contains(newEntry))
                        itemsToAdd.Add(newEntry);
                }

                return new MergeResult<T>(itemsToAdd, itemsToRemove);
            }

            return new MergeResult<T>(newCollection, currentCollection);
        }
    }
}