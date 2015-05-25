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
	public partial class photobank_photo_tagsStore : Meridian.IEntityStore, admin.db.IDataService<proto.photobank_photo_tags>
	{
		public photobank_photo_tagsStore()
		{
			m_Items = new SortedList<long, proto.photobank_photo_tags>();
		}
		private SortedList<long, proto.photobank_photo_tags> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.photobank_photo_tags> GetAll()
		{
			return Queryable.AsQueryable<proto.photobank_photo_tags>(All());
		}
		public proto.photobank_photo_tags GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.photobank_photo_tags>.Insert(proto.photobank_photo_tags item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.photobank_photo_tags>.Delete(proto.photobank_photo_tags item)
		{
			Delete(item);
		}
		public proto.photobank_photo_tags CreateItem()
		{
			return new proto.photobank_photo_tags() {   };
		}
		public void AbortItem(proto.photobank_photo_tags item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.photobank_photo_tags>.Update(proto.photobank_photo_tags item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.photobank_photo_tags);
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
			var cmd = new MySqlCommand("SELECT `id`, `tag_id`, `photo_id` FROM photobank_photo_tags");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.photobank_photo_tags();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.photobank_photo_tags Insert(MySqlConnection _connection, proto.photobank_photo_tags _item)
		{
			var cmd = new MySqlCommand("INSERT INTO photobank_photo_tags ( `tag_id`, `photo_id` ) VALUES ( @tag_id, @photo_id ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "tag_id", Value = _item.tag_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "photo_id", Value = _item.photo_id });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.photobank_photo_tags Update(MySqlConnection _connection, proto.photobank_photo_tags _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE photobank_photo_tags SET `tag_id`= @tag_id, `photo_id`= @photo_id WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_tag_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "tag_id = @tag_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "tag_id", Value = _item.tag_id });
			}
			if(_item.mc_photo_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "photo_id = @photo_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "photo_id", Value = _item.photo_id });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE photobank_photo_tags SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.photobank_photo_tags Delete(MySqlConnection _connection, proto.photobank_photo_tags _item)
		{
			var cmd = new MySqlCommand("DELETE FROM photobank_photo_tags WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.photobank_photo_tags Insert(proto.photobank_photo_tags _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.photobank_photo_tags Persist(proto.photobank_photo_tags _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.photobank_photo_tags Delete(proto.photobank_photo_tags _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.photobank_photo_tags Update(proto.photobank_photo_tags _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.photobank_photo_tags> All()
		{
			return m_Items.Values;
		}
		public proto.photobank_photo_tags Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `tag_id`, `photo_id` FROM photobank_photo_tags WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `tag_id`, `photo_id` FROM photobank_photo_tags WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.photobank_photo_tags();
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
