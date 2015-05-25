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
	[MetadataType(typeof(blog_comments_meta))]	public partial class blog_comments : admin.db.IDatabaseEntity
	{
		public blog_comments()
		{
			cb_child_comments = new List<blog_comments>();
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private int m_left_key = 0;
		internal bool mc_left_key { get; private set; }
		private int m_right_key = 0;
		internal bool mc_right_key { get; private set; }
		private int m_level = 0;
		internal bool mc_level { get; private set; }
		private bool m_delete = false;
		internal bool mc_delete { get; private set; }
		private DateTime m_create_date = DateTime.MinValue;
		internal bool mc_create_date { get; private set; }
		private long m_account_id = 0;
		internal bool mc_account_id { get; private set; }
		private string m_text = "";
		internal bool mc_text { get; private set; }
		private long m_parent_id = 0;
		internal bool mc_parent_id { get; private set; }
		private long m_blog_id = 0;
		internal bool mc_blog_id { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_left_key = _reader["left_key"].GetType() != typeof(System.DBNull) ? _reader.GetInt32("left_key") : 0;
			mc_left_key = false;
			m_right_key = _reader["right_key"].GetType() != typeof(System.DBNull) ? _reader.GetInt32("right_key") : 0;
			mc_right_key = false;
			m_level = _reader["level"].GetType() != typeof(System.DBNull) ? _reader.GetInt32("level") : 0;
			mc_level = false;
			m_delete = _reader["delete"].GetType() != typeof(System.DBNull) ? _reader.GetBoolean("delete") : false;
			mc_delete = false;
			m_create_date = _reader["create_date"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("create_date") : DateTime.MinValue;
			mc_create_date = false;
			m_account_id = _reader["account_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("account_id") : 0;
			mc_account_id = false;
			m_text = _reader["text"].GetType() != typeof(System.DBNull) ? _reader.GetString("text") : "";
			mc_text = false;
			m_parent_id = _reader["parent_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("parent_id") : 0;
			mc_parent_id = false;
			m_blog_id = _reader["blog_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("blog_id") : 0;
			mc_blog_id = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
			if((blog_id > 0) && (_meridian.blogsStore.Exists(blog_id)))
			{
				this.b_comments_blogs = _meridian.blogsStore.Get(blog_id);;
				this.b_comments_blogs.AddBlogComments(this);
			}
			if((account_id > 0) && (_meridian.accountsStore.Exists(account_id)))
			{
				this.u_blog_comments_accounts = _meridian.accountsStore.Get(account_id);;
				this.u_blog_comments_accounts.AddBlogComments(this);
			}
			if((parent_id > 0) && (_meridian.blog_commentsStore.Exists(parent_id)))
			{
				this.cb_child_comments_blog_comments = _meridian.blog_commentsStore.Get(parent_id);;
				this.cb_child_comments_blog_comments.AddBlogChildComments(this);
			}
		}
		public void DeleteAggregations()
		{
			if(this.b_comments_blogs != null)
			{
				this.b_comments_blogs.RemoveBlogComments(this);
			}
			if(this.u_blog_comments_accounts != null)
			{
				this.u_blog_comments_accounts.RemoveBlogComments(this);
			}
			if(this.cb_child_comments_blog_comments != null)
			{
				this.cb_child_comments_blog_comments.RemoveBlogChildComments(this);
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
			get { return "blog_comments"; }
		}
		/* metafile template 
		internal class blog_comments_meta
		{
			public long id { get; set; }
			public int left_key { get; set; }
			public int right_key { get; set; }
			public int level { get; set; }
			public bool delete { get; set; }
			public DateTime create_date { get; set; }
			public long account_id { get; set; }
			public string text { get; set; }
			public long parent_id { get; set; }
			public long blog_id { get; set; }
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
		public int left_key
		{
			get
			{
				return m_left_key;
			}
			set
			{
				if(m_left_key != value)
				{
					m_left_key = value != null ? value : 0;
					mc_left_key = true;
					// call update worker thread;
				}
			}
		}
		public int right_key
		{
			get
			{
				return m_right_key;
			}
			set
			{
				if(m_right_key != value)
				{
					m_right_key = value != null ? value : 0;
					mc_right_key = true;
					// call update worker thread;
				}
			}
		}
		public int level
		{
			get
			{
				return m_level;
			}
			set
			{
				if(m_level != value)
				{
					m_level = value != null ? value : 0;
					mc_level = true;
					// call update worker thread;
				}
			}
		}
		public bool delete
		{
			get
			{
				return m_delete;
			}
			set
			{
				if(m_delete != value)
				{
					m_delete = value != null ? value : false;
					mc_delete = true;
					// call update worker thread;
				}
			}
		}
		public DateTime create_date
		{
			get
			{
				return m_create_date;
			}
			set
			{
				if(m_create_date != value)
				{
					m_create_date = value != null ? value : DateTime.MinValue;
					if(m_create_date.Year < 1800) value = DateTime.MinValue;
					mc_create_date = true;
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
		public long blog_id
		{
			get
			{
				return m_blog_id;
			}
			set
			{
				if(m_blog_id != value)
				{
					m_blog_id = value != null ? value : 0;
					mc_blog_id = true;
					// call update worker thread;
				}
			}
		}
		private List<blog_comments> cb_child_comments
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<blog_comments> BlogChildComments
		{
			get { return cb_child_comments; }
		}
		public IEnumerable<blog_comments> GetBlogChildComments()
		{
			return cb_child_comments;
		}
		public blog_comments AddBlogChildComments(blog_comments _item, bool _insertToStore = false)
		{
			if(cb_child_comments.IndexOf(_item) != -1) return _item;
			cb_child_comments.Add(_item);
			_item.parent_id = id;
			if(_insertToStore && !Meridian.Default.blog_commentsStore.Exists(_item.id))
			{
				Meridian.Default.blog_commentsStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public blog_comments RemoveBlogChildComments(blog_comments _item, bool _complete = false)
		{
			cb_child_comments.Remove(_item);
			if(_complete) Meridian.Default.blog_commentsStore.Delete(_item);
			return _item;
		}
		private blogs b_comments_blogs
		{
			get; set; 
		}
		public blogs GetBlogCommentsBlog()
		{
			return b_comments_blogs ;
		}
		private accounts u_blog_comments_accounts
		{
			get; set; 
		}
		public accounts GetBlogCommentsAccount()
		{
			return u_blog_comments_accounts ;
		}
		private blog_comments cb_child_comments_blog_comments
		{
			get; set; 
		}
		public blog_comments GetBlogChildCommentsBlog_comment()
		{
			return cb_child_comments_blog_comments ;
		}
	}
}