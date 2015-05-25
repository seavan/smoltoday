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
	[MetadataType(typeof(action_categories_meta))]	public partial class action_categories : admin.db.IDatabaseEntity
	{
		public action_categories()
		{
			ca_actions = new List<actions>();
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private string m_title = "";
		internal bool mc_title { get; private set; }
		private int m_order_id = 0;
		internal bool mc_order_id { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_title = _reader["title"].GetType() != typeof(System.DBNull) ? _reader.GetString("title") : "";
			mc_title = false;
			m_order_id = _reader["order_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt32("order_id") : 0;
			mc_order_id = false;
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
			get { return "action_categories"; }
		}
		/* metafile template 
		internal class action_categories_meta
		{
			public long id { get; set; }
			public string title { get; set; }
			public int order_id { get; set; }
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
		public int order_id
		{
			get
			{
				return m_order_id;
			}
			set
			{
				if(m_order_id != value)
				{
					m_order_id = value != null ? value : 0;
					mc_order_id = true;
					// call update worker thread;
				}
			}
		}
		private List<actions> ca_actions
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<actions> ActionCategory
		{
			get { return ca_actions; }
		}
		public IEnumerable<actions> GetActionCategory()
		{
			return ca_actions;
		}
		public actions AddActionCategory(actions _item, bool _insertToStore = false)
		{
			if(ca_actions.IndexOf(_item) != -1) return _item;
			ca_actions.Add(_item);
			_item.category_id = id;
			if(_insertToStore && !Meridian.Default.actionsStore.Exists(_item.id))
			{
				Meridian.Default.actionsStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public actions RemoveActionCategory(actions _item, bool _complete = false)
		{
			ca_actions.Remove(_item);
			if(_complete) Meridian.Default.actionsStore.Delete(_item);
			return _item;
		}
	}
}
