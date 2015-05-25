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
	public partial class main_page_widgetsStore : Meridian.IEntityStore, admin.db.IDataService<proto.main_page_widgets>
	{
		public main_page_widgetsStore()
		{
			m_Items = new SortedList<long, proto.main_page_widgets>();
		}
		private SortedList<long, proto.main_page_widgets> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.main_page_widgets> GetAll()
		{
			return Queryable.AsQueryable<proto.main_page_widgets>(All());
		}
		public proto.main_page_widgets GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.main_page_widgets>.Insert(proto.main_page_widgets item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.main_page_widgets>.Delete(proto.main_page_widgets item)
		{
			Delete(item);
		}
		public proto.main_page_widgets CreateItem()
		{
			return new proto.main_page_widgets() {   };
		}
		public void AbortItem(proto.main_page_widgets item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.main_page_widgets>.Update(proto.main_page_widgets item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.main_page_widgets);
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
			var cmd = new MySqlCommand("SELECT `id`, `temperature`, `sky`, `sky_icon`, `eur_price`, `eur_change`, `usd_price`, `usd_change`, `jams_degree`, `jams_description`, `sky_icon_morning`, `sky_icon_afternoon`, `sky_icon_evening`, `sky_morning`, `sky_afternoon`, `sky_evening`, `temperature_morning`, `temperature_afternoon`, `temperature_evening` FROM main_page_widgets");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.main_page_widgets();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.main_page_widgets Insert(MySqlConnection _connection, proto.main_page_widgets _item)
		{
			var cmd = new MySqlCommand("INSERT INTO main_page_widgets ( `temperature`, `sky`, `sky_icon`, `eur_price`, `eur_change`, `usd_price`, `usd_change`, `jams_degree`, `jams_description`, `sky_icon_morning`, `sky_icon_afternoon`, `sky_icon_evening`, `sky_morning`, `sky_afternoon`, `sky_evening`, `temperature_morning`, `temperature_afternoon`, `temperature_evening` ) VALUES ( @temperature, @sky, @sky_icon, @eur_price, @eur_change, @usd_price, @usd_change, @jams_degree, @jams_description, @sky_icon_morning, @sky_icon_afternoon, @sky_icon_evening, @sky_morning, @sky_afternoon, @sky_evening, @temperature_morning, @temperature_afternoon, @temperature_evening ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "temperature", Value = _item.temperature });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky", Value = _item.sky });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_icon", Value = _item.sky_icon });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "eur_price", Value = _item.eur_price });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "eur_change", Value = _item.eur_change });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "usd_price", Value = _item.usd_price });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "usd_change", Value = _item.usd_change });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "jams_degree", Value = _item.jams_degree });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "jams_description", Value = _item.jams_description });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_icon_morning", Value = _item.sky_icon_morning });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_icon_afternoon", Value = _item.sky_icon_afternoon });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_icon_evening", Value = _item.sky_icon_evening });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_morning", Value = _item.sky_morning });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_afternoon", Value = _item.sky_afternoon });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_evening", Value = _item.sky_evening });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "temperature_morning", Value = _item.temperature_morning });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "temperature_afternoon", Value = _item.temperature_afternoon });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "temperature_evening", Value = _item.temperature_evening });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.main_page_widgets Update(MySqlConnection _connection, proto.main_page_widgets _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE main_page_widgets SET `temperature`= @temperature, `sky`= @sky, `sky_icon`= @sky_icon, `eur_price`= @eur_price, `eur_change`= @eur_change, `usd_price`= @usd_price, `usd_change`= @usd_change, `jams_degree`= @jams_degree, `jams_description`= @jams_description, `sky_icon_morning`= @sky_icon_morning, `sky_icon_afternoon`= @sky_icon_afternoon, `sky_icon_evening`= @sky_icon_evening, `sky_morning`= @sky_morning, `sky_afternoon`= @sky_afternoon, `sky_evening`= @sky_evening, `temperature_morning`= @temperature_morning, `temperature_afternoon`= @temperature_afternoon, `temperature_evening`= @temperature_evening WHERE id=@id"); ;
			if(_item.mc_id)
			{
			}
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			if(_item.mc_temperature)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "temperature = @temperature";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "temperature", Value = _item.temperature != null ? (object)_item.temperature : DBNull.Value });
			}
			if(_item.mc_sky)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "sky = @sky";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky", Value = _item.sky != null ? (object)_item.sky : DBNull.Value });
			}
			if(_item.mc_sky_icon)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "sky_icon = @sky_icon";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_icon", Value = _item.sky_icon != null ? (object)_item.sky_icon : DBNull.Value });
			}
			if(_item.mc_eur_price)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "eur_price = @eur_price";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "eur_price", Value = _item.eur_price });
			}
			if(_item.mc_eur_change)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "eur_change = @eur_change";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "eur_change", Value = _item.eur_change });
			}
			if(_item.mc_usd_price)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "usd_price = @usd_price";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "usd_price", Value = _item.usd_price });
			}
			if(_item.mc_usd_change)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "usd_change = @usd_change";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "usd_change", Value = _item.usd_change });
			}
			if(_item.mc_jams_degree)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "jams_degree = @jams_degree";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "jams_degree", Value = _item.jams_degree });
			}
			if(_item.mc_jams_description)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "jams_description = @jams_description";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "jams_description", Value = _item.jams_description != null ? (object)_item.jams_description : DBNull.Value });
			}
			if(_item.mc_sky_icon_morning)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "sky_icon_morning = @sky_icon_morning";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_icon_morning", Value = _item.sky_icon_morning != null ? (object)_item.sky_icon_morning : DBNull.Value });
			}
			if(_item.mc_sky_icon_afternoon)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "sky_icon_afternoon = @sky_icon_afternoon";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_icon_afternoon", Value = _item.sky_icon_afternoon != null ? (object)_item.sky_icon_afternoon : DBNull.Value });
			}
			if(_item.mc_sky_icon_evening)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "sky_icon_evening = @sky_icon_evening";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_icon_evening", Value = _item.sky_icon_evening != null ? (object)_item.sky_icon_evening : DBNull.Value });
			}
			if(_item.mc_sky_morning)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "sky_morning = @sky_morning";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_morning", Value = _item.sky_morning != null ? (object)_item.sky_morning : DBNull.Value });
			}
			if(_item.mc_sky_afternoon)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "sky_afternoon = @sky_afternoon";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_afternoon", Value = _item.sky_afternoon != null ? (object)_item.sky_afternoon : DBNull.Value });
			}
			if(_item.mc_sky_evening)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "sky_evening = @sky_evening";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sky_evening", Value = _item.sky_evening != null ? (object)_item.sky_evening : DBNull.Value });
			}
			if(_item.mc_temperature_morning)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "temperature_morning = @temperature_morning";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "temperature_morning", Value = _item.temperature_morning != null ? (object)_item.temperature_morning : DBNull.Value });
			}
			if(_item.mc_temperature_afternoon)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "temperature_afternoon = @temperature_afternoon";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "temperature_afternoon", Value = _item.temperature_afternoon != null ? (object)_item.temperature_afternoon : DBNull.Value });
			}
			if(_item.mc_temperature_evening)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "temperature_evening = @temperature_evening";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "temperature_evening", Value = _item.temperature_evening != null ? (object)_item.temperature_evening : DBNull.Value });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE main_page_widgets SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.main_page_widgets Delete(MySqlConnection _connection, proto.main_page_widgets _item)
		{
			var cmd = new MySqlCommand("DELETE FROM main_page_widgets WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.main_page_widgets Insert(proto.main_page_widgets _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.main_page_widgets Persist(proto.main_page_widgets _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.main_page_widgets Delete(proto.main_page_widgets _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.main_page_widgets Update(proto.main_page_widgets _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.main_page_widgets> All()
		{
			return m_Items.Values;
		}
		public proto.main_page_widgets Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `temperature`, `sky`, `sky_icon`, `eur_price`, `eur_change`, `usd_price`, `usd_change`, `jams_degree`, `jams_description`, `sky_icon_morning`, `sky_icon_afternoon`, `sky_icon_evening`, `sky_morning`, `sky_afternoon`, `sky_evening`, `temperature_morning`, `temperature_afternoon`, `temperature_evening` FROM main_page_widgets WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `temperature`, `sky`, `sky_icon`, `eur_price`, `eur_change`, `usd_price`, `usd_change`, `jams_degree`, `jams_description`, `sky_icon_morning`, `sky_icon_afternoon`, `sky_icon_evening`, `sky_morning`, `sky_afternoon`, `sky_evening`, `temperature_morning`, `temperature_afternoon`, `temperature_evening` FROM main_page_widgets WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.main_page_widgets();
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
