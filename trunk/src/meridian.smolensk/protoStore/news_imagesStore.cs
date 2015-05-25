﻿/* Automatically generated codefile, Meridian
 * Generated by magic, please do not interfere
 * Please sleep well and do not smoke. Love, Sam */

using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;

namespace meridian.smolensk.protoStore
{
	public partial class news_imagesStore : Meridian.IEntityStore, admin.db.IDataService<proto.news_images>
	{
		public news_imagesStore()
		{
			m_Items = new SortedList<long, proto.news_images>();
		}
		private SortedList<long, proto.news_images> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.news_images> GetAll()
		{
			return Queryable.AsQueryable<proto.news_images>(All());
		}
		public proto.news_images GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.news_images>.Insert(proto.news_images item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.news_images>.Delete(proto.news_images item)
		{
			Delete(item);
		}
		public proto.news_images CreateItem()
		{
			return new proto.news_images() {   };
		}
		public void AbortItem(proto.news_images item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.news_images>.Update(proto.news_images item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.news_images);
		}
		public void DeleteById(long _id)
		{
			Delete(Get(_id));
		}
		public void UpdateById(long _id)
		{
			Update(Get(_id));
		}
		public void LoadAggregations(Meridian _meridian)
		{
			foreach(var item in m_Items.Values)
			{
				item.LoadAggregations(_meridian);
			}
		}
		public void Select(MySqlConnection _connection)
		{
			var cmd = new MySqlCommand("SELECT `id`, `news_id`, `small_thumbnail`, `medium_thumbnail`, `large_thumbnail`, `normal_thumbnail`, `original`, `description`, `url`, `alt`, `inline`, `guid` FROM news_images");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.news_images();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.news_images Insert(MySqlConnection _connection, proto.news_images _item)
		{
			var cmd = new MySqlCommand("INSERT INTO news_images ( `news_id`, `small_thumbnail`, `medium_thumbnail`, `large_thumbnail`, `normal_thumbnail`, `original`, `description`, `url`, `alt`, `inline`, `guid` ) VALUES ( @news_id, @small_thumbnail, @medium_thumbnail, @large_thumbnail, @normal_thumbnail, @original, @description, @url, @alt, @inline, @guid ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "news_id", Value = _item.news_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "small_thumbnail", Value = _item.small_thumbnail });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "medium_thumbnail", Value = _item.medium_thumbnail });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "large_thumbnail", Value = _item.large_thumbnail });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "normal_thumbnail", Value = _item.normal_thumbnail });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "original", Value = _item.original });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "description", Value = _item.description });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "url", Value = _item.url });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "alt", Value = _item.alt });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "inline", Value = _item.inline });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "guid", Value = _item.guid });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.news_images Update(MySqlConnection _connection, proto.news_images _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE news_images SET `news_id`= @news_id, `small_thumbnail`= @small_thumbnail, `medium_thumbnail`= @medium_thumbnail, `large_thumbnail`= @large_thumbnail, `normal_thumbnail`= @normal_thumbnail, `original`= @original, `description`= @description, `url`= @url, `alt`= @alt, `inline`= @inline, `guid`= @guid WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_news_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "news_id = @news_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "news_id", Value = _item.news_id });
			}
			if(_item.mc_small_thumbnail)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "small_thumbnail = @small_thumbnail";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "small_thumbnail", Value = _item.small_thumbnail != null ? (object)_item.small_thumbnail : DBNull.Value });
			}
			if(_item.mc_medium_thumbnail)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "medium_thumbnail = @medium_thumbnail";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "medium_thumbnail", Value = _item.medium_thumbnail != null ? (object)_item.medium_thumbnail : DBNull.Value });
			}
			if(_item.mc_large_thumbnail)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "large_thumbnail = @large_thumbnail";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "large_thumbnail", Value = _item.large_thumbnail != null ? (object)_item.large_thumbnail : DBNull.Value });
			}
			if(_item.mc_normal_thumbnail)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "normal_thumbnail = @normal_thumbnail";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "normal_thumbnail", Value = _item.normal_thumbnail != null ? (object)_item.normal_thumbnail : DBNull.Value });
			}
			if(_item.mc_original)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "original = @original";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "original", Value = _item.original != null ? (object)_item.original : DBNull.Value });
			}
			if(_item.mc_description)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "description = @description";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "description", Value = _item.description != null ? (object)_item.description : DBNull.Value });
			}
			if(_item.mc_url)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "url = @url";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "url", Value = _item.url != null ? (object)_item.url : DBNull.Value });
			}
			if(_item.mc_alt)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "alt = @alt";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "alt", Value = _item.alt != null ? (object)_item.alt : DBNull.Value });
			}
			if(_item.mc_inline)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "inline = @inline";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "inline", Value = _item.inline });
			}
			if(_item.mc_guid)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "guid = @guid";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "guid", Value = _item.guid });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE news_images SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.news_images Delete(MySqlConnection _connection, proto.news_images _item)
		{
			var cmd = new MySqlCommand("DELETE FROM news_images WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.news_images Insert(proto.news_images _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.news_images Persist(proto.news_images _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.news_images Delete(proto.news_images _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.news_images Update(proto.news_images _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.news_images> All()
		{
			return m_Items.Values;
		}
		public proto.news_images Get(long _id)
		{
			return m_Items[_id];
		}
		public bool Exists(long _id)
		{
			return m_Items.ContainsKey(_id);
		}
		public void UpdateSync(MySqlConnection _connection, long _id, Meridian _meridian)
		{
			if (!Exists(_id))
			{
			return;
			}
			var item = Get(_id);
			var cmd = new MySqlCommand("SELECT `id`, `news_id`, `small_thumbnail`, `medium_thumbnail`, `large_thumbnail`, `normal_thumbnail`, `original`, `description`, `url`, `alt`, `inline`, `guid` FROM news_images WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					item.DeleteCompositions(Meridian.Default);
					item.DeleteAggregations();
					item.LoadFromReader(reader);
					item.LoadAggregations(_meridian);
					item.LoadCompositions(_meridian);
				}
			}
		}
		public void InsertSync(MySqlConnection _connection, long _id, Meridian _meridian)
		{
			if(Exists(_id)) return;;
			var cmd = new MySqlCommand("SELECT `id`, `news_id`, `small_thumbnail`, `medium_thumbnail`, `large_thumbnail`, `normal_thumbnail`, `original`, `description`, `url`, `alt`, `inline`, `guid` FROM news_images WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.news_images();
					item.LoadFromReader(reader);
					item.LoadAggregations(_meridian);
					item.LoadCompositions(_meridian);
					m_Items.Add(item.id, item);
				}
			}
		}
		public void DeleteSync(MySqlConnection _connection, long _id, Meridian _meridian)
		{
			if (!Exists(_id))
			{
			return;
			}
			var item = Get(_id);
			item.DeleteCompositions(Meridian.Default);
			item.DeleteAggregations();
			m_Items.Remove(item.id);
		}
	}
}
