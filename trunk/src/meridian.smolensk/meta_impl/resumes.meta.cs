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
	public partial class resumes_meta
	{
		public resumes_meta()
		{
		}
		/* metafile template */
		public long id { get; set; }
		public string post { get; set; }
		public string first_name { get; set; }
		public string middle_name { get; set; }
		public string last_name { get; set; }
		public DateTime birth_date { get; set; }
		public int sex { get; set; }
		public int salary { get; set; }
		public string photo_url { get; set; }
		public long region_id { get; set; }
		public long city_id { get; set; }
		public string languages { get; set; }
		public int exp_years { get; set; }
		public int exp_months { get; set; }
		public int children { get; set; }
		public string success_description { get; set; }
		public string about { get; set; }
		public string address { get; set; }
		public string phone { get; set; }
		public string phone2 { get; set; }
		public string email { get; set; }
		public DateTime created { get; set; }
		public DateTime edited { get; set; }
		public long account_id { get; set; }
		public bool is_publish { get; set; }
		/* metafile template */
	}
}
