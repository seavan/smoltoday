using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.CodeModels
{
    public class FileElement
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
        public string Url { get; set; }
    }
}