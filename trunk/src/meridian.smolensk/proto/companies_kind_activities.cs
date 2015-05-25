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
	[MetadataType(typeof(companies_kind_activities_meta))]	public partial class companies_kind_activities : admin.db.IDatabaseEntity
	{
		public companies_kind_activities()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private long m_company_id = 0;
		internal bool mc_company_id { get; private set; }
		private long m_kind_activitiy_id = 0;
		internal bool mc_kind_activitiy_id { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_company_id = _reader["company_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("company_id") : 0;
			mc_company_id = false;
			m_kind_activitiy_id = _reader["kind_activitiy_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("kind_activitiy_id") : 0;
			mc_kind_activitiy_id = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
			if((company_id > 0) && (_meridian.companiesStore.Exists(company_id)))
			{
				this.co_kinds_companies = _meridian.companiesStore.Get(company_id);;
				this.co_kinds_companies.AddKinds(this);
			}
			if((kind_activitiy_id > 0) && (_meridian.company_kind_activitiesStore.Exists(kind_activitiy_id)))
			{
				this.ki_activities_company_kind_activities = _meridian.company_kind_activitiesStore.Get(kind_activitiy_id);;
				this.ki_activities_company_kind_activities.AddCompanies(this);
			}
		}
		public void DeleteAggregations()
		{
			if(this.co_kinds_companies != null)
			{
				this.co_kinds_companies.RemoveKinds(this);
			}
			if(this.ki_activities_company_kind_activities != null)
			{
				this.ki_activities_company_kind_activities.RemoveCompanies(this);
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
			get { return "companies_kind_activities"; }
		}
		/* metafile template 
		internal class companies_kind_activities_meta
		{
			public long id { get; set; }
			public long company_id { get; set; }
			public long kind_activitiy_id { get; set; }
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
		public long kind_activitiy_id
		{
			get
			{
				return m_kind_activitiy_id;
			}
			set
			{
				if(m_kind_activitiy_id != value)
				{
					m_kind_activitiy_id = value != null ? value : 0;
					mc_kind_activitiy_id = true;
					// call update worker thread;
				}
			}
		}
		private companies co_kinds_companies
		{
			get; set; 
		}
		public companies GetKindsCompanie()
		{
			return co_kinds_companies ;
		}
		private company_kind_activities ki_activities_company_kind_activities
		{
			get; set; 
		}
		public company_kind_activities GetCompaniesCompany_kind_activitie()
		{
			return ki_activities_company_kind_activities ;
		}
	}
}
