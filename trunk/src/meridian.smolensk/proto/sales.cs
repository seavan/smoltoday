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
	[MetadataType(typeof(sales_meta))]	public partial class sales : admin.db.IDatabaseEntity
	{
		public sales()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private string m_title = "";
		internal bool mc_title { get; private set; }
		private string m_text = "";
		internal bool mc_text { get; private set; }
		private DateTime m_publish_date = DateTime.MinValue;
		internal bool mc_publish_date { get; private set; }
		private bool m_is_main = false;
		internal bool mc_is_main { get; private set; }
		private long m_category_id = 0;
		internal bool mc_category_id { get; private set; }
		private long m_company_id = 0;
		internal bool mc_company_id { get; private set; }
		private long m_sale_type_id = 0;
		internal bool mc_sale_type_id { get; private set; }
		private int m_comment_count = 0;
		internal bool mc_comment_count { get; private set; }
		private DateTime m_start_date = DateTime.MinValue;
		internal bool mc_start_date { get; private set; }
		private DateTime m_end_date = DateTime.MinValue;
		internal bool mc_end_date { get; private set; }
		private int m_percent = 0;
		internal bool mc_percent { get; private set; }
		private int m_percent_max = 0;
		internal bool mc_percent_max { get; private set; }
		private string m_site = "";
		internal bool mc_site { get; private set; }
		private string m_phone = "";
		internal bool mc_phone { get; private set; }
		private string m_products = "";
		internal bool mc_products { get; private set; }
		private string m_work_time = "";
		internal bool mc_work_time { get; private set; }
		private string m_sales_offices = "";
		internal bool mc_sales_offices { get; private set; }
		private string m_image = "";
		internal bool mc_image { get; private set; }
		private string m_image_for_main = "";
		internal bool mc_image_for_main { get; private set; }
		public ILookupValueAspect GetLookupValueAspect(string _fieldName)
		{
			switch (_fieldName)
			{
				case "category_id": return Getcategory_idLookupValueAspect(); break;
				case "company_id": return Getcompany_idLookupValueAspect(); break;
				case "sale_type_id": return Getsale_type_idLookupValueAspect(); break;
				default: throw new SystemException("Aspect LookupValue not found in sales");
			}
		}
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_title = _reader["title"].GetType() != typeof(System.DBNull) ? _reader.GetString("title") : "";
			mc_title = false;
			m_text = _reader["text"].GetType() != typeof(System.DBNull) ? _reader.GetString("text") : "";
			mc_text = false;
			m_publish_date = _reader["publish_date"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("publish_date") : DateTime.MinValue;
			mc_publish_date = false;
			m_is_main = _reader["is_main"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("is_main") : false;
			mc_is_main = false;
			m_category_id = _reader["category_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("category_id") : 0;
			mc_category_id = false;
			m_company_id = _reader["company_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("company_id") : 0;
			mc_company_id = false;
			m_sale_type_id = _reader["sale_type_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("sale_type_id") : 0;
			mc_sale_type_id = false;
			m_comment_count = _reader["comment_count"].GetType() != typeof(System.DBNull) ? _reader.GetInt32("comment_count") : 0;
			mc_comment_count = false;
			m_start_date = _reader["start_date"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("start_date") : DateTime.MinValue;
			mc_start_date = false;
			m_end_date = _reader["end_date"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("end_date") : DateTime.MinValue;
			mc_end_date = false;
			m_percent = _reader["percent"].GetType() != typeof(System.DBNull) ? _reader.GetInt32("percent") : 0;
			mc_percent = false;
			m_percent_max = _reader["percent_max"].GetType() != typeof(System.DBNull) ? _reader.GetInt32("percent_max") : 0;
			mc_percent_max = false;
			m_site = _reader["site"].GetType() != typeof(System.DBNull) ? _reader.GetString("site") : "";
			mc_site = false;
			m_phone = _reader["phone"].GetType() != typeof(System.DBNull) ? _reader.GetString("phone") : "";
			mc_phone = false;
			m_products = _reader["products"].GetType() != typeof(System.DBNull) ? _reader.GetString("products") : "";
			mc_products = false;
			m_work_time = _reader["work_time"].GetType() != typeof(System.DBNull) ? _reader.GetString("work_time") : "";
			mc_work_time = false;
			m_sales_offices = _reader["sales_offices"].GetType() != typeof(System.DBNull) ? _reader.GetString("sales_offices") : "";
			mc_sales_offices = false;
			m_image = _reader["image"].GetType() != typeof(System.DBNull) ? _reader.GetString("image") : "";
			mc_image = false;
			m_image_for_main = _reader["image_for_main"].GetType() != typeof(System.DBNull) ? _reader.GetString("image_for_main") : "";
			mc_image_for_main = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
			if((sale_type_id > 0) && (_meridian.sale_typesStore.Exists(sale_type_id)))
			{
				this.st_sales_sale_types = _meridian.sale_typesStore.Get(sale_type_id);;
				this.st_sales_sale_types.AddSaleType(this);
			}
		}
		public void DeleteAggregations()
		{
			if(this.st_sales_sale_types != null)
			{
				this.st_sales_sale_types.RemoveSaleType(this);
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
			get { return "sales"; }
		}
		/* metafile template 
		internal class sales_meta
		{
			public long id { get; set; }
			public string title { get; set; }
			public string text { get; set; }
			public DateTime publish_date { get; set; }
			public bool is_main { get; set; }
			public long category_id { get; set; }
			public long company_id { get; set; }
			public long sale_type_id { get; set; }
			public int comment_count { get; set; }
			public DateTime start_date { get; set; }
			public DateTime end_date { get; set; }
			public int percent { get; set; }
			public int percent_max { get; set; }
			public string site { get; set; }
			public string phone { get; set; }
			public string products { get; set; }
			public string work_time { get; set; }
			public string sales_offices { get; set; }
			public string image { get; set; }
			public string image_for_main { get; set; }
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
		public string text
		{
			get
			{
				return m_text;
			}
			set
			{
				if(m_text != value)
				{
					m_text = value != null ? value : "";
					mc_text = true;
					// call update worker thread;
				}
			}
		}
		public DateTime publish_date
		{
			get
			{
				return m_publish_date;
			}
			set
			{
				if(m_publish_date != value)
				{
					m_publish_date = value != null ? value : DateTime.MinValue;
					if(m_publish_date.Year < 1800) value = DateTime.MinValue;
					mc_publish_date = true;
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
		public long category_id
		{
			get
			{
				return m_category_id;
			}
			set
			{
				if(m_category_id != value)
				{
					m_category_id = value != null ? value : 0;
					mc_category_id = true;
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
		public long sale_type_id
		{
			get
			{
				return m_sale_type_id;
			}
			set
			{
				if(m_sale_type_id != value)
				{
					m_sale_type_id = value != null ? value : 0;
					mc_sale_type_id = true;
					// call update worker thread;
				}
			}
		}
		public int comment_count
		{
			get
			{
				return m_comment_count;
			}
			set
			{
				if(m_comment_count != value)
				{
					m_comment_count = value != null ? value : 0;
					mc_comment_count = true;
					// call update worker thread;
				}
			}
		}
		public DateTime start_date
		{
			get
			{
				return m_start_date;
			}
			set
			{
				if(m_start_date != value)
				{
					m_start_date = value != null ? value : DateTime.MinValue;
					if(m_start_date.Year < 1800) value = DateTime.MinValue;
					mc_start_date = true;
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
		public int percent
		{
			get
			{
				return m_percent;
			}
			set
			{
				if(m_percent != value)
				{
					m_percent = value != null ? value : 0;
					mc_percent = true;
					// call update worker thread;
				}
			}
		}
		public int percent_max
		{
			get
			{
				return m_percent_max;
			}
			set
			{
				if(m_percent_max != value)
				{
					m_percent_max = value != null ? value : 0;
					mc_percent_max = true;
					// call update worker thread;
				}
			}
		}
		public string site
		{
			get
			{
				return m_site;
			}
			set
			{
				if(m_site != value)
				{
					m_site = value != null ? value : "";
					mc_site = true;
					// call update worker thread;
				}
			}
		}
		public string phone
		{
			get
			{
				return m_phone;
			}
			set
			{
				if(m_phone != value)
				{
					m_phone = value != null ? value : "";
					mc_phone = true;
					// call update worker thread;
				}
			}
		}
		public string products
		{
			get
			{
				return m_products;
			}
			set
			{
				if(m_products != value)
				{
					m_products = value != null ? value : "";
					mc_products = true;
					// call update worker thread;
				}
			}
		}
		public string work_time
		{
			get
			{
				return m_work_time;
			}
			set
			{
				if(m_work_time != value)
				{
					m_work_time = value != null ? value : "";
					mc_work_time = true;
					// call update worker thread;
				}
			}
		}
		public string sales_offices
		{
			get
			{
				return m_sales_offices;
			}
			set
			{
				if(m_sales_offices != value)
				{
					m_sales_offices = value != null ? value : "";
					mc_sales_offices = true;
					// call update worker thread;
				}
			}
		}
		public string image
		{
			get
			{
				return m_image;
			}
			set
			{
				if(m_image != value)
				{
					m_image = value != null ? value : "";
					mc_image = true;
					// call update worker thread;
				}
			}
		}
		public string image_for_main
		{
			get
			{
				return m_image_for_main;
			}
			set
			{
				if(m_image_for_main != value)
				{
					m_image_for_main = value != null ? value : "";
					mc_image_for_main = true;
					// call update worker thread;
				}
			}
		}
		private sale_types st_sales_sale_types
		{
			get; set; 
		}
		public sale_types GetSaleTypeSale_type()
		{
			return st_sales_sale_types ;
		}
	}
}
