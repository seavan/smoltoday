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
	public partial class newsStore : Meridian.IEntityStore, admin.db.IDataService<proto.news>
	{
		public newsStore()
		{
			m_Items = new SortedList<long, proto.news>();
		}
		private SortedList<long, proto.news> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.news> GetAll()
		{
			return Queryable.AsQueryable<proto.news>(All());
		}
		public proto.news GetById(long id)
		{
			return Get(id);
		}
		public proto.news CreateItem()
		{
			return new proto.news() {   };
		}
		public void AbortItem(proto.news item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.news);
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `lead_title`, `announce`, `text`, `processed_text`, `create_date`, `publish_date`, `is_main`, `is_smolensk_news`, `rating`, `views`, `comment_count`, `category_id`, `author_as_text`, `tags` FROM news");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.news();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.news Insert(MySqlConnection _connection, proto.news _item)
		{
			var cmd = new MySqlCommand("INSERT INTO news ( `title`, `lead_title`, `announce`, `text`, `processed_text`, `create_date`, `publish_date`, `is_main`, `is_smolensk_news`, `rating`, `views`, `comment_count`, `category_id`, `author_as_text`, `tags` ) VALUES ( @title, @lead_title, @announce, @text, @processed_text, @create_date, @publish_date, @is_main, @is_smolensk_news, @rating, @views, @comment_count, @category_id, @author_as_text, @tags ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "title", Value = _item.title });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "lead_title", Value = _item.lead_title });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "announce", Value = _item.announce });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "text", Value = _item.text });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "processed_text", Value = _item.processed_text });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "create_date", Value = (_item.create_date != null && _item.create_date.Year > 1800) ? _item.create_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "publish_date", Value = (_item.publish_date != null && _item.publish_date.Year > 1800) ? _item.publish_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_main", Value = _item.is_main });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_smolensk_news", Value = _item.is_smolensk_news });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "rating", Value = _item.rating });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "views", Value = _item.views });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "comment_count", Value = _item.comment_count });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "category_id", Value = _item.category_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "author_as_text", Value = _item.author_as_text });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "tags", Value = _item.tags });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.news Update(MySqlConnection _connection, proto.news _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE news SET `title`= @title, `lead_title`= @lead_title, `announce`= @announce, `text`= @text, `processed_text`= @processed_text, `create_date`= @create_date, `publish_date`= @publish_date, `is_main`= @is_main, `is_smolensk_news`= @is_smolensk_news, `rating`= @rating, `views`= @views, `comment_count`= @comment_count, `category_id`= @category_id, `author_as_text`= @author_as_text, `tags`= @tags WHERE id=@id"); ;
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
			if(_item.mc_lead_title)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "lead_title = @lead_title";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "lead_title", Value = _item.lead_title != null ? (object)_item.lead_title : DBNull.Value });
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
			if(_item.mc_processed_text)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "processed_text = @processed_text";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "processed_text", Value = _item.processed_text != null ? (object)_item.processed_text : DBNull.Value });
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
			if(_item.mc_is_smolensk_news)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_smolensk_news = @is_smolensk_news";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_smolensk_news", Value = _item.is_smolensk_news });
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
			if(_item.mc_author_as_text)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "author_as_text = @author_as_text";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "author_as_text", Value = _item.author_as_text != null ? (object)_item.author_as_text : DBNull.Value });
			}
			if(_item.mc_tags)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "tags = @tags";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "tags", Value = _item.tags != null ? (object)_item.tags : DBNull.Value });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE news SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.news Delete(MySqlConnection _connection, proto.news _item)
		{
			var cmd = new MySqlCommand("DELETE FROM news WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.news Insert(proto.news _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.news Persist(proto.news _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.news Delete(proto.news _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.news Update(proto.news _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.news> All()
		{
			return m_Items.Values;
		}
		public proto.news Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `lead_title`, `announce`, `text`, `processed_text`, `create_date`, `publish_date`, `is_main`, `is_smolensk_news`, `rating`, `views`, `comment_count`, `category_id`, `author_as_text`, `tags` FROM news WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `lead_title`, `announce`, `text`, `processed_text`, `create_date`, `publish_date`, `is_main`, `is_smolensk_news`, `rating`, `views`, `comment_count`, `category_id`, `author_as_text`, `tags` FROM news WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.news();
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