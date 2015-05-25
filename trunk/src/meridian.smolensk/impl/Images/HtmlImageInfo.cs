using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using CuttingEdge.Conditions;
using smolensk.common.Domain;

namespace meridian.smolensk.impl.Images
{
    class HtmlImageInfo : IEntity<Guid>
    {
        public HtmlImageInfo(HtmlNode node, Guid id, Uri uri, string alt, bool inline)
        {
            Condition.Requires(node, "node").IsNotNull();

            this.Node = node;
            this.Id = id;
            this.Uri = uri;
            this.Alt = alt;
            this.IsInline = inline;
        }

        public Guid Id { get; set; }
        public Uri Uri { get; set; }
        public string Alt { get; set; }
        public bool IsInline { get; set; }
        public HtmlNode Node { get; set; }

        Guid IEntity<Guid>.id
        {
            get { return this.Id; }
        }
    }
}