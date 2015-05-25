using System;
using System.Collections.Generic;
using System.Linq;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.Models.ViewModels;

namespace smolensk.Mappers
{
    public static class ActionCategoryMapper
    {
        public static ActionCategoryViewModel GetCategory(long? category_id)
        {
            var c_store = Meridian.Default.action_categoriesStore;
            return category_id.HasValue && c_store.Exists(category_id.Value) ? c_store.Get(category_id.Value).ToCategory() : null;
        }

        public static ActionCategoryViewModel ToCategory(this action_categories category, bool onlyDesc = true, DateTime? from = null, DateTime? to = null)
        {
            var model = new ActionCategoryViewModel(category.id) 
            {
                Title = category.title 
            };
            if (!onlyDesc)
            {
                model.LastActions = Meridian.Default.GetLastActions(category.id, from, to);
                model.ActionsCount = ActionsMapper.GetAcionsCount(category.id, from, to);
                model.Date = new Models.CodeModels.DateRange(from, to);
            }
            return model;
        }

        public static IEnumerable<ActionCategoryViewModel> GetActionCategoriesList(this Meridian meridian, bool onlyDesc = true, DateTime? from = null, DateTime? to = null)
        {
            return meridian.action_categoriesStore.All().OrderBy(c => c.order_id)
                                                  .Select(c => c.ToCategory(onlyDesc, from, to))
                                                  .Where(c => c.ActionsCount > 0);
        }
    }
}