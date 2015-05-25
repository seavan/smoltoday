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
	public partial class photobank_related_photosStore : Meridian.IEntityStore, admin.db.IDataService<proto.photobank_related_photos>
	{
		public photobank_related_photosStore()
		{
			m_Items = new SortedList<long, proto.photobank_related_photos>();
		}
		private SortedList<long, proto.photobank_related_photos> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.photobank_related_photos> GetAll()
		{
			return Queryable.AsQueryable<proto.photobank_related_photos>(All());
		}
		public proto.photobank_related_photos GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.photobank_related_photos>.Insert(proto.photobank_related_photos item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.photobank_related_photos>.Delete(proto.photobank_related_photos item)
		{
			Delete(item);
		}
		public proto.photobank_related_photos CreateItem()
		{
			return new proto.photobank_related_photos() {   };
		}
		public void AbortItem(proto.photobank_related_photos item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.photobank_related_photos>.Update(proto.photobank_related_photos item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.photobank_related_photos);
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
			var cmd = new MySqlCommand("SELECT `id`, `photo_id`, `original`, `width`, `height`, `photo`, `filename` FROM photobank_related_photos");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.photobank_related_photos();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.photobank_related_photos Insert(MySqlConnection _connection, proto.photobank_related_photos _item)
		{
			var cmd = new MySqlCommand("INSERT INTO photobank_related_photos ( `photo_id`, `original`, `width`, `height`, `photo`, `filename` ) VALUES ( @photo_id, @original, @width, @height, @photo, @filename ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "photo_id", Value = _item.photo_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "original", Value = _item.original });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "width", Value = _item.width });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "height", Value = _item.height });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "photo", Value = _item.photo });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "filename", Value = _item.filename });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.photobank_related_photos Update(MySqlConnection _connection, proto.photobank_related_photos _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE photobank_related_photos SET `photo_id`= @photo_id, `original`= @original, `width`= @width, `height`= @height, `photo`= @photo, `filename`= @filename WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_photo_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "photo_id = @photo_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "photo_id", Value = _item.photo_id });
			}
			if(_item.mc_original)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "original = @original";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "original", Value = _item.original });
			}
			if(_item.mc_width)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "width = @width";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "width", Value = _item.width });
			}
			if(_item.mc_height)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "height = @height";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "height", Value = _item.height });
			}
			if(_item.mc_photo)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "photo = @photo";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "photo", Value = _item.photo != null ? (object)_item.photo : DBNull.Value });
			}
			if(_item.mc_filename)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "filename = @filename";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "filename", Value = _item.filename != null ? (object)_item.filename : DBNull.Value });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE photobank_related_photos SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.photobank_related_photos Delete(MySqlConnection _connection, proto.photobank_related_photos _item)
		{
			var cmd = new MySqlCommand("DELETE FROM photobank_related_photos WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.photobank_related_photos Insert(proto.photobank_related_photos _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.photobank_related_photos Persist(proto.photobank_related_photos _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.photobank_related_photos Delete(proto.photobank_related_photos _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.photobank_related_photos Update(proto.photobank_related_photos _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.photobank_related_photos> All()
		{
			return m_Items.Values;
		}
		public proto.photobank_related_photos Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `photo_id`, `original`, `width`, `height`, `photo`, `filename` FROM photobank_related_photos WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `photo_id`, `original`, `width`, `height`, `photo`, `filename` FROM photobank_related_photos WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.photobank_related_photos();
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
