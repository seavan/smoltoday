using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.CodeModels
{
    public class DictionaryElement
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public long? ParentId { get; set; }

        public DictionaryElement()
        {
            
        }

        public DictionaryElement(long id, string value)
        {
            Id = id;
            Value = value;
        }

        public DictionaryElement(long id, string value, long parentId)
            :this(id, value)
        {
            ParentId = parentId;
        }
    }
}