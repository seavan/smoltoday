using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Models.CodeModels
{
    public class Mark : IMark
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public long MaterialId { get; set; }
        public long AuthorId { get; set; }
        public int CMark { get; set; }

        public string ProtoName { get; set; }

        public Mark()
        {
            CreateDate = DateTime.Now;
        }
    }
}