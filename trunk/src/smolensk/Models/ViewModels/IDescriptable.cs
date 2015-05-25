using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public interface IDescriptable
    {
        string Description { get; set; }
        string GetShortDescription();
        int GetShortDescriptionLength();
    }
}