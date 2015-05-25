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
	[MetadataType(typeof(cities_meta))]	public partial class cities : admin.db.IDatabaseEntity
	{
		public cities()
		{
			ci_resumes = new List<resumes>();
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private string m_title = "";
		internal bool mc_title { get; private set; }
		private long m_region_id = 0;
		internal bool mc_region_id { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_title = _reader["title"].GetType() != typeof(System.DBNull) ? _reader.GetString("title") : "";
			mc_title = false;
			m_region_id = _reader["region_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("region_id") : 0;
			mc_region_id = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
			if((region_id > 0) && (_meridian.regionsStore.Exists(region_id)))
			{
				this.re_cities_regions = _meridian.regionsStore.Get(region_id);;
				this.re_cities_regions.AddCities(this);
			}
		}
		public void DeleteAggregations()
		{
			if(this.re_cities_regions != null)
			{
				this.re_cities_regions.RemoveCities(this);
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
			get { return "cities"; }
		}
		/* metafile template 
		internal class cities_meta
		{
			public long id { get; set; }
			public string title { get; set; }
			public long region_id { get; set; }
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
		public long region_id
		{
			get
			{
				return m_region_id;
			}
			set
			{
				if(m_region_id != value)
				{
					m_region_id = value != null ? value : 0;
					mc_region_id = true;
					// call update worker thread;
				}
			}
		}
		private List<resumes> ci_resumes
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<resumes> Resumes
		{
			get { return ci_resumes; }
		}
		public IEnumerable<resumes> GetResumes()
		{
			return ci_resumes;
		}
		public resumes AddResumes(resumes _item, bool _insertToStore = false)
		{
			if(ci_resumes.IndexOf(_item) != -1) return _item;
			ci_resumes.Add(_item);
			_item.city_id = id;
			if(_insertToStore && !Meridian.Default.resumesStore.Exists(_item.id))
			{
				Meridian.Default.resumesStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public resumes RemoveResumes(resumes _item, bool _complete = false)
		{
			ci_resumes.Remove(_item);
			if(_complete) Meridian.Default.resumesStore.Delete(_item);
			return _item;
		}
		private regions re_cities_regions
		{
			get; set; 
		}
		public regions GetCitiesRegion()
		{
			return re_cities_regions ;
		}
	}
}
