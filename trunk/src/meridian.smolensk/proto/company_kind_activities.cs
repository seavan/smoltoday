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
	[MetadataType(typeof(company_kind_activities_meta))]	public partial class company_kind_activities : admin.db.IDatabaseEntity
	{
		public company_kind_activities()
		{
			ki_activities = new List<companies_kind_activities>();
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private string m_name = "";
		internal bool mc_name { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_name = _reader["name"].GetType() != typeof(System.DBNull) ? _reader.GetString("name") : "";
			mc_name = false;
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
			get { return "company_kind_activities"; }
		}
		/* metafile template 
		internal class company_kind_activities_meta
		{
			public long id { get; set; }
			public string name { get; set; }
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
		public string name
		{
			get
			{
				return m_name;
			}
			set
			{
				if(m_name != value)
				{
					m_name = value != null ? value : "";
					mc_name = true;
					// call update worker thread;
				}
			}
		}
		private List<companies_kind_activities> ki_activities
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<companies_kind_activities> Companies
		{
			get { return ki_activities; }
		}
		public IEnumerable<companies_kind_activities> GetCompanies()
		{
			return ki_activities;
		}
		public companies_kind_activities AddCompanies(companies_kind_activities _item, bool _insertToStore = false)
		{
			if(ki_activities.IndexOf(_item) != -1) return _item;
			ki_activities.Add(_item);
			_item.kind_activitiy_id = id;
			if(_insertToStore && !Meridian.Default.companies_kind_activitiesStore.Exists(_item.id))
			{
				Meridian.Default.companies_kind_activitiesStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public companies_kind_activities RemoveCompanies(companies_kind_activities _item, bool _complete = false)
		{
			ki_activities.Remove(_item);
			if(_complete) Meridian.Default.companies_kind_activitiesStore.Delete(_item);
			return _item;
		}
	}
}