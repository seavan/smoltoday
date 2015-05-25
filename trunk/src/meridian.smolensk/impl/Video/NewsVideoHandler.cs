using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.impl.Images;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.common.Infrastructure;
using smolensk.common.Domain;
using meridian.smolensk.proto;

namespace meridian.smolensk.impl.Video
{
    public class NewsVideoHandler : EntityContentHandler
    {
        public NewsVideoHandler(Meridian meridian, UrlBuilder urlBuilder, long newsId) : base(meridian, urlBuilder, newsId)
        {
        }

        public MergeResult<IEntity<Guid>> MergeVideos(IEnumerable<IEntity<Guid>> newVideos)
        {
            IEnumerable<IEntity<Guid>> currentVideos = null;

            if (!meridian.newsStore.Exists(EntityId))
                currentVideos = new List<IEntity<Guid>>(0);
            else
                currentVideos = meridian.news_videosStore.All()
                    .Where(nv => nv.news_id == EntityId)
                    .Select(nv => new NewsVideosToEntityAdapter(nv));

            return MergeUtils.Merge(currentVideos, newVideos);
        }

        public void InsertVideo(news_videos video)
        {
            video.news_id = EntityId;
            meridian.news_videosStore.Insert(video);
        }

        public void DeleteVideo(Guid id)
        {
            var video = meridian.news_videosStore.All()
                .Where(nv => nv.news_id == EntityId && nv.guid.Equals(id)).FirstOrDefault();

            if (video != null)
                meridian.news_videosStore.Delete(video);
        }

        private class NewsVideosToEntityAdapter : IEntity<Guid>
        {
            private news_videos video;

            public NewsVideosToEntityAdapter(news_videos video)
            {
                this.video = video;
            }

            public Guid id
            {
                get { return video.guid; }
            }
        }
    }
}
