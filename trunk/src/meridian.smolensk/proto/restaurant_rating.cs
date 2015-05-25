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
	[MetadataType(typeof(restaurant_rating_meta))]	public partial class restaurant_rating : admin.db.IDatabaseEntity
	{
		public restaurant_rating()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private long m_account_id = 0;
		internal bool mc_account_id { get; private set; }
		private long m_restaurant_id = 0;
		internal bool mc_restaurant_id { get; private set; }
		private int m_rating = 0;
		internal bool mc_rating { get; private set; }
		private DateTime m_create_date = DateTime.MinValue;
		internal bool mc_create_date { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_account_id = _reader["account_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("account_id") : 0;
			mc_account_id = false;
			m_restaurant_id = _reader["restaurant_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("restaurant_id") : 0;
			mc_restaurant_id = false;
			m_rating = _reader["rating"].GetType() != typeof(System.DBNull) ? _reader.GetInt32("rating") : 0;
			mc_rating = false;
			m_create_date = _reader["create_date"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("create_date") : DateTime.MinValue;
			mc_create_date = false;
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
			get { return "restaurant_rating"; }
		}
		/* metafile template 
		internal class restaurant_rating_meta
		{
			public long id { get; set; }
			public long account_id { get; set; }
			public long restaurant_id { get; set; }
			public int rating { get; set; }
			public DateTime create_date { get; set; }
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
		public int rating
		{
			get
			{
				return m_rating;
			}
			set
			{
				if(m_rating != value)
				{
					m_rating = value != null ? value : 0;
					mc_rating = true;
					// call update worker thread;
				}
			}
		}
		public DateTime create_date
		{
			get
			{
				return m_create_date;
			}
			set
			{
				if(m_create_date != value)
				{
					m_create_date = value != null ? value : DateTime.MinValue;
					if(m_create_date.Year < 1800) value = DateTime.MinValue;
					mc_create_date = true;
					// call update worker thread;
				}
			}
		}
	}
}
