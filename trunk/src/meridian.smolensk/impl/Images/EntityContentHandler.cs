using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.system;
using smolensk.common;
using CuttingEdge.Conditions;

namespace meridian.smolensk.impl.Images
{
    public abstract class EntityContentHandler
    {
        protected Meridian meridian;
        protected UrlBuilder urlBuilder;

        public EntityContentHandler(Meridian meridian, UrlBuilder urlBuilder, long entityId)
        {
            Condition.Requires(meridian, "meridian").IsNotNull();
            Condition.Requires(urlBuilder, "urlBuilder").IsNotNull();

            this.meridian = meridian;
            this.urlBuilder = urlBuilder;
            this.EntityId = entityId;
        }

        public long EntityId { get; set; }

        public Uri GetAbsoluteImageUri(string imageUri)
        {
            return urlBuilder.BuildAbsoluteUri(imageUri);
        }
    }
}
