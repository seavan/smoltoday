using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.common;

namespace smolensk.Mappers
{
    public static class MappingUtils
    {
        public static IEnumerable<T> TakePage<T>(IEnumerable<T> collection, int page, int pageSize = Constants.PageSize)
        {
            return collection.Skip((page - 1)*pageSize).Take(pageSize);
        }

        public static int CalculatePagesCount(long recordsCount, int pageSize = Constants.PageSize)
        {
            return (int)(recordsCount / pageSize) + (recordsCount % pageSize > 0 ? 1 : 0);
        }
    }
}