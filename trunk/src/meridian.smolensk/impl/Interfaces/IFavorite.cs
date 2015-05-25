using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meridian.smolensk.proto
{
    public interface IFavorite
    {
        void AddToFavorite(long account_id);
        void DeleteFromFavorite(long account_id);
        bool IsFavorite(long account_id);
        long id { get; }
        string ProtoName { get; }
    }

    public static class ExFavorite
    {
        public static IEnumerable<T> GetFavorites<T>(this IEnumerable<T> list, long? account_id) where T : IFavorite
        {
            if (!account_id.HasValue || account_id.Value == 0)
                return list;
            return list.Where(f => f.IsFavorite(account_id.Value));
        }
    }
}
