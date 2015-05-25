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
	public partial class blog_categoriesStore : Meridian.IEntityStore, admin.db.IDataService<proto.blog_categories>
	{
		public blog_categoriesStore()
		{
			m_Items = new SortedList<long, proto.blog_categories>();
		}
		private SortedList<long, proto.blog_categories> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.blog_categories> GetAll()
		{
			return Queryable.AsQueryable<proto.blog_categories>(All());
		}
		public proto.blog_categories GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.blog_categories>.Insert(proto.blog_categories item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.blog_categories>.Delete(proto.blog_categories item)
		{
			Delete(item);
		}
		public proto.blog_categories CreateItem()
		{
			return new proto.blog_categories() {   };
		}
		public void AbortItem(proto.blog_categories item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.blog_categories>.Update(proto.blog_categories item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.blog_categories);
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
			var cmd = new MySqlCommand("SELECT `id`, `key`, `title`, `order_id`, `is_sub` FROM blog_categories");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.blog_categories();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.blog_categories Insert(MySqlConnection _connection, proto.blog_categories _item)
		{
			var cmd = new MySqlCommand("INSERT INTO blog_categories ( `key`, `title`, `order_id`, `is_sub` ) VALUES ( @key, @title, @order_id, @is_sub ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "key", Value = _item.key });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "title", Value = _item.title });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "order_id", Value = _item.order_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_sub", Value = _item.is_sub });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.blog_categories Update(MySqlConnection _connection, proto.blog_categories _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE blog_categories SET `key`= @key, `title`= @title, `order_id`= @order_id, `is_sub`= @is_sub WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_key)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "key = @key";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "key", Value = _item.key != null ? (object)_item.key : DBNull.Value });
			}
			if(_item.mc_title)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "title = @title";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "title", Value = _item.title != null ? (object)_item.title : DBNull.Value });
			}
			if(_item.mc_order_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "order_id = @order_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "order_id", Value = _item.order_id });
			}
			if(_item.mc_is_sub)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_sub = @is_sub";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_sub", Value = _item.is_sub });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE blog_categories SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.blog_categories Delete(MySqlConnection _connection, proto.blog_categories _item)
		{
			var cmd = new MySqlCommand("DELETE FROM blog_categories WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.blog_categories Insert(proto.blog_categories _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.blog_categories Persist(proto.blog_categories _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.blog_categories Delete(proto.blog_categories _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.blog_categories Update(proto.blog_categories _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.blog_categories> All()
		{
			return m_Items.Values;
		}
		public proto.blog_categories Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `key`, `title`, `order_id`, `is_sub` FROM blog_categories WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `key`, `title`, `order_id`, `is_sub` FROM blog_categories WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.blog_categories();
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
