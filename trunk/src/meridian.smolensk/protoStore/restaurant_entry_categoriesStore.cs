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
	public partial class restaurant_entry_categoriesStore : Meridian.IEntityStore, admin.db.IDataService<proto.restaurant_entry_categories>
	{
		public restaurant_entry_categoriesStore()
		{
			m_Items = new SortedList<long, proto.restaurant_entry_categories>();
		}
		private SortedList<long, proto.restaurant_entry_categories> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.restaurant_entry_categories> GetAll()
		{
			return Queryable.AsQueryable<proto.restaurant_entry_categories>(All());
		}
		public proto.restaurant_entry_categories GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.restaurant_entry_categories>.Insert(proto.restaurant_entry_categories item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.restaurant_entry_categories>.Delete(proto.restaurant_entry_categories item)
		{
			Delete(item);
		}
		public proto.restaurant_entry_categories CreateItem()
		{
			return new proto.restaurant_entry_categories() {   };
		}
		public void AbortItem(proto.restaurant_entry_categories item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.restaurant_entry_categories>.Update(proto.restaurant_entry_categories item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.restaurant_entry_categories);
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `is_multiple`, `is_anyvalue`, `is_visible` FROM restaurant_entry_categories");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.restaurant_entry_categories();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.restaurant_entry_categories Insert(MySqlConnection _connection, proto.restaurant_entry_categories _item)
		{
			var cmd = new MySqlCommand("INSERT INTO restaurant_entry_categories ( `title`, `is_multiple`, `is_anyvalue`, `is_visible` ) VALUES ( @title, @is_multiple, @is_anyvalue, @is_visible ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "title", Value = _item.title });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_multiple", Value = _item.is_multiple });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_anyvalue", Value = _item.is_anyvalue });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_visible", Value = _item.is_visible });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.restaurant_entry_categories Update(MySqlConnection _connection, proto.restaurant_entry_categories _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE restaurant_entry_categories SET `title`= @title, `is_multiple`= @is_multiple, `is_anyvalue`= @is_anyvalue, `is_visible`= @is_visible WHERE id=@id"); ;
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
			if(_item.mc_is_multiple)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_multiple = @is_multiple";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_multiple", Value = _item.is_multiple });
			}
			if(_item.mc_is_anyvalue)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_anyvalue = @is_anyvalue";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_anyvalue", Value = _item.is_anyvalue });
			}
			if(_item.mc_is_visible)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_visible = @is_visible";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_visible", Value = _item.is_visible });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE restaurant_entry_categories SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.restaurant_entry_categories Delete(MySqlConnection _connection, proto.restaurant_entry_categories _item)
		{
			var cmd = new MySqlCommand("DELETE FROM restaurant_entry_categories WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.restaurant_entry_categories Insert(proto.restaurant_entry_categories _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.restaurant_entry_categories Persist(proto.restaurant_entry_categories _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.restaurant_entry_categories Delete(proto.restaurant_entry_categories _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.restaurant_entry_categories Update(proto.restaurant_entry_categories _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.restaurant_entry_categories> All()
		{
			return m_Items.Values;
		}
		public proto.restaurant_entry_categories Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `is_multiple`, `is_anyvalue`, `is_visible` FROM restaurant_entry_categories WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `is_multiple`, `is_anyvalue`, `is_visible` FROM restaurant_entry_categories WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.restaurant_entry_categories();
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