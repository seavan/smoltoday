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
	public partial class blog_lastviews_meta
	{
		public blog_lastviews_meta()
		{
		}
		/* metafile template */
		public long id { get; set; }
		public long blog_id { get; set; }
		public long account_id { get; set; }
		public DateTime view_date { get; set; }
		/* metafile template */
	}
}