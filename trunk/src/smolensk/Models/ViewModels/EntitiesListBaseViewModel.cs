using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public abstract class EntitiesListBaseViewModel<TEntity>
    {
        public int TotalEntities { get; set; }
        public int TotalPages { get; set; }
        public IList<TEntity> Entities { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}