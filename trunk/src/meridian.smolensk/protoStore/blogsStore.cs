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
	public partial class blogsStore : Meridian.IEntityStore, admin.db.IDataService<proto.blogs>
	{
		public blogsStore()
		{
			m_Items = new SortedList<long, proto.blogs>();
		}
		private SortedList<long, proto.blogs> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.blogs> GetAll()
		{
			return Queryable.AsQueryable<proto.blogs>(All());
		}
		public proto.blogs GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.blogs>.Insert(proto.blogs item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.blogs>.Delete(proto.blogs item)
		{
			Delete(item);
		}
		public proto.blogs CreateItem()
		{
			return new proto.blogs() {   };
		}
		public void AbortItem(proto.blogs item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.blogs>.Update(proto.blogs item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.blogs);
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `announce`, `text`, `create_date`, `publish_date`, `is_main`, `rating`, `views`, `comment_count`, `category_id`, `is_interesting`, `is_thebest`, `account_id`, `can_comment`, `is_publish`, `is_delete` FROM blogs");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.blogs();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.blogs Insert(MySqlConnection _connection, proto.blogs _item)
		{
			var cmd = new MySqlCommand("INSERT INTO blogs ( `title`, `announce`, `text`, `create_date`, `publish_date`, `is_main`, `rating`, `views`, `comment_count`, `category_id`, `is_interesting`, `is_thebest`, `account_id`, `can_comment`, `is_publish`, `is_delete` ) VALUES ( @title, @announce, @text, @create_date, @publish_date, @is_main, @rating, @views, @comment_count, @category_id, @is_interesting, @is_thebest, @account_id, @can_comment, @is_publish, @is_delete ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "title", Value = _item.title });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "announce", Value = _item.announce });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "text", Value = _item.text });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "create_date", Value = (_item.create_date != null && _item.create_date.Year > 1800) ? _item.create_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "publish_date", Value = (_item.publish_date != null && _item.publish_date.Year > 1800) ? _item.publish_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_main", Value = _item.is_main });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "rating", Value = _item.rating });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "views", Value = _item.views });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "comment_count", Value = _item.comment_count });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "category_id", Value = _item.category_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_interesting", Value = _item.is_interesting });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_thebest", Value = _item.is_thebest });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "account_id", Value = _item.account_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "can_comment", Value = _item.can_comment });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_publish", Value = _item.is_publish });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_delete", Value = _item.is_delete });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.blogs Update(MySqlConnection _connection, proto.blogs _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE blogs SET `title`= @title, `announce`= @announce, `text`= @text, `create_date`= @create_date, `publish_date`= @publish_date, `is_main`= @is_main, `rating`= @rating, `views`= @views, `comment_count`= @comment_count, `category_id`= @category_id, `is_interesting`= @is_interesting, `is_thebest`= @is_thebest, `account_id`= @account_id, `can_comment`= @can_comment, `is_publish`= @is_publish, `is_delete`= @is_delete WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_title)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "title = @title";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "title", Value = _item.title != null ? (object)_item.title : DBNull.Value });
			}
			if(_item.mc_announce)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "announce = @announce";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "announce", Value = _item.announce != null ? (object)_item.announce : DBNull.Value });
			}
			if(_item.mc_text)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "text = @text";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "text", Value = _item.text != null ? (object)_item.text : DBNull.Value });
			}
			if(_item.mc_create_date)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "create_date = @create_date";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "create_date", Value = _item.create_date });
			}
			if(_item.mc_publish_date)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "publish_date = @publish_date";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "publish_date", Value = _item.publish_date });
			}
			if(_item.mc_is_main)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_main = @is_main";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_main", Value = _item.is_main });
			}
			if(_item.mc_rating)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "rating = @rating";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "rating", Value = _item.rating });
			}
			if(_item.mc_views)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "views = @views";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "views", Value = _item.views });
			}
			if(_item.mc_comment_count)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "comment_count = @comment_count";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "comment_count", Value = _item.comment_count });
			}
			if(_item.mc_category_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "category_id = @category_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "category_id", Value = _item.category_id });
			}
			if(_item.mc_is_interesting)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_interesting = @is_interesting";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_interesting", Value = _item.is_interesting });
			}
			if(_item.mc_is_thebest)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_thebest = @is_thebest";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_thebest", Value = _item.is_thebest });
			}
			if(_item.mc_account_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "account_id = @account_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "account_id", Value = _item.account_id });
			}
			if(_item.mc_can_comment)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "can_comment = @can_comment";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "can_comment", Value = _item.can_comment });
			}
			if(_item.mc_is_publish)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_publish = @is_publish";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_publish", Value = _item.is_publish });
			}
			if(_item.mc_is_delete)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_delete = @is_delete";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_delete", Value = _item.is_delete });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE blogs SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.blogs Delete(MySqlConnection _connection, proto.blogs _item)
		{
			var cmd = new MySqlCommand("DELETE FROM blogs WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.blogs Insert(proto.blogs _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.blogs Persist(proto.blogs _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.blogs Delete(proto.blogs _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.blogs Update(proto.blogs _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.blogs> All()
		{
			return m_Items.Values;
		}
		public proto.blogs Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `announce`, `text`, `create_date`, `publish_date`, `is_main`, `rating`, `views`, `comment_count`, `category_id`, `is_interesting`, `is_thebest`, `account_id`, `can_comment`, `is_publish`, `is_delete` FROM blogs WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `announce`, `text`, `create_date`, `publish_date`, `is_main`, `rating`, `views`, `comment_count`, `category_id`, `is_interesting`, `is_thebest`, `account_id`, `can_comment`, `is_publish`, `is_delete` FROM blogs WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.blogs();
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