using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using smolensk.Models.CodeModels;
using System.Collections;

namespace smolensk.Models.ModelValidators.Attributes
{
    public class NeedOneAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                IEnumerable list = value as IEnumerable;
                if(list!=null)
                {
                    List<ISelected> valueList = new List<ISelected>();

                    foreach (var selected in list)
                    {
                        if(selected is ISelected)
                        {
                            valueList.Add(selected as ISelected);
                        }
                    }

                    if (valueList.Count > 0)
                    {
                        return valueList.Any(s => s.Selected);
                    }
                }
                return true;
            }
            catch
            {
                return true;
            }
            
        }
    }
}