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
	public partial class news_images_meta
	{
		public news_images_meta()
		{
		}
		/* metafile template */
		public long id { get; set; }
		public long news_id { get; set; }
		public string small_thumbnail { get; set; }
		public string medium_thumbnail { get; set; }
		public string large_thumbnail { get; set; }
		public string normal_thumbnail { get; set; }
		public string original { get; set; }
		public string description { get; set; }
		public string url { get; set; }
		public string alt { get; set; }
		public bool inline { get; set; }
		public System.Guid guid { get; set; }
		/* metafile template */
	}
}