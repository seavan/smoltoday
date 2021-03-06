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
	[MetadataType(typeof(ad_photos_meta))]	public partial class ad_photos : admin.db.IDatabaseEntity
	{
		public ad_photos()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private long m_ad_id = 0;
		internal bool mc_ad_id { get; private set; }
		private string m_preview = "";
		internal bool mc_preview { get; private set; }
		private string m_photo = "";
		internal bool mc_photo { get; private set; }
		private string m_original = "";
		internal bool mc_original { get; private set; }
		private DateTime m_create_date = DateTime.MinValue;
		internal bool mc_create_date { get; private set; }
		private bool m_is_main = false;
		internal bool mc_is_main { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_ad_id = _reader["ad_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("ad_id") : 0;
			mc_ad_id = false;
			m_preview = _reader["preview"].GetType() != typeof(System.DBNull) ? _reader.GetString("preview") : "";
			mc_preview = false;
			m_photo = _reader["photo"].GetType() != typeof(System.DBNull) ? _reader.GetString("photo") : "";
			mc_photo = false;
			m_original = _reader["original"].GetType() != typeof(System.DBNull) ? _reader.GetString("original") : "";
			mc_original = false;
			m_create_date = _reader["create_date"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("create_date") : DateTime.MinValue;
			mc_create_date = false;
			m_is_main = _reader["is_main"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("is_main") : false;
			mc_is_main = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
			if((ad_id > 0) && (_meridian.ad_advertismentsStore.Exists(ad_id)))
			{
				this.adverts_ad_photos_ad_advertisments = _meridian.ad_advertismentsStore.Get(ad_id);;
				this.adverts_ad_photos_ad_advertisments.AddPhotos(this);
			}
		}
		public void DeleteAggregations()
		{
			if(this.adverts_ad_photos_ad_advertisments != null)
			{
				this.adverts_ad_photos_ad_advertisments.RemovePhotos(this);
			}
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
			get { return "ad_photos"; }
		}
		/* metafile template 
		internal class ad_photos_meta
		{
			public long id { get; set; }
			public long ad_id { get; set; }
			public string preview { get; set; }
			public string photo { get; set; }
			public string original { get; set; }
			public DateTime create_date { get; set; }
			public bool is_main { get; set; }
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
		public string preview
		{
			get
			{
				return m_preview;
			}
			set
			{
				if(m_preview != value)
				{
					m_preview = value != null ? value : "";
					mc_preview = true;
					// call update worker thread;
				}
			}
		}
		public string photo
		{
			get
			{
				return m_photo;
			}
			set
			{
				if(m_photo != value)
				{
					m_photo = value != null ? value : "";
					mc_photo = true;
					// call update worker thread;
				}
			}
		}
		public string original
		{
			get
			{
				return m_original;
			}
			set
			{
				if(m_original != value)
				{
					m_original = value != null ? value : "";
					mc_original = true;
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
		public bool is_main
		{
			get
			{
				return m_is_main;
			}
			set
			{
				if(m_is_main != value)
				{
					m_is_main = value != null ? value : false;
					mc_is_main = true;
					// call update worker thread;
				}
			}
		}
		private ad_advertisments adverts_ad_photos_ad_advertisments
		{
			get; set; 
		}
		public ad_advertisments GetPhotosAd_advertisment()
		{
			return adverts_ad_photos_ad_advertisments ;
		}
	}
}
