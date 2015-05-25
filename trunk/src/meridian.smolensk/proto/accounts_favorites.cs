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
	[MetadataType(typeof(accounts_favorites_meta))]	public partial class accounts_favorites : admin.db.IDatabaseEntity
	{
		public accounts_favorites()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private long m_account_id = 0;
		internal bool mc_account_id { get; private set; }
		private long m_sale_id = 0;
		internal bool mc_sale_id { get; private set; }
		private long m_restaurant_id = 0;
		internal bool mc_restaurant_id { get; private set; }
		private long m_ad_id = 0;
		internal bool mc_ad_id { get; private set; }
		private long m_company_id = 0;
		internal bool mc_company_id { get; private set; }
		private long m_vacancy_id = 0;
		internal bool mc_vacancy_id { get; private set; }
		private long m_resume_id = 0;
		internal bool mc_resume_id { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_account_id = _reader["account_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("account_id") : 0;
			mc_account_id = false;
			m_sale_id = _reader["sale_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("sale_id") : 0;
			mc_sale_id = false;
			m_restaurant_id = _reader["restaurant_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("restaurant_id") : 0;
			mc_restaurant_id = false;
			m_ad_id = _reader["ad_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("ad_id") : 0;
			mc_ad_id = false;
			m_company_id = _reader["company_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("company_id") : 0;
			mc_company_id = false;
			m_vacancy_id = _reader["vacancy_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("vacancy_id") : 0;
			mc_vacancy_id = false;
			m_resume_id = _reader["resume_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("resume_id") : 0;
			mc_resume_id = false;
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
			get { return "accounts_favorites"; }
		}
		/* metafile template 
		internal class accounts_favorites_meta
		{
			public long id { get; set; }
			public long account_id { get; set; }
			public long sale_id { get; set; }
			public long restaurant_id { get; set; }
			public long ad_id { get; set; }
			public long company_id { get; set; }
			public long vacancy_id { get; set; }
			public long resume_id { get; set; }
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
		public long sale_id
		{
			get
			{
				return m_sale_id;
			}
			set
			{
				if(m_sale_id != value)
				{
					m_sale_id = value != null ? value : 0;
					mc_sale_id = true;
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
		public long company_id
		{
			get
			{
				return m_company_id;
			}
			set
			{
				if(m_company_id != value)
				{
					m_company_id = value != null ? value : 0;
					mc_company_id = true;
					// call update worker thread;
				}
			}
		}
		public long vacancy_id
		{
			get
			{
				return m_vacancy_id;
			}
			set
			{
				if(m_vacancy_id != value)
				{
					m_vacancy_id = value != null ? value : 0;
					mc_vacancy_id = true;
					// call update worker thread;
				}
			}
		}
		public long resume_id
		{
			get
			{
				return m_resume_id;
			}
			set
			{
				if(m_resume_id != value)
				{
					m_resume_id = value != null ? value : 0;
					mc_resume_id = true;
					// call update worker thread;
				}
			}
		}
	}
}