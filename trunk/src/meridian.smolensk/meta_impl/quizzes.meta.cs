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
	public partial class quizzes_meta
	{
		public quizzes_meta()
		{
		}
		/* metafile template */
		public long id { get; set; }
		public string title { get; set; }
		public DateTime datetime_start { get; set; }
		public DateTime datetime_finish { get; set; }
		public DateTime datetime_publish { get; set; }
		public bool is_main { get; set; }
		/* metafile template */
	}
}
