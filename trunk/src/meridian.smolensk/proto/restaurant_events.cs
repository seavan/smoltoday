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
	[MetadataType(typeof(restaurant_events_meta))]	public partial class restaurant_events : admin.db.IDatabaseEntity
	{
		public restaurant_events()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private DateTime m_date = DateTime.MinValue;
		internal bool mc_date { get; private set; }
		private string m_title = "";
		internal bool mc_title { get; private set; }
		private string m_short_desc = "";
		internal bool mc_short_desc { get; private set; }
		private long m_restaurant_id = 0;
		internal bool mc_restaurant_id { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_date = _reader["date"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("date") : DateTime.MinValue;
			mc_date = false;
			m_title = _reader["title"].GetType() != typeof(System.DBNull) ? _reader.GetString("title") : "";
			mc_title = false;
			m_short_desc = _reader["short_desc"].GetType() != typeof(System.DBNull) ? _reader.GetString("short_desc") : "";
			mc_short_desc = false;
			m_restaurant_id = _reader["restaurant_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("restaurant_id") : 0;
			mc_restaurant_id = false;
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
			get { return "restaurant_events"; }
		}
		/* metafile template 
		internal class restaurant_events_meta
		{
			public long id { get; set; }
			public DateTime date { get; set; }
			public string title { get; set; }
			public string short_desc { get; set; }
			public long restaurant_id { get; set; }
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
		public DateTime date
		{
			get
			{
				return m_date;
			}
			set
			{
				if(m_date != value)
				{
					m_date = value != null ? value : DateTime.MinValue;
					if(m_date.Year < 1800) value = DateTime.MinValue;
					mc_date = true;
					// call update worker thread;
				}
			}
		}
		public string title
		{
			get
			{
				return m_title;
			}
			set
			{
				if(m_title != value)
				{
					m_title = value != null ? value : "";
					mc_title = true;
					// call update worker thread;
				}
			}
		}
		public string short_desc
		{
			get
			{
				return m_short_desc;
			}
			set
			{
				if(m_short_desc != value)
				{
					m_short_desc = value != null ? value : "";
					mc_short_desc = true;
					// call update worker thread;
				}
			}
		}
		public long restaurant_id
		{
			get
			{
				return m_restaurant_id;
			}
			set
			{
				if(m_restaurant_id != value)
				{
					m_restaurant_id = value != null ? value : 0;
					mc_restaurant_id = true;
					// call update worker thread;
				}
			}
		}
	}
}
