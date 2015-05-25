using admin.db;

namespace meridian.smolensk.proto
{
    public interface IAspect
    {
        string FieldName { get; set; }
        IDatabaseEntity GetParent();
    }
}