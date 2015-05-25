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
	[MetadataType(typeof(vacancies_professionals_meta))]	public partial class vacancies_professionals : admin.db.IDatabaseEntity
	{
		public vacancies_professionals()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private long m_vacancy_id = 0;
		internal bool mc_vacancy_id { get; private set; }
		private long m_professional_id = 0;
		internal bool mc_professional_id { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_vacancy_id = _reader["vacancy_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("vacancy_id") : 0;
			mc_vacancy_id = false;
			m_professional_id = _reader["professional_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("professional_id") : 0;
			mc_professional_id = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
			if((vacancy_id > 0) && (_meridian.vacanciesStore.Exists(vacancy_id)))
			{
				this.va_professionals_vacancies = _meridian.vacanciesStore.Get(vacancy_id);;
				this.va_professionals_vacancies.AddProfressionals(this);
			}
			if((professional_id > 0) && (_meridian.vacancy_professionalsStore.Exists(professional_id)))
			{
				this.va_pro_vacancies_vacancy_professionals = _meridian.vacancy_professionalsStore.Get(professional_id);;
				this.va_pro_vacancies_vacancy_professionals.AddVacancies(this);
			}
		}
		public void DeleteAggregations()
		{
			if(this.va_professionals_vacancies != null)
			{
				this.va_professionals_vacancies.RemoveProfressionals(this);
			}
			if(this.va_pro_vacancies_vacancy_professionals != null)
			{
				this.va_pro_vacancies_vacancy_professionals.RemoveVacancies(this);
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
			get { return "vacancies_professionals"; }
		}
		/* metafile template 
		internal class vacancies_professionals_meta
		{
			public long id { get; set; }
			public long vacancy_id { get; set; }
			public long professional_id { get; set; }
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
		public long professional_id
		{
			get
			{
				return m_professional_id;
			}
			set
			{
				if(m_professional_id != value)
				{
					m_professional_id = value != null ? value : 0;
					mc_professional_id = true;
					// call update worker thread;
				}
			}
		}
		private vacancies va_professionals_vacancies
		{
			get; set; 
		}
		public vacancies GetProfressionalsVacancie()
		{
			return va_professionals_vacancies ;
		}
		private vacancy_professionals va_pro_vacancies_vacancy_professionals
		{
			get; set; 
		}
		public vacancy_professionals GetVacanciesVacancy_professional()
		{
			return va_pro_vacancies_vacancy_professionals ;
		}
	}
}