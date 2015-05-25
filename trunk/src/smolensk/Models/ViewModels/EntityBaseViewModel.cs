using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using admin.db;

namespace smolensk.ViewModels
{
    public abstract class EntityBaseViewModel
    {
        protected EntityBaseViewModel(long id)
        {
            this.Id = id;
        }

        protected EntityBaseViewModel(IDatabaseEntity entity)
        {
            this.Id = entity.id;
        }

        //NOTE: Просьба не делать set приватным, т.к он нужен при мэппинге:)
        public long Id { get; set; }
    }
}