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
	[MetadataType(typeof(restaurant_entry_categories_meta))]	public partial class restaurant_entry_categories : admin.db.IDatabaseEntity
	{
		public restaurant_entry_categories()
		{
			re_entries_values = new List<restaurant_entries>();
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private string m_title = "";
		internal bool mc_title { get; private set; }
		private bool m_is_multiple = false;
		internal bool mc_is_multiple { get; private set; }
		private bool m_is_anyvalue = false;
		internal bool mc_is_anyvalue { get; private set; }
		private bool m_is_visible = false;
		internal bool mc_is_visible { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_title = _reader["title"].GetType() != typeof(System.DBNull) ? _reader.GetString("title") : "";
			mc_title = false;
			m_is_multiple = _reader["is_multiple"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("is_multiple") : false;
			mc_is_multiple = false;
			m_is_anyvalue = _reader["is_anyvalue"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("is_anyvalue") : false;
			mc_is_anyvalue = false;
			m_is_visible = _reader["is_visible"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("is_visible") : false;
			mc_is_visible = false;
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
			get { return "restaurant_entry_categories"; }
		}
		/* metafile template 
		internal class restaurant_entry_categories_meta
		{
			public long id { get; set; }
			public string title { get; set; }
			public bool is_multiple { get; set; }
			public bool is_anyvalue { get; set; }
			public bool is_visible { get; set; }
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
		public bool is_multiple
		{
			get
			{
				return m_is_multiple;
			}
			set
			{
				if(m_is_multiple != value)
				{
					m_is_multiple = value != null ? value : false;
					mc_is_multiple = true;
					// call update worker thread;
				}
			}
		}
		public bool is_anyvalue
		{
			get
			{
				return m_is_anyvalue;
			}
			set
			{
				if(m_is_anyvalue != value)
				{
					m_is_anyvalue = value != null ? value : false;
					mc_is_anyvalue = true;
					// call update worker thread;
				}
			}
		}
		public bool is_visible
		{
			get
			{
				return m_is_visible;
			}
			set
			{
				if(m_is_visible != value)
				{
					m_is_visible = value != null ? value : false;
					mc_is_visible = true;
					// call update worker thread;
				}
			}
		}
		private List<restaurant_entries> re_entries_values
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<restaurant_entries> EntriesValues
		{
			get { return re_entries_values; }
		}
		public IEnumerable<restaurant_entries> GetEntriesValues()
		{
			return re_entries_values;
		}
		public restaurant_entries AddEntriesValues(restaurant_entries _item, bool _insertToStore = false)
		{
			if(re_entries_values.IndexOf(_item) != -1) return _item;
			re_entries_values.Add(_item);
			_item.restaurant_entry_category_id = id;
			if(_insertToStore && !Meridian.Default.restaurant_entriesStore.Exists(_item.id))
			{
				Meridian.Default.restaurant_entriesStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public restaurant_entries RemoveEntriesValues(restaurant_entries _item, bool _complete = false)
		{
			re_entries_values.Remove(_item);
			if(_complete) Meridian.Default.restaurant_entriesStore.Delete(_item);
			return _item;
		}
	}
}
