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
	public partial class actionsStore : Meridian.IEntityStore, admin.db.IDataService<proto.actions>
	{
		public actionsStore()
		{
			m_Items = new SortedList<long, proto.actions>();
		}
		private SortedList<long, proto.actions> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.actions> GetAll()
		{
			return Queryable.AsQueryable<proto.actions>(All());
		}
		public proto.actions GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.actions>.Insert(proto.actions item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.actions>.Delete(proto.actions item)
		{
			Delete(item);
		}
		public proto.actions CreateItem()
		{
			return new proto.actions() {   };
		}
		public void AbortItem(proto.actions item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.actions>.Update(proto.actions item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.actions);
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `text`, `publish_date`, `is_main`, `is_main_category`, `is_top`, `rating`, `age_limit`, `comment_count`, `participiants_count`, `category_id`, `account_id`, `approve`, `published`, `delete`, `author`, `producer`, `statement`, `lecturer`, `performers`, `country`, `duration`, `start_date`, `price_min`, `price_max`, `site`, `google_link`, `facebook_link`, `twitter_link`, `vk_link`, `mail_link`, `odnoklassniki_link`, `coordinates`, `map_title`, `map_description`, `image_for_main` FROM actions");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.actions();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.actions Insert(MySqlConnection _connection, proto.actions _item)
		{
			var cmd = new MySqlCommand("INSERT INTO actions ( `title`, `text`, `publish_date`, `is_main`, `is_main_category`, `is_top`, `rating`, `age_limit`, `comment_count`, `participiants_count`, `category_id`, `account_id`, `approve`, `published`, `delete`, `author`, `producer`, `statement`, `lecturer`, `performers`, `country`, `duration`, `start_date`, `price_min`, `price_max`, `site`, `google_link`, `facebook_link`, `twitter_link`, `vk_link`, `mail_link`, `odnoklassniki_link`, `coordinates`, `map_title`, `map_description`, `image_for_main` ) VALUES ( @title, @text, @publish_date, @is_main, @is_main_category, @is_top, @rating, @age_limit, @comment_count, @participiants_count, @category_id, @account_id, @approve, @published, @delete, @author, @producer, @statement, @lecturer, @performers, @country, @duration, @start_date, @price_min, @price_max, @site, @google_link, @facebook_link, @twitter_link, @vk_link, @mail_link, @odnoklassniki_link, @coordinates, @map_title, @map_description, @image_for_main ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "title", Value = _item.title });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "text", Value = _item.text });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "publish_date", Value = (_item.publish_date != null && _item.publish_date.Year > 1800) ? _item.publish_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_main", Value = _item.is_main });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_main_category", Value = _item.is_main_category });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_top", Value = _item.is_top });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "rating", Value = _item.rating });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "age_limit", Value = _item.age_limit });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "comment_count", Value = _item.comment_count });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "participiants_count", Value = _item.participiants_count });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "category_id", Value = _item.category_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "account_id", Value = _item.account_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "approve", Value = _item.approve });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "published", Value = _item.published });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "delete", Value = _item.delete });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "author", Value = _item.author });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "producer", Value = _item.producer });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "statement", Value = _item.statement });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "lecturer", Value = _item.lecturer });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "performers", Value = _item.performers });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "country", Value = _item.country });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "duration", Value = _item.duration });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "start_date", Value = (_item.start_date != null && _item.start_date.Year > 1800) ? _item.start_date : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "price_min", Value = _item.price_min });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "price_max", Value = _item.price_max });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "site", Value = _item.site });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "google_link", Value = _item.google_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "facebook_link", Value = _item.facebook_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "twitter_link", Value = _item.twitter_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "vk_link", Value = _item.vk_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "mail_link", Value = _item.mail_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "odnoklassniki_link", Value = _item.odnoklassniki_link });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "coordinates", Value = _item.coordinates });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "map_title", Value = _item.map_title });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "map_description", Value = _item.map_description });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "image_for_main", Value = _item.image_for_main });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.actions Update(MySqlConnection _connection, proto.actions _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE actions SET `title`= @title, `text`= @text, `publish_date`= @publish_date, `is_main`= @is_main, `is_main_category`= @is_main_category, `is_top`= @is_top, `rating`= @rating, `age_limit`= @age_limit, `comment_count`= @comment_count, `participiants_count`= @participiants_count, `category_id`= @category_id, `account_id`= @account_id, `approve`= @approve, `published`= @published, `delete`= @delete, `author`= @author, `producer`= @producer, `statement`= @statement, `lecturer`= @lecturer, `performers`= @performers, `country`= @country, `duration`= @duration, `start_date`= @start_date, `price_min`= @price_min, `price_max`= @price_max, `site`= @site, `google_link`= @google_link, `facebook_link`= @facebook_link, `twitter_link`= @twitter_link, `vk_link`= @vk_link, `mail_link`= @mail_link, `odnoklassniki_link`= @odnoklassniki_link, `coordinates`= @coordinates, `map_title`= @map_title, `map_description`= @map_description, `image_for_main`= @image_for_main WHERE id=@id"); ;
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
			if(_item.mc_publish_date)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "publish_date = @publish_date";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "publish_date", Value = _item.publish_date });
			}
			if(_item.mc_is_main)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_main = @is_main";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_main", Value = _item.is_main });
			}
			if(_item.mc_is_main_category)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_main_category = @is_main_category";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_main_category", Value = _item.is_main_category });
			}
			if(_item.mc_is_top)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_top = @is_top";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_top", Value = _item.is_top });
			}
			if(_item.mc_rating)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "rating = @rating";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "rating", Value = _item.rating });
			}
			if(_item.mc_age_limit)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "age_limit = @age_limit";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "age_limit", Value = _item.age_limit });
			}
			if(_item.mc_comment_count)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "comment_count = @comment_count";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "comment_count", Value = _item.comment_count });
			}
			if(_item.mc_participiants_count)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "participiants_count = @participiants_count";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "participiants_count", Value = _item.participiants_count });
			}
			if(_item.mc_category_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "category_id = @category_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "category_id", Value = _item.category_id });
			}
			if(_item.mc_account_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "account_id = @account_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "account_id", Value = _item.account_id });
			}
			if(_item.mc_approve)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "approve = @approve";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "approve", Value = _item.approve });
			}
			if(_item.mc_published)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "published = @published";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "published", Value = _item.published });
			}
			if(_item.mc_delete)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "delete = @delete";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "delete", Value = _item.delete });
			}
			if(_item.mc_author)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "author = @author";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "author", Value = _item.author != null ? (object)_item.author : DBNull.Value });
			}
			if(_item.mc_producer)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "producer = @producer";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "producer", Value = _item.producer != null ? (object)_item.producer : DBNull.Value });
			}
			if(_item.mc_statement)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "statement = @statement";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "statement", Value = _item.statement != null ? (object)_item.statement : DBNull.Value });
			}
			if(_item.mc_lecturer)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "lecturer = @lecturer";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "lecturer", Value = _item.lecturer != null ? (object)_item.lecturer : DBNull.Value });
			}
			if(_item.mc_performers)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "performers = @performers";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "performers", Value = _item.performers != null ? (object)_item.performers : DBNull.Value });
			}
			if(_item.mc_country)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "country = @country";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "country", Value = _item.country != null ? (object)_item.country : DBNull.Value });
			}
			if(_item.mc_duration)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "duration = @duration";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "duration", Value = _item.duration });
			}
			if(_item.mc_start_date)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "start_date = @start_date";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "start_date", Value = _item.start_date });
			}
			if(_item.mc_price_min)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "price_min = @price_min";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "price_min", Value = _item.price_min });
			}
			if(_item.mc_price_max)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "price_max = @price_max";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "price_max", Value = _item.price_max });
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
			if(_item.mc_map_title)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "map_title = @map_title";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "map_title", Value = _item.map_title != null ? (object)_item.map_title : DBNull.Value });
			}
			if(_item.mc_map_description)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "map_description = @map_description";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "map_description", Value = _item.map_description != null ? (object)_item.map_description : DBNull.Value });
			}
			if(_item.mc_image_for_main)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "image_for_main = @image_for_main";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "image_for_main", Value = _item.image_for_main != null ? (object)_item.image_for_main : DBNull.Value });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE actions SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.actions Delete(MySqlConnection _connection, proto.actions _item)
		{
			var cmd = new MySqlCommand("DELETE FROM actions WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.actions Insert(proto.actions _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.actions Persist(proto.actions _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.actions Delete(proto.actions _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.actions Update(proto.actions _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.actions> All()
		{
			return m_Items.Values;
		}
		public proto.actions Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `text`, `publish_date`, `is_main`, `is_main_category`, `is_top`, `rating`, `age_limit`, `comment_count`, `participiants_count`, `category_id`, `account_id`, `approve`, `published`, `delete`, `author`, `producer`, `statement`, `lecturer`, `performers`, `country`, `duration`, `start_date`, `price_min`, `price_max`, `site`, `google_link`, `facebook_link`, `twitter_link`, `vk_link`, `mail_link`, `odnoklassniki_link`, `coordinates`, `map_title`, `map_description`, `image_for_main` FROM actions WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `text`, `publish_date`, `is_main`, `is_main_category`, `is_top`, `rating`, `age_limit`, `comment_count`, `participiants_count`, `category_id`, `account_id`, `approve`, `published`, `delete`, `author`, `producer`, `statement`, `lecturer`, `performers`, `country`, `duration`, `start_date`, `price_min`, `price_max`, `site`, `google_link`, `facebook_link`, `twitter_link`, `vk_link`, `mail_link`, `odnoklassniki_link`, `coordinates`, `map_title`, `map_description`, `image_for_main` FROM actions WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.actions();
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
