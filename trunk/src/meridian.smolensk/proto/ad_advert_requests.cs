﻿/* Automatically generated codefile, Meridian
 * Generated by magic, please do not interfere
 * Please sleep well and do not smoke. Love, Sam */

using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
	[MetadataType(typeof(ad_advert_requests_meta))]	public partial class ad_advert_requests : admin.db.IDatabaseEntity
	{
		public ad_advert_requests()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private long m_account_id = 0;
		internal bool mc_account_id { get; private set; }
		private long m_ad_id = 0;
		internal bool mc_ad_id { get; private set; }
		private bool m_in_interesting = false;
		internal bool mc_in_interesting { get; private set; }
		private bool m_pin_to_list = false;
		internal bool mc_pin_to_list { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_account_id = _reader["account_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("account_id") : 0;
			mc_account_id = false;
			m_ad_id = _reader["ad_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("ad_id") : 0;
			mc_ad_id = false;
			m_in_interesting = _reader["in_interesting"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("in_interesting") : false;
			mc_in_interesting = false;
			m_pin_to_list = _reader["pin_to_list"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("pin_to_list") : false;
			mc_pin_to_list = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
		}
		public void DeleteAggregations()
		{
		}
		public void LoadCompositions(Meridian _meridian)
		{
			string[] keyIds = null;
		}
		public void SaveCompositions(Meridian _meridian)
		{
		}
		public void DeleteCompositions(Meridian _meridian)
		{
			string[] keyIds = null;
		}
		public string ProtoName
		{
			get { return "ad_advert_requests"; }
		}
		/* metafile template 
		internal class ad_advert_requests_meta
		{
			public long id { get; set; }
			public long account_id { get; set; }
			public long ad_id { get; set; }
			public bool in_interesting { get; set; }
			public bool pin_to_list { get; set; }
		}
		 metafile template */
		public long id
		{
			get
			{
				return m_id;
			}
			set
			{
				if(m_id != value)
				{
					m_id = value != null ? value : 0;
					mc_id = true;
					// call update worker thread;
				}
			}
		}
		public long account_id
		{
			get
			{
				return m_account_id;
			}
			set
			{
				if(m_account_id != value)
				{
					m_account_id = value != null ? value : 0;
					mc_account_id = true;
					// call update worker thread;
				}
			}
		}
		public long ad_id
		{
			get
			{
				return m_ad_id;
			}
			set
			{
				if(m_ad_id != value)
				{
					m_ad_id = value != null ? value : 0;
					mc_ad_id = true;
					// call update worker thread;
				}
			}
		}
		public bool in_interesting
		{
			get
			{
				return m_in_interesting;
			}
			set
			{
				if(m_in_interesting != value)
				{
					m_in_interesting = value != null ? value : false;
					mc_in_interesting = true;
					// call update worker thread;
				}
			}
		}
		public bool pin_to_list
		{
			get
			{
				return m_pin_to_list;
			}
			set
			{
				if(m_pin_to_list != value)
				{
					m_pin_to_list = value != null ? value : false;
					mc_pin_to_list = true;
					// call update worker thread;
				}
			}
		}
	}
}
