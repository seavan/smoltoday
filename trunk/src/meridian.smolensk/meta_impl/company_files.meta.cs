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
	public partial class company_files_meta
	{
		public company_files_meta()
		{
		}
		/* metafile template */
		public long id { get; set; }
		public string file { get; set; }
		public long size { get; set; }
		public string title { get; set; }
		public long company_id { get; set; }
		/* metafile template */
	}
}
