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
	[MetadataType(typeof(photobank_cart_meta))]	public partial class photobank_cart : admin.db.IDatabaseEntity
	{
		public photobank_cart()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private long m_account_id = 0;
		internal bool mc_account_id { get; private set; }
		private long m_price_id = 0;
		internal bool mc_price_id { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_account_id = _reader["account_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("account_id") : 0;
			mc_account_id = false;
			m_price_id = _reader["price_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("price_id") : 0;
			mc_price_id = false;
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
			get { return "photobank_cart"; }
		}
		/* metafile template 
		internal class photobank_cart_meta
		{
			public long id { get; set; }
			public long account_id { get; set; }
			public long price_id { get; set; }
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
		public long price_id
		{
			get
			{
				return m_price_id;
			}
			set
			{
				if(m_price_id != value)
				{
					m_price_id = value != null ? value : 0;
					mc_price_id = true;
					// call update worker thread;
				}
			}
		}
	}
}
