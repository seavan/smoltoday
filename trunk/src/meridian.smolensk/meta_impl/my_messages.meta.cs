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
	public partial class my_messages_meta
	{
		public my_messages_meta()
		{
		}
		/* metafile template */
		public long id { get; set; }
		public string title { get; set; }
		public string text { get; set; }
		public string link { get; set; }
		public string link_name { get; set; }
		public DateTime create_date { get; set; }
		public bool is_new { get; set; }
		public long account_id { get; set; }
		/* metafile template */
	}
}
