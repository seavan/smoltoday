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
	[MetadataType(typeof(ad_advertisments_meta))]	public partial class ad_advertisments : admin.db.IDatabaseEntity
	{
		public ad_advertisments()
		{
			adverts_ad_fields = new List<ad_fields>();
			adverts_ad_photos = new List<ad_photos>();
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private long m_account_id = 0;
		internal bool mc_account_id { get; private set; }
		private long m_category_id = 0;
		internal bool mc_category_id { get; private set; }
		private DateTime m_created_date = DateTime.MinValue;
		internal bool mc_created_date { get; private set; }
		private string m_title = "";
		internal bool mc_title { get; private set; }
		private string m_description = "";
		internal bool mc_description { get; private set; }
		private double m_price = (double)0;
		internal bool mc_price { get; private set; }
		private string m_name = "";
		internal bool mc_name { get; private set; }
		private string m_phone = "";
		internal bool mc_phone { get; private set; }
		private string m_email = "";
		internal bool mc_email { get; private set; }
		private int m_view_count = 0;
		internal bool mc_view_count { get; private set; }
		private bool m_on_main = false;
		internal bool mc_on_main { get; private set; }
		private bool m_in_interesting = false;
		internal bool mc_in_interesting { get; private set; }
		private bool m_pin_to_list = false;
		internal bool mc_pin_to_list { get; private set; }
		private string m_url = "";
		internal bool mc_url { get; private set; }
		public ILookupValueAspect GetLookupValueAspect(string _fieldName)
		{
			switch (_fieldName)
			{
				case "category_id": return Getcategory_idLookupValueAspect(); break;
				case "account_id": return Getaccount_idLookupValueAspect(); break;
				default: throw new SystemException("Aspect LookupValue not found in ad_advertisments");
			}
		}
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_account_id = _reader["account_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("account_id") : 0;
			mc_account_id = false;
			m_category_id = _reader["category_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("category_id") : 0;
			mc_category_id = false;
			m_created_date = _reader["created_date"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("created_date") : DateTime.MinValue;
			mc_created_date = false;
			m_title = _reader["title"].GetType() != typeof(System.DBNull) ? _reader.GetString("title") : "";
			mc_title = false;
			m_description = _reader["description"].GetType() != typeof(System.DBNull) ? _reader.GetString("description") : "";
			mc_description = false;
			m_price = _reader["price"].GetType() != typeof(System.DBNull) ? _reader.GetFloat("price") : (double)0;
			mc_price = false;
			m_name = _reader["name"].GetType() != typeof(System.DBNull) ? _reader.GetString("name") : "";
			mc_name = false;
			m_phone = _reader["phone"].GetType() != typeof(System.DBNull) ? _reader.GetString("phone") : "";
			mc_phone = false;
			m_email = _reader["email"].GetType() != typeof(System.DBNull) ? _reader.GetString("email") : "";
			mc_email = false;
			m_view_count = _reader["view_count"].GetType() != typeof(System.DBNull) ? _reader.GetInt32("view_count") : 0;
			mc_view_count = false;
			m_on_main = _reader["on_main"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("on_main") : false;
			mc_on_main = false;
			m_in_interesting = _reader["in_interesting"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("in_interesting") : false;
			mc_in_interesting = false;
			m_pin_to_list = _reader["pin_to_list"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("pin_to_list") : false;
			mc_pin_to_list = false;
			m_url = _reader["url"].GetType() != typeof(System.DBNull) ? _reader.GetString("url") : "";
			mc_url = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
			if((category_id > 0) && (_meridian.ad_categoriesStore.Exists(category_id)))
			{
				this.adverts_category_advertisments_ad_categories = _meridian.ad_categoriesStore.Get(category_id);;
				this.adverts_category_advertisments_ad_categories.AddAdvertisments(this);
			}
		}
		public void DeleteAggregations()
		{
			if(this.adverts_category_advertisments_ad_categories != null)
			{
				this.adverts_category_advertisments_ad_categories.RemoveAdvertisments(this);
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
			get { return "ad_advertisments"; }
		}
		/* metafile template 
		internal class ad_advertisments_meta
		{
			public long id { get; set; }
			public long account_id { get; set; }
			public long category_id { get; set; }
			public DateTime created_date { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public double price { get; set; }
			public string name { get; set; }
			public string phone { get; set; }
			public string email { get; set; }
			public int view_count { get; set; }
			public bool on_main { get; set; }
			public bool in_interesting { get; set; }
			public bool pin_to_list { get; set; }
			public string url { get; set; }
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
		public DateTime created_date
		{
			get
			{
				return m_created_date;
			}
			set
			{
				if(m_created_date != value)
				{
					m_created_date = value != null ? value : DateTime.MinValue;
					if(m_created_date.Year < 1800) value = DateTime.MinValue;
					mc_created_date = true;
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
		public string description
		{
			get
			{
				return m_description;
			}
			set
			{
				if(m_description != value)
				{
					m_description = value != null ? value : "";
					mc_description = true;
					// call update worker thread;
				}
			}
		}
		public double price
		{
			get
			{
				return m_price;
			}
			set
			{
				if(m_price != value)
				{
					m_price = value != null ? value : (double)0;
					mc_price = true;
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
		public string email
		{
			get
			{
				return m_email;
			}
			set
			{
				if(m_email != value)
				{
					m_email = value != null ? value : "";
					mc_email = true;
					// call update worker thread;
				}
			}
		}
		public int view_count
		{
			get
			{
				return m_view_count;
			}
			set
			{
				if(m_view_count != value)
				{
					m_view_count = value != null ? value : 0;
					mc_view_count = true;
					// call update worker thread;
				}
			}
		}
		public bool on_main
		{
			get
			{
				return m_on_main;
			}
			set
			{
				if(m_on_main != value)
				{
					m_on_main = value != null ? value : false;
					mc_on_main = true;
					// call update worker thread;
				}
			}
		}
		public bool in_interesting
		{
			get
			{
				return m_in_interesting;
			}
			set
			{
				if(m_in_interesting != value)
				{
					m_in_interesting = value != null ? value : false;
					mc_in_interesting = true;
					// call update worker thread;
				}
			}
		}
		public bool pin_to_list
		{
			get
			{
				return m_pin_to_list;
			}
			set
			{
				if(m_pin_to_list != value)
				{
					m_pin_to_list = value != null ? value : false;
					mc_pin_to_list = true;
					// call update worker thread;
				}
			}
		}
		public string url
		{
			get
			{
				return m_url;
			}
			set
			{
				if(m_url != value)
				{
					m_url = value != null ? value : "";
					mc_url = true;
					// call update worker thread;
				}
			}
		}
		private List<ad_fields> adverts_ad_fields
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<ad_fields> AdFields
		{
			get { return adverts_ad_fields; }
		}
		public IEnumerable<ad_fields> GetAdFields()
		{
			return adverts_ad_fields;
		}
		public ad_fields AddAdFields(ad_fields _item, bool _insertToStore = false)
		{
			if(adverts_ad_fields.IndexOf(_item) != -1) return _item;
			adverts_ad_fields.Add(_item);
			_item.ad_id = id;
			if(_insertToStore && !Meridian.Default.ad_fieldsStore.Exists(_item.id))
			{
				Meridian.Default.ad_fieldsStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public ad_fields RemoveAdFields(ad_fields _item, bool _complete = false)
		{
			adverts_ad_fields.Remove(_item);
			if(_complete) Meridian.Default.ad_fieldsStore.Delete(_item);
			return _item;
		}
		private List<ad_photos> adverts_ad_photos
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<ad_photos> Photos
		{
			get { return adverts_ad_photos; }
		}
		public IEnumerable<ad_photos> GetPhotos()
		{
			return adverts_ad_photos;
		}
		public ad_photos AddPhotos(ad_photos _item, bool _insertToStore = false)
		{
			if(adverts_ad_photos.IndexOf(_item) != -1) return _item;
			adverts_ad_photos.Add(_item);
			_item.ad_id = id;
			if(_insertToStore && !Meridian.Default.ad_photosStore.Exists(_item.id))
			{
				Meridian.Default.ad_photosStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public ad_photos RemovePhotos(ad_photos _item, bool _complete = false)
		{
			adverts_ad_photos.Remove(_item);
			if(_complete) Meridian.Default.ad_photosStore.Delete(_item);
			return _item;
		}
		private ad_categories adverts_category_advertisments_ad_categories
		{
			get; set; 
		}
		public ad_categories GetAdvertismentsAd_categorie()
		{
			return adverts_category_advertisments_ad_categories ;
		}
	}
}
