﻿/* Automatically generated codefile, Meridian
 * Generated by magic, please do not interfere
 * Please sleep well and do not smoke. Love, Sam */

using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;

namespace meridian.smolensk.proto
{
	public partial class news_videos_meta
	{
		public news_videos_meta()
		{
		}
		/* metafile template */
		public long id { get; set; }
		public long news_id { get; set; }
		public System.Guid guid { get; set; }
		public string url { get; set; }
		public string original { get; set; }
		public string small_thumbnail { get; set; }
		/* metafile template */
	}
}