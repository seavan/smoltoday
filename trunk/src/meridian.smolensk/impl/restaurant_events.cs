using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class restaurant_events : ILookupValueAspectProvider
    {

        public ILookupValueAspect GetLookupValueAspect(string _fieldName)
        {
            return new LookupAspect(_fieldName, this,
                () =>
                {
                    return Meridian.Default.restaurantsStore.All().OrderBy(s => s.title);
                });
        }
    }
}
