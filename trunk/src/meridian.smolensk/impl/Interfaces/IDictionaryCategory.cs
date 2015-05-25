using System.Collections.Generic;

namespace meridian.smolensk.proto
{
    public interface IDictionaryCategory
    {
        long id { get; }
        string title { get; set; }
        bool MultiValue { get; }
        bool FreeValue { get; }
        bool Selectable { get; }
        bool ShowIsNoSelect { get; }
        IEnumerable<IDictionaryValue> GetAllValues();
    }
}