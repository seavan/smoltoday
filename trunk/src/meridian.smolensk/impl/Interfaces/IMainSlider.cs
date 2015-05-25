using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meridian.smolensk.proto
{
    public interface IMainSlider
    {
        string ProtoName { get; }
        string title { get;}
        DateTime publish_date { get;  }
        Uri ItemMainUri { get; }
        Uri GetImgItemMainUri();

    }
}
