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
	public partial class placesStore : Meridian.IEntityStore, admin.db.IDataService<proto.places>
	{
		public placesStore()
		{
			m_Items = new SortedList<long, proto.places>();
		}
		private SortedList<long, proto.places> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.places> GetAll()
		{
			return Queryable.AsQueryable<proto.places>(All());
		}
		public proto.places GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.places>.Insert(proto.places item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.places>.Delete(proto.places item)
		{
			Delete(item);
		}
		public proto.places CreateItem()
		{
			return new proto.places() {   };
		}
		public void AbortItem(proto.places item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.places>.Update(proto.places item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.places);
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `text`, `adress`, `price`, `work_time`, `location`, `phone`, `site`, `google_link`, `facebook_link`, `twitter_link`, `vk_link`, `mail_link`, `odnoklassniki_link`, `coordinates` FROM places");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.places();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.places Insert(MySqlConnection _connection, proto.places _item)
		{
			var cmd = new MySqlCommand("INSERT INTO places ( `title`, `text`, `adress`, `price`, `work_time`, `location`, `phone`, `site`, `google_link`, `facebook_link`, `twitter_link`, `vk_link`, `mail_link`, `odnoklassniki_link`, `coordinates` ) VALUES ( @title, @text, @adress, @price, @work_time, @location, @phone, @site, @google_link, @facebook_link, @twitter_link, @vk_link, @mail_link, @odnoklassniki_link, @coordinates ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "title", Value = _item.title });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "text", Value = _item.text });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "adress", Value = _item.adress });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "price", Value = _item.price });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_time", Value = _item.work_time });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "location", Value = _item.location });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "phone", Value = _item.phone });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "site", Value = _item.site });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "google_link", Value = _item.google_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "facebook_link", Value = _item.facebook_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "twitter_link", Value = _item.twitter_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "vk_link", Value = _item.vk_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "mail_link", Value = _item.mail_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "odnoklassniki_link", Value = _item.odnoklassniki_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "coordinates", Value = _item.coordinates });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.places Update(MySqlConnection _connection, proto.places _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE places SET `title`= @title, `text`= @text, `adress`= @adress, `price`= @price, `work_time`= @work_time, `location`= @location, `phone`= @phone, `site`= @site, `google_link`= @google_link, `facebook_link`= @facebook_link, `twitter_link`= @twitter_link, `vk_link`= @vk_link, `mail_link`= @mail_link, `odnoklassniki_link`= @odnoklassniki_link, `coordinates`= @coordinates WHERE id=@id"); ;
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
			if(_item.mc_text)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "text = @text";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "text", Value = _item.text != null ? (object)_item.text : DBNull.Value });
			}
			if(_item.mc_adress)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "adress = @adress";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "adress", Value = _item.adress != null ? (object)_item.adress : DBNull.Value });
			}
			if(_item.mc_price)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "price = @price";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "price", Value = _item.price != null ? (object)_item.price : DBNull.Value });
			}
			if(_item.mc_work_time)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "work_time = @work_time";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_time", Value = _item.work_time != null ? (object)_item.work_time : DBNull.Value });
			}
			if(_item.mc_location)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "location = @location";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "location", Value = _item.location != null ? (object)_item.location : DBNull.Value });
			}
			if(_item.mc_phone)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "phone = @phone";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "phone", Value = _item.phone != null ? (object)_item.phone : DBNull.Value });
			}
			if(_item.mc_site)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "site = @site";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "site", Value = _item.site != null ? (object)_item.site : DBNull.Value });
			}
			if(_item.mc_google_link)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "google_link = @google_link";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "google_link", Value = _item.google_link != null ? (object)_item.google_link : DBNull.Value });
			}
			if(_item.mc_facebook_link)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "facebook_link = @facebook_link";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "facebook_link", Value = _item.facebook_link != null ? (object)_item.facebook_link : DBNull.Value });
			}
			if(_item.mc_twitter_link)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "twitter_link = @twitter_link";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "twitter_link", Value = _item.twitter_link != null ? (object)_item.twitter_link : DBNull.Value });
			}
			if(_item.mc_vk_link)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "vk_link = @vk_link";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "vk_link", Value = _item.vk_link != null ? (object)_item.vk_link : DBNull.Value });
			}
			if(_item.mc_mail_link)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "mail_link = @mail_link";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "mail_link", Value = _item.mail_link != null ? (object)_item.mail_link : DBNull.Value });
			}
			if(_item.mc_odnoklassniki_link)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "odnoklassniki_link = @odnoklassniki_link";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "odnoklassniki_link", Value = _item.odnoklassniki_link != null ? (object)_item.odnoklassniki_link : DBNull.Value });
			}
			if(_item.mc_coordinates)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "coordinates = @coordinates";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "coordinates", Value = _item.coordinates != null ? (object)_item.coordinates : DBNull.Value });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE places SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.places Delete(MySqlConnection _connection, proto.places _item)
		{
			var cmd = new MySqlCommand("DELETE FROM places WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.places Insert(proto.places _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.places Persist(proto.places _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.places Delete(proto.places _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.places Update(proto.places _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.places> All()
		{
			return m_Items.Values;
		}
		public proto.places Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `text`, `adress`, `price`, `work_time`, `location`, `phone`, `site`, `google_link`, `facebook_link`, `twitter_link`, `vk_link`, `mail_link`, `odnoklassniki_link`, `coordinates` FROM places WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `text`, `adress`, `price`, `work_time`, `location`, `phone`, `site`, `google_link`, `facebook_link`, `twitter_link`, `vk_link`, `mail_link`, `odnoklassniki_link`, `coordinates` FROM places WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.places();
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
