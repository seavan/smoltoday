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
	public partial class ad_photosStore : Meridian.IEntityStore, admin.db.IDataService<proto.ad_photos>
	{
		public ad_photosStore()
		{
			m_Items = new SortedList<long, proto.ad_photos>();
		}
		private SortedList<long, proto.ad_photos> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.ad_photos> GetAll()
		{
			return Queryable.AsQueryable<proto.ad_photos>(All());
		}
		public proto.ad_photos GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.ad_photos>.Insert(proto.ad_photos item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.ad_photos>.Delete(proto.ad_photos item)
		{
			Delete(item);
		}
		public proto.ad_photos CreateItem()
		{
			return new proto.ad_photos() {   };
		}
		public void AbortItem(proto.ad_photos item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.ad_photos>.Update(proto.ad_photos item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.ad_photos);
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
			var cmd = new MySqlCommand("SELECT `id`, `ad_id`, `preview`, `photo`, `original`, `create_date`, `is_main` FROM ad_photos");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.ad_photos();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.ad_photos Insert(MySqlConnection _connection, proto.ad_photos _item)
		{
			var cmd = new MySqlCommand("INSERT INTO ad_photos ( `ad_id`, `preview`, `photo`, `original`, `create_date`, `is_main` ) VALUES ( @ad_id, @preview, @photo, @original, @create_date, @is_main ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "ad_id", Value = _item.ad_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "preview", Value = _item.preview });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "photo", Value = _item.photo });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "original", Value = _item.original });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "create_date", Value = (_item.create_date != null && _item.create_date.Year > 1800) ? _item.create_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_main", Value = _item.is_main });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.ad_photos Update(MySqlConnection _connection, proto.ad_photos _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE ad_photos SET `ad_id`= @ad_id, `preview`= @preview, `photo`= @photo, `original`= @original, `create_date`= @create_date, `is_main`= @is_main WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_ad_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "ad_id = @ad_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "ad_id", Value = _item.ad_id });
			}
			if(_item.mc_preview)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "preview = @preview";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "preview", Value = _item.preview != null ? (object)_item.preview : DBNull.Value });
			}
			if(_item.mc_photo)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "photo = @photo";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "photo", Value = _item.photo != null ? (object)_item.photo : DBNull.Value });
			}
			if(_item.mc_original)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "original = @original";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "original", Value = _item.original != null ? (object)_item.original : DBNull.Value });
			}
			if(_item.mc_create_date)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "create_date = @create_date";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "create_date", Value = _item.create_date });
			}
			if(_item.mc_is_main)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_main = @is_main";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_main", Value = _item.is_main });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE ad_photos SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.ad_photos Delete(MySqlConnection _connection, proto.ad_photos _item)
		{
			var cmd = new MySqlCommand("DELETE FROM ad_photos WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.ad_photos Insert(proto.ad_photos _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.ad_photos Persist(proto.ad_photos _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.ad_photos Delete(proto.ad_photos _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.ad_photos Update(proto.ad_photos _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.ad_photos> All()
		{
			return m_Items.Values;
		}
		public proto.ad_photos Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `ad_id`, `preview`, `photo`, `original`, `create_date`, `is_main` FROM ad_photos WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `ad_id`, `preview`, `photo`, `original`, `create_date`, `is_main` FROM ad_photos WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.ad_photos();
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