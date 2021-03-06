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
	[MetadataType(typeof(regions_meta))]	public partial class regions : admin.db.IDatabaseEntity
	{
		public regions()
		{
			re_cities = new List<cities>();
			re_resumes = new List<resumes>();
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private string m_title = "";
		internal bool mc_title { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_title = _reader["title"].GetType() != typeof(System.DBNull) ? _reader.GetString("title") : "";
			mc_title = false;
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
			get { return "regions"; }
		}
		/* metafile template 
		internal class regions_meta
		{
			public long id { get; set; }
			public string title { get; set; }
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
		private List<cities> re_cities
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<cities> Cities
		{
			get { return re_cities; }
		}
		public IEnumerable<cities> GetCities()
		{
			return re_cities;
		}
		public cities AddCities(cities _item, bool _insertToStore = false)
		{
			if(re_cities.IndexOf(_item) != -1) return _item;
			re_cities.Add(_item);
			_item.region_id = id;
			if(_insertToStore && !Meridian.Default.citiesStore.Exists(_item.id))
			{
				Meridian.Default.citiesStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public cities RemoveCities(cities _item, bool _complete = false)
		{
			re_cities.Remove(_item);
			if(_complete) Meridian.Default.citiesStore.Delete(_item);
			return _item;
		}
		private List<resumes> re_resumes
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<resumes> Resumes
		{
			get { return re_resumes; }
		}
		public IEnumerable<resumes> GetResumes()
		{
			return re_resumes;
		}
		public resumes AddResumes(resumes _item, bool _insertToStore = false)
		{
			if(re_resumes.IndexOf(_item) != -1) return _item;
			re_resumes.Add(_item);
			_item.region_id = id;
			if(_insertToStore && !Meridian.Default.resumesStore.Exists(_item.id))
			{
				Meridian.Default.resumesStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public resumes RemoveResumes(resumes _item, bool _complete = false)
		{
			re_resumes.Remove(_item);
			if(_complete) Meridian.Default.resumesStore.Delete(_item);
			return _item;
		}
	}
}
