using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.Models.CodeModels;

namespace smolensk.Extensions
{
    public static class DictionaryElementExtensions
    {
        public static string EnumerateToString(this IEnumerable<DictionaryElement> list)
        {
            return string.Join(", ", list.Select(t => t.Value));
        }
    }
}