using admin.db;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace meridian.smolensk.protoStore
{
    public partial class salesStore
    {
        sales IDataService<sales>.CreateItem()
        {
            return sales.Create();
        }
    }
}
