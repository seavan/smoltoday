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
	public partial class news_videosStore : Meridian.IEntityStore, admin.db.IDataService<proto.news_videos>
	{
		public news_videosStore()
		{
			m_Items = new SortedList<long, proto.news_videos>();
		}
		private SortedList<long, proto.news_videos> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.news_videos> GetAll()
		{
			return Queryable.AsQueryable<proto.news_videos>(All());
		}
		public proto.news_videos GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.news_videos>.Insert(proto.news_videos item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.news_videos>.Delete(proto.news_videos item)
		{
			Delete(item);
		}
		public proto.news_videos CreateItem()
		{
			return new proto.news_videos() {   };
		}
		public void AbortItem(proto.news_videos item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.news_videos>.Update(proto.news_videos item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.news_videos);
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
			var cmd = new MySqlCommand("SELECT `id`, `news_id`, `guid`, `url`, `original`, `small_thumbnail` FROM news_videos");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.news_videos();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.news_videos Insert(MySqlConnection _connection, proto.news_videos _item)
		{
			var cmd = new MySqlCommand("INSERT INTO news_videos ( `news_id`, `guid`, `url`, `original`, `small_thumbnail` ) VALUES ( @news_id, @guid, @url, @original, @small_thumbnail ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "news_id", Value = _item.news_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "guid", Value = _item.guid });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "url", Value = _item.url });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "original", Value = _item.original });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "small_thumbnail", Value = _item.small_thumbnail });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.news_videos Update(MySqlConnection _connection, proto.news_videos _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE news_videos SET `news_id`= @news_id, `guid`= @guid, `url`= @url, `original`= @original, `small_thumbnail`= @small_thumbnail WHERE id=@id"); ;
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
			if(_item.mc_guid)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "guid = @guid";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "guid", Value = _item.guid });
			}
			if(_item.mc_url)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "url = @url";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "url", Value = _item.url != null ? (object)_item.url : DBNull.Value });
			}
			if(_item.mc_original)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "original = @original";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "original", Value = _item.original != null ? (object)_item.original : DBNull.Value });
			}
			if(_item.mc_small_thumbnail)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "small_thumbnail = @small_thumbnail";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "small_thumbnail", Value = _item.small_thumbnail != null ? (object)_item.small_thumbnail : DBNull.Value });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE news_videos SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.news_videos Delete(MySqlConnection _connection, proto.news_videos _item)
		{
			var cmd = new MySqlCommand("DELETE FROM news_videos WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.news_videos Insert(proto.news_videos _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.news_videos Persist(proto.news_videos _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.news_videos Delete(proto.news_videos _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.news_videos Update(proto.news_videos _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.news_videos> All()
		{
			return m_Items.Values;
		}
		public proto.news_videos Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `news_id`, `guid`, `url`, `original`, `small_thumbnail` FROM news_videos WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `news_id`, `guid`, `url`, `original`, `small_thumbnail` FROM news_videos WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.news_videos();
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
