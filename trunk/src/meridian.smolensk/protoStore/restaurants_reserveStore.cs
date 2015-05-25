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
	public partial class restaurants_reserveStore : Meridian.IEntityStore, admin.db.IDataService<proto.restaurants_reserve>
	{
		public restaurants_reserveStore()
		{
			m_Items = new SortedList<long, proto.restaurants_reserve>();
		}
		private SortedList<long, proto.restaurants_reserve> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.restaurants_reserve> GetAll()
		{
			return Queryable.AsQueryable<proto.restaurants_reserve>(All());
		}
		public proto.restaurants_reserve GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.restaurants_reserve>.Insert(proto.restaurants_reserve item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.restaurants_reserve>.Delete(proto.restaurants_reserve item)
		{
			Delete(item);
		}
		public proto.restaurants_reserve CreateItem()
		{
			return new proto.restaurants_reserve() {   };
		}
		public void AbortItem(proto.restaurants_reserve item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.restaurants_reserve>.Update(proto.restaurants_reserve item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.restaurants_reserve);
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
			var cmd = new MySqlCommand("SELECT `id`, `create_date`, `contact`, `phone`, `visit_date`, `persons_count`, `account_id`, `restaraunt_id` FROM restaurants_reserve");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.restaurants_reserve();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.restaurants_reserve Insert(MySqlConnection _connection, proto.restaurants_reserve _item)
		{
			var cmd = new MySqlCommand("INSERT INTO restaurants_reserve ( `create_date`, `contact`, `phone`, `visit_date`, `persons_count`, `account_id`, `restaraunt_id` ) VALUES ( @create_date, @contact, @phone, @visit_date, @persons_count, @account_id, @restaraunt_id ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "create_date", Value = (_item.create_date != null && _item.create_date.Year > 1800) ? _item.create_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "contact", Value = _item.contact });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "phone", Value = _item.phone });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "visit_date", Value = (_item.visit_date != null && _item.visit_date.Year > 1800) ? _item.visit_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "persons_count", Value = _item.persons_count });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "account_id", Value = _item.account_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "restaraunt_id", Value = _item.restaraunt_id });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.restaurants_reserve Update(MySqlConnection _connection, proto.restaurants_reserve _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE restaurants_reserve SET `create_date`= @create_date, `contact`= @contact, `phone`= @phone, `visit_date`= @visit_date, `persons_count`= @persons_count, `account_id`= @account_id, `restaraunt_id`= @restaraunt_id WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_create_date)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "create_date = @create_date";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "create_date", Value = _item.create_date });
			}
			if(_item.mc_contact)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "contact = @contact";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "contact", Value = _item.contact != null ? (object)_item.contact : DBNull.Value });
			}
			if(_item.mc_phone)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "phone = @phone";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "phone", Value = _item.phone != null ? (object)_item.phone : DBNull.Value });
			}
			if(_item.mc_visit_date)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "visit_date = @visit_date";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "visit_date", Value = _item.visit_date });
			}
			if(_item.mc_persons_count)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "persons_count = @persons_count";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "persons_count", Value = _item.persons_count });
			}
			if(_item.mc_account_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "account_id = @account_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "account_id", Value = _item.account_id });
			}
			if(_item.mc_restaraunt_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "restaraunt_id = @restaraunt_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "restaraunt_id", Value = _item.restaraunt_id });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE restaurants_reserve SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.restaurants_reserve Delete(MySqlConnection _connection, proto.restaurants_reserve _item)
		{
			var cmd = new MySqlCommand("DELETE FROM restaurants_reserve WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.restaurants_reserve Insert(proto.restaurants_reserve _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.restaurants_reserve Persist(proto.restaurants_reserve _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.restaurants_reserve Delete(proto.restaurants_reserve _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.restaurants_reserve Update(proto.restaurants_reserve _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.restaurants_reserve> All()
		{
			return m_Items.Values;
		}
		public proto.restaurants_reserve Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `create_date`, `contact`, `phone`, `visit_date`, `persons_count`, `account_id`, `restaraunt_id` FROM restaurants_reserve WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `create_date`, `contact`, `phone`, `visit_date`, `persons_count`, `account_id`, `restaraunt_id` FROM restaurants_reserve WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.restaurants_reserve();
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