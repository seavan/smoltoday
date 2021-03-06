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
	public partial class restaurant_commentsStore : Meridian.IEntityStore, admin.db.IDataService<proto.restaurant_comments>
	{
		public restaurant_commentsStore()
		{
			m_Items = new SortedList<long, proto.restaurant_comments>();
		}
		private SortedList<long, proto.restaurant_comments> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.restaurant_comments> GetAll()
		{
			return Queryable.AsQueryable<proto.restaurant_comments>(All());
		}
		public proto.restaurant_comments GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.restaurant_comments>.Insert(proto.restaurant_comments item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.restaurant_comments>.Delete(proto.restaurant_comments item)
		{
			Delete(item);
		}
		public proto.restaurant_comments CreateItem()
		{
			return new proto.restaurant_comments() {   };
		}
		public void AbortItem(proto.restaurant_comments item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.restaurant_comments>.Update(proto.restaurant_comments item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.restaurant_comments);
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
			var cmd = new MySqlCommand("SELECT `id`, `left_key`, `right_key`, `level`, `delete`, `create_date`, `account_id`, `text`, `parent_id`, `restaurant_id` FROM restaurant_comments");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.restaurant_comments();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.restaurant_comments Insert(MySqlConnection _connection, proto.restaurant_comments _item)
		{
			var cmd = new MySqlCommand("INSERT INTO restaurant_comments ( `left_key`, `right_key`, `level`, `delete`, `create_date`, `account_id`, `text`, `parent_id`, `restaurant_id` ) VALUES ( @left_key, @right_key, @level, @delete, @create_date, @account_id, @text, @parent_id, @restaurant_id ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "left_key", Value = _item.left_key });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "right_key", Value = _item.right_key });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "level", Value = _item.level });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "delete", Value = _item.delete });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "create_date", Value = (_item.create_date != null && _item.create_date.Year > 1800) ? _item.create_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "account_id", Value = _item.account_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "text", Value = _item.text });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "parent_id", Value = _item.parent_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "restaurant_id", Value = _item.restaurant_id });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.restaurant_comments Update(MySqlConnection _connection, proto.restaurant_comments _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE restaurant_comments SET `left_key`= @left_key, `right_key`= @right_key, `level`= @level, `delete`= @delete, `create_date`= @create_date, `account_id`= @account_id, `text`= @text, `parent_id`= @parent_id, `restaurant_id`= @restaurant_id WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_left_key)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "left_key = @left_key";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "left_key", Value = _item.left_key });
			}
			if(_item.mc_right_key)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "right_key = @right_key";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "right_key", Value = _item.right_key });
			}
			if(_item.mc_level)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "level = @level";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "level", Value = _item.level });
			}
			if(_item.mc_delete)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "delete = @delete";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "delete", Value = _item.delete });
			}
			if(_item.mc_create_date)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "create_date = @create_date";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "create_date", Value = _item.create_date });
			}
			if(_item.mc_account_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "account_id = @account_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "account_id", Value = _item.account_id });
			}
			if(_item.mc_text)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "text = @text";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "text", Value = _item.text != null ? (object)_item.text : DBNull.Value });
			}
			if(_item.mc_parent_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "parent_id = @parent_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "parent_id", Value = _item.parent_id });
			}
			if(_item.mc_restaurant_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "restaurant_id = @restaurant_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "restaurant_id", Value = _item.restaurant_id });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE restaurant_comments SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.restaurant_comments Delete(MySqlConnection _connection, proto.restaurant_comments _item)
		{
			var cmd = new MySqlCommand("DELETE FROM restaurant_comments WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.restaurant_comments Insert(proto.restaurant_comments _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.restaurant_comments Persist(proto.restaurant_comments _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.restaurant_comments Delete(proto.restaurant_comments _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.restaurant_comments Update(proto.restaurant_comments _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.restaurant_comments> All()
		{
			return m_Items.Values;
		}
		public proto.restaurant_comments Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `left_key`, `right_key`, `level`, `delete`, `create_date`, `account_id`, `text`, `parent_id`, `restaurant_id` FROM restaurant_comments WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `left_key`, `right_key`, `level`, `delete`, `create_date`, `account_id`, `text`, `parent_id`, `restaurant_id` FROM restaurant_comments WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.restaurant_comments();
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
