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
	[MetadataType(typeof(photobank_tags_meta))]	public partial class photobank_tags : admin.db.IDatabaseEntity
	{
		public photobank_tags()
		{
			tl_photobank_tags = new List<photobank_photo_tags>();
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private string m_title = "";
		internal bool mc_title { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_title = _reader["title"].GetType() != typeof(System.DBNull) ? _reader.GetString("title") : "";
			mc_title = false;
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
			get { return "photobank_tags"; }
		}
		/* metafile template 
		internal class photobank_tags_meta
		{
			public long id { get; set; }
			public string title { get; set; }
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
		private List<photobank_photo_tags> tl_photobank_tags
		{
			get; set; 
		}
		[ScriptIgnore]
		public IEnumerable<photobank_photo_tags> TagsPhotoTags
		{
			get { return tl_photobank_tags; }
		}
		public IEnumerable<photobank_photo_tags> GetTagsPhotoTags()
		{
			return tl_photobank_tags;
		}
		public photobank_photo_tags AddTagsPhotoTags(photobank_photo_tags _item, bool _insertToStore = false)
		{
			if(tl_photobank_tags.IndexOf(_item) != -1) return _item;
			tl_photobank_tags.Add(_item);
			_item.tag_id = id;
			if(_insertToStore && !Meridian.Default.photobank_photo_tagsStore.Exists(_item.id))
			{
				Meridian.Default.photobank_photo_tagsStore.Insert(_item);
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public photobank_photo_tags RemoveTagsPhotoTags(photobank_photo_tags _item, bool _complete = false)
		{
			tl_photobank_tags.Remove(_item);
			if(_complete) Meridian.Default.photobank_photo_tagsStore.Delete(_item);
			return _item;
		}
	}
}
