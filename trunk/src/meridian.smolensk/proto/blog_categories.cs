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
	[MetadataType(typeof(blog_categories_meta))]	public partial class blog_categories : admin.db.IDatabaseEntity
	{
		public blog_categories()
		{
			uc_blogs = new List<blogs>();
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private string m_key = "";
		internal bool mc_key { get; private set; }
		private string m_title = "";
		internal bool mc_title { get; private set; }
		private int m_order_id = 0;
		internal bool mc_order_id { get; private set; }
		private bool m_is_sub = false;
		internal bool mc_is_sub { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_key = _reader["key"].GetType() != typeof(System.DBNull) ? _reader.GetString("key") : "";
			mc_key = false;
			m_title = _reader["title"].GetType() != typeof(System.DBNull) ? _reader.GetString("title") : "";
			mc_title = false;
			m_order_id = _reader["order_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt32("order_id") : 0;
			mc_order_id = false;
			m_is_sub = _reader["is_sub"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("is_sub") : false;
			mc_is_sub = false;
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
			get { return "blog_categories"; }
		}
		/* metafile template 
		internal class blog_categories_meta
		{
			public long id { get; set; }
			public string key { get; set; }
			public string title { get; set; }
			public int order_id { get; set; }
			public bool is_sub { get; set; }
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
		public string key
		{
			get
			{
				return m_key;
			}
			set
			{
				if(m_key != value)
				{
					m_key = value != null ? value : "";
					mc_key = true;
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
		public bool is_sub
		{
			get
			{
				return m_is_sub;
			}
			set
			{
				if(m_is_sub != value)
				{
					m_is_sub = value != null ? value : false;
					mc_is_sub = true;
					// call update worker thread;
				}
			}
		}
		private List<blogs> uc_blogs
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<blogs> CategoryBlog
		{
			get { return uc_blogs; }
		}
		public IEnumerable<blogs> GetCategoryBlog()
		{
			return uc_blogs;
		}
		public blogs AddCategoryBlog(blogs _item, bool _insertToStore = false)
		{
			if(uc_blogs.IndexOf(_item) != -1) return _item;
			uc_blogs.Add(_item);
			_item.category_id = id;
			if(_insertToStore && !Meridian.Default.blogsStore.Exists(_item.id))
			{
				Meridian.Default.blogsStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public blogs RemoveCategoryBlog(blogs _item, bool _complete = false)
		{
			uc_blogs.Remove(_item);
			if(_complete) Meridian.Default.blogsStore.Delete(_item);
			return _item;
		}
	}
}
