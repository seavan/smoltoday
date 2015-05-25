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
	[MetadataType(typeof(resume_educations_meta))]	public partial class resume_educations : admin.db.IDatabaseEntity
	{
		public resume_educations()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private DateTime m_begin_date = DateTime.MinValue;
		internal bool mc_begin_date { get; private set; }
		private DateTime m_end_date = DateTime.MinValue;
		internal bool mc_end_date { get; private set; }
		private string m_address = "";
		internal bool mc_address { get; private set; }
		private long m_education_entry_id = 0;
		internal bool mc_education_entry_id { get; private set; }
		private string m_faculty = "";
		internal bool mc_faculty { get; private set; }
		private string m_specialty = "";
		internal bool mc_specialty { get; private set; }
		private long m_form_entry_id = 0;
		internal bool mc_form_entry_id { get; private set; }
		private long m_resume_id = 0;
		internal bool mc_resume_id { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_begin_date = _reader["begin_date"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("begin_date") : DateTime.MinValue;
			mc_begin_date = false;
			m_end_date = _reader["end_date"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("end_date") : DateTime.MinValue;
			mc_end_date = false;
			m_address = _reader["address"].GetType() != typeof(System.DBNull) ? _reader.GetString("address") : "";
			mc_address = false;
			m_education_entry_id = _reader["education_entry_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("education_entry_id") : 0;
			mc_education_entry_id = false;
			m_faculty = _reader["faculty"].GetType() != typeof(System.DBNull) ? _reader.GetString("faculty") : "";
			mc_faculty = false;
			m_specialty = _reader["specialty"].GetType() != typeof(System.DBNull) ? _reader.GetString("specialty") : "";
			mc_specialty = false;
			m_form_entry_id = _reader["form_entry_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("form_entry_id") : 0;
			mc_form_entry_id = false;
			m_resume_id = _reader["resume_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("resume_id") : 0;
			mc_resume_id = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
			if((resume_id > 0) && (_meridian.resumesStore.Exists(resume_id)))
			{
				this.re_educations_resumes = _meridian.resumesStore.Get(resume_id);;
				this.re_educations_resumes.AddEducations(this);
			}
		}
		public void DeleteAggregations()
		{
			if(this.re_educations_resumes != null)
			{
				this.re_educations_resumes.RemoveEducations(this);
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
			get { return "resume_educations"; }
		}
		/* metafile template 
		internal class resume_educations_meta
		{
			public long id { get; set; }
			public DateTime begin_date { get; set; }
			public DateTime end_date { get; set; }
			public string address { get; set; }
			public long education_entry_id { get; set; }
			public string faculty { get; set; }
			public string specialty { get; set; }
			public long form_entry_id { get; set; }
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
		public DateTime begin_date
		{
			get
			{
				return m_begin_date;
			}
			set
			{
				if(m_begin_date != value)
				{
					m_begin_date = value != null ? value : DateTime.MinValue;
					if(m_begin_date.Year < 1800) value = DateTime.MinValue;
					mc_begin_date = true;
					// call update worker thread;
				}
			}
		}
		public DateTime end_date
		{
			get
			{
				return m_end_date;
			}
			set
			{
				if(m_end_date != value)
				{
					m_end_date = value != null ? value : DateTime.MinValue;
					if(m_end_date.Year < 1800) value = DateTime.MinValue;
					mc_end_date = true;
					// call update worker thread;
				}
			}
		}
		public string address
		{
			get
			{
				return m_address;
			}
			set
			{
				if(m_address != value)
				{
					m_address = value != null ? value : "";
					mc_address = true;
					// call update worker thread;
				}
			}
		}
		public long education_entry_id
		{
			get
			{
				return m_education_entry_id;
			}
			set
			{
				if(m_education_entry_id != value)
				{
					m_education_entry_id = value != null ? value : 0;
					mc_education_entry_id = true;
					// call update worker thread;
				}
			}
		}
		public string faculty
		{
			get
			{
				return m_faculty;
			}
			set
			{
				if(m_faculty != value)
				{
					m_faculty = value != null ? value : "";
					mc_faculty = true;
					// call update worker thread;
				}
			}
		}
		public string specialty
		{
			get
			{
				return m_specialty;
			}
			set
			{
				if(m_specialty != value)
				{
					m_specialty = value != null ? value : "";
					mc_specialty = true;
					// call update worker thread;
				}
			}
		}
		public long form_entry_id
		{
			get
			{
				return m_form_entry_id;
			}
			set
			{
				if(m_form_entry_id != value)
				{
					m_form_entry_id = value != null ? value : 0;
					mc_form_entry_id = true;
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
		private resumes re_educations_resumes
		{
			get; set; 
		}
		public resumes GetEducationsResume()
		{
			return re_educations_resumes ;
		}
	}
}
