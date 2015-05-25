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
	[MetadataType(typeof(vacancy_professionals_meta))]	public partial class vacancy_professionals : admin.db.IDatabaseEntity
	{
		public vacancy_professionals()
		{
			va_pro_children = new List<vacancy_professionals>();
			va_pro_vacancies = new List<vacancies_professionals>();
			va_pro_resumes = new List<resumes_professionals>();
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private string m_title = "";
		internal bool mc_title { get; private set; }
		private long m_parent_id = 0;
		internal bool mc_parent_id { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_title = _reader["title"].GetType() != typeof(System.DBNull) ? _reader.GetString("title") : "";
			mc_title = false;
			m_parent_id = _reader["parent_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("parent_id") : 0;
			mc_parent_id = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
			if((parent_id > 0) && (_meridian.vacancy_professionalsStore.Exists(parent_id)))
			{
				this.va_pro_children_vacancy_professionals = _meridian.vacancy_professionalsStore.Get(parent_id);;
				this.va_pro_children_vacancy_professionals.AddChildren(this);
			}
		}
		public void DeleteAggregations()
		{
			if(this.va_pro_children_vacancy_professionals != null)
			{
				this.va_pro_children_vacancy_professionals.RemoveChildren(this);
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
			get { return "vacancy_professionals"; }
		}
		/* metafile template 
		internal class vacancy_professionals_meta
		{
			public long id { get; set; }
			public string title { get; set; }
			public long parent_id { get; set; }
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
		public long parent_id
		{
			get
			{
				return m_parent_id;
			}
			set
			{
				if(m_parent_id != value)
				{
					m_parent_id = value != null ? value : 0;
					mc_parent_id = true;
					// call update worker thread;
				}
			}
		}
		private List<vacancy_professionals> va_pro_children
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<vacancy_professionals> Children
		{
			get { return va_pro_children; }
		}
		public IEnumerable<vacancy_professionals> GetChildren()
		{
			return va_pro_children;
		}
		public vacancy_professionals AddChildren(vacancy_professionals _item, bool _insertToStore = false)
		{
			if(va_pro_children.IndexOf(_item) != -1) return _item;
			va_pro_children.Add(_item);
			_item.parent_id = id;
			if(_insertToStore && !Meridian.Default.vacancy_professionalsStore.Exists(_item.id))
			{
				Meridian.Default.vacancy_professionalsStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public vacancy_professionals RemoveChildren(vacancy_professionals _item, bool _complete = false)
		{
			va_pro_children.Remove(_item);
			if(_complete) Meridian.Default.vacancy_professionalsStore.Delete(_item);
			return _item;
		}
		private List<vacancies_professionals> va_pro_vacancies
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<vacancies_professionals> Vacancies
		{
			get { return va_pro_vacancies; }
		}
		public IEnumerable<vacancies_professionals> GetVacancies()
		{
			return va_pro_vacancies;
		}
		public vacancies_professionals AddVacancies(vacancies_professionals _item, bool _insertToStore = false)
		{
			if(va_pro_vacancies.IndexOf(_item) != -1) return _item;
			va_pro_vacancies.Add(_item);
			_item.professional_id = id;
			if(_insertToStore && !Meridian.Default.vacancies_professionalsStore.Exists(_item.id))
			{
				Meridian.Default.vacancies_professionalsStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public vacancies_professionals RemoveVacancies(vacancies_professionals _item, bool _complete = false)
		{
			va_pro_vacancies.Remove(_item);
			if(_complete) Meridian.Default.vacancies_professionalsStore.Delete(_item);
			return _item;
		}
		private List<resumes_professionals> va_pro_resumes
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<resumes_professionals> Resumes
		{
			get { return va_pro_resumes; }
		}
		public IEnumerable<resumes_professionals> GetResumes()
		{
			return va_pro_resumes;
		}
		public resumes_professionals AddResumes(resumes_professionals _item, bool _insertToStore = false)
		{
			if(va_pro_resumes.IndexOf(_item) != -1) return _item;
			va_pro_resumes.Add(_item);
			_item.professional_id = id;
			if(_insertToStore && !Meridian.Default.resumes_professionalsStore.Exists(_item.id))
			{
				Meridian.Default.resumes_professionalsStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public resumes_professionals RemoveResumes(resumes_professionals _item, bool _complete = false)
		{
			va_pro_resumes.Remove(_item);
			if(_complete) Meridian.Default.resumes_professionalsStore.Delete(_item);
			return _item;
		}
		private vacancy_professionals va_pro_children_vacancy_professionals
		{
			get; set; 
		}
		public vacancy_professionals GetChildrenVacancy_professional()
		{
			return va_pro_children_vacancy_professionals ;
		}
	}
}
