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
	public partial class resume_trainingsStore : Meridian.IEntityStore, admin.db.IDataService<proto.resume_trainings>
	{
		public resume_trainingsStore()
		{
			m_Items = new SortedList<long, proto.resume_trainings>();
		}
		private SortedList<long, proto.resume_trainings> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.resume_trainings> GetAll()
		{
			return Queryable.AsQueryable<proto.resume_trainings>(All());
		}
		public proto.resume_trainings GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.resume_trainings>.Insert(proto.resume_trainings item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.resume_trainings>.Delete(proto.resume_trainings item)
		{
			Delete(item);
		}
		public proto.resume_trainings CreateItem()
		{
			return new proto.resume_trainings() {   };
		}
		public void AbortItem(proto.resume_trainings item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.resume_trainings>.Update(proto.resume_trainings item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.resume_trainings);
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
			var cmd = new MySqlCommand("SELECT `id`, `begin_date`, `end_date`, `description`, `resume_id` FROM resume_trainings");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.resume_trainings();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.resume_trainings Insert(MySqlConnection _connection, proto.resume_trainings _item)
		{
			var cmd = new MySqlCommand("INSERT INTO resume_trainings ( `begin_date`, `end_date`, `description`, `resume_id` ) VALUES ( @begin_date, @end_date, @description, @resume_id ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "begin_date", Value = (_item.begin_date != null && _item.begin_date.Year > 1800) ? _item.begin_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "end_date", Value = (_item.end_date != null && _item.end_date.Year > 1800) ? _item.end_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "description", Value = _item.description });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "resume_id", Value = _item.resume_id });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.resume_trainings Update(MySqlConnection _connection, proto.resume_trainings _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE resume_trainings SET `begin_date`= @begin_date, `end_date`= @end_date, `description`= @description, `resume_id`= @resume_id WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_begin_date)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "begin_date = @begin_date";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "begin_date", Value = _item.begin_date });
			}
			if(_item.mc_end_date)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "end_date = @end_date";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "end_date", Value = _item.end_date });
			}
			if(_item.mc_description)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "description = @description";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "description", Value = _item.description != null ? (object)_item.description : DBNull.Value });
			}
			if(_item.mc_resume_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "resume_id = @resume_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "resume_id", Value = _item.resume_id });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE resume_trainings SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.resume_trainings Delete(MySqlConnection _connection, proto.resume_trainings _item)
		{
			var cmd = new MySqlCommand("DELETE FROM resume_trainings WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.resume_trainings Insert(proto.resume_trainings _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.resume_trainings Persist(proto.resume_trainings _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.resume_trainings Delete(proto.resume_trainings _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.resume_trainings Update(proto.resume_trainings _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.resume_trainings> All()
		{
			return m_Items.Values;
		}
		public proto.resume_trainings Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `begin_date`, `end_date`, `description`, `resume_id` FROM resume_trainings WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `begin_date`, `end_date`, `description`, `resume_id` FROM resume_trainings WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.resume_trainings();
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
