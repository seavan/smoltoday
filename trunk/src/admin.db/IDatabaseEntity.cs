using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace admin.db
{
    public interface IDatabaseEntity
    {
        long id { get; set; }

        string ProtoName { get; }
    }
}
