using System;
using System.Linq;
using System.Text;

namespace meridian.smolensk.proto
{
    public interface IMark
    {
        long Id { get; set; }
        DateTime CreateDate { get; set; }
        long MaterialId { get; set; }
        long AuthorId { get; set; }
        int CMark { get; set; }
    }
}
