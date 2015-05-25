using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using smolensk.common.Domain;

namespace meridian.smolensk.impl.Video
{
    class HtmlVideoInfo : IEntity<Guid>
    {
        public HtmlVideoInfo(HtmlNode node, Uri uri, Guid guid, IVideoImageProvider imageProvider)
        {
            this.Node = node;
            this.Id = guid;
            this.Uri = uri;
            this.ImageProvider = imageProvider;
        }

        public HtmlNode Node { get; set; }
        public Uri Uri { get; set; }
        public Guid Id { get; set; }
        public IVideoImageProvider ImageProvider { get; set; }

        Guid IEntity<Guid>.id
        {
            get { return this.Id; }
        }
    }
}
