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
	public partial class actions_placesStore : Meridian.IEntityStore, admin.db.IDataService<proto.actions_places>
	{
		public actions_placesStore()
		{
			m_Items = new SortedList<long, proto.actions_places>();
		}
		private SortedList<long, proto.actions_places> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.actions_places> GetAll()
		{
			return Queryable.AsQueryable<proto.actions_places>(All());
		}
		public proto.actions_places GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.actions_places>.Insert(proto.actions_places item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.actions_places>.Delete(proto.actions_places item)
		{
			Delete(item);
		}
		public proto.actions_places CreateItem()
		{
			return new proto.actions_places() {   };
		}
		public void AbortItem(proto.actions_places item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.actions_places>.Update(proto.actions_places item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.actions_places);
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
			var cmd = new MySqlCommand("SELECT `id`, `action_id`, `place_id` FROM actions_places");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.actions_places();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.actions_places Insert(MySqlConnection _connection, proto.actions_places _item)
		{
			var cmd = new MySqlCommand("INSERT INTO actions_places ( `action_id`, `place_id` ) VALUES ( @action_id, @place_id ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "action_id", Value = _item.action_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "place_id", Value = _item.place_id });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.actions_places Update(MySqlConnection _connection, proto.actions_places _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE actions_places SET `action_id`= @action_id, `place_id`= @place_id WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_action_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "action_id = @action_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "action_id", Value = _item.action_id });
			}
			if(_item.mc_place_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "place_id = @place_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "place_id", Value = _item.place_id });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE actions_places SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.actions_places Delete(MySqlConnection _connection, proto.actions_places _item)
		{
			var cmd = new MySqlCommand("DELETE FROM actions_places WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.actions_places Insert(proto.actions_places _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.actions_places Persist(proto.actions_places _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.actions_places Delete(proto.actions_places _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.actions_places Update(proto.actions_places _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.actions_places> All()
		{
			return m_Items.Values;
		}
		public proto.actions_places Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `action_id`, `place_id` FROM actions_places WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `action_id`, `place_id` FROM actions_places WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.actions_places();
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
