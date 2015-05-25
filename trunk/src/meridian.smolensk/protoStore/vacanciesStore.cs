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
	public partial class vacanciesStore : Meridian.IEntityStore, admin.db.IDataService<proto.vacancies>
	{
		public vacanciesStore()
		{
			m_Items = new SortedList<long, proto.vacancies>();
		}
		private SortedList<long, proto.vacancies> m_Items;
		public void Commit()
		{
			//throw new NotImplementedException();
		}
		public IQueryable<proto.vacancies> GetAll()
		{
			return Queryable.AsQueryable<proto.vacancies>(All());
		}
		public proto.vacancies GetById(long id)
		{
			return Get(id);
		}
		void admin.db.IDataService<proto.vacancies>.Insert(proto.vacancies item)
		{
			Insert(item);
		}
		void admin.db.IDataService<proto.vacancies>.Delete(proto.vacancies item)
		{
			Delete(item);
		}
		public proto.vacancies CreateItem()
		{
			return new proto.vacancies() {   };
		}
		public void AbortItem(proto.vacancies item)
		{
			Delete(item);
		}
		public void Discard()
		{
			;
		}
		void admin.db.IDataService<proto.vacancies>.Update(proto.vacancies item)
		{
			Persist(item);
		}
		public object GetObject(long _id)
		{
			return Get(_id);
		}
		public System.Type GetObjectType()
		{
			return typeof(proto.vacancies);
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `company_id`, `city_id`, `contact_person`, `contact_phone`, `contact_phone2`, `compensation1`, `compensation2`, `age1`, `age2`, `sex`, `description`, `responsibility`, `requirements`, `terms`, `work_region_id`, `work_city_id`, `work_phone`, `work_phone2`, `work_address`, `created`, `edited`, `views_count`, `closed`, `show_in_banner`, `account_id`, `is_publish`, `url` FROM vacancies");
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.vacancies();
					item.LoadFromReader(reader);
					m_Items[item.id] = item;
				}
			}
		}
		public proto.vacancies Insert(MySqlConnection _connection, proto.vacancies _item)
		{
			var cmd = new MySqlCommand("INSERT INTO vacancies ( `title`, `company_id`, `city_id`, `contact_person`, `contact_phone`, `contact_phone2`, `compensation1`, `compensation2`, `age1`, `age2`, `sex`, `description`, `responsibility`, `requirements`, `terms`, `work_region_id`, `work_city_id`, `work_phone`, `work_phone2`, `work_address`, `created`, `edited`, `views_count`, `closed`, `show_in_banner`, `account_id`, `is_publish`, `url` ) VALUES ( @title, @company_id, @city_id, @contact_person, @contact_phone, @contact_phone2, @compensation1, @compensation2, @age1, @age2, @sex, @description, @responsibility, @requirements, @terms, @work_region_id, @work_city_id, @work_phone, @work_phone2, @work_address, @created, @edited, @views_count, @closed, @show_in_banner, @account_id, @is_publish, @url ); SELECT LAST_INSERT_ID();"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "title", Value = _item.title });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "company_id", Value = _item.company_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "city_id", Value = _item.city_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "contact_person", Value = _item.contact_person });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "contact_phone", Value = _item.contact_phone });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "contact_phone2", Value = _item.contact_phone2 });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "compensation1", Value = _item.compensation1 });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "compensation2", Value = _item.compensation2 });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "age1", Value = _item.age1 });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "age2", Value = _item.age2 });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sex", Value = _item.sex });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "description", Value = _item.description });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "responsibility", Value = _item.responsibility });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "requirements", Value = _item.requirements });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "terms", Value = _item.terms });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_region_id", Value = _item.work_region_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_city_id", Value = _item.work_city_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_phone", Value = _item.work_phone });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_phone2", Value = _item.work_phone2 });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_address", Value = _item.work_address });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "created", Value = (_item.created != null && _item.created.Year > 1800) ? _item.created : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "edited", Value = (_item.edited != null && _item.edited.Year > 1800) ? _item.edited : new DateTime(1800, 1, 1) });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "views_count", Value = _item.views_count });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "closed", Value = _item.closed });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "show_in_banner", Value = _item.show_in_banner });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "account_id", Value = _item.account_id });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_publish", Value = _item.is_publish });
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "url", Value = _item.url });
			cmd.Connection = _connection;
			_item.id = Convert.ToInt64(cmd.ExecuteScalar());
			m_Items.Add(_item.id, _item);
			_item.LoadAggregations(Meridian.Default);
			return _item;
		}
		public proto.vacancies Update(MySqlConnection _connection, proto.vacancies _item)
		{
			bool changed =  false;
			var cmdText =  "";
			var cmd = new MySqlCommand("UPDATE vacancies SET `title`= @title, `company_id`= @company_id, `city_id`= @city_id, `contact_person`= @contact_person, `contact_phone`= @contact_phone, `contact_phone2`= @contact_phone2, `compensation1`= @compensation1, `compensation2`= @compensation2, `age1`= @age1, `age2`= @age2, `sex`= @sex, `description`= @description, `responsibility`= @responsibility, `requirements`= @requirements, `terms`= @terms, `work_region_id`= @work_region_id, `work_city_id`= @work_city_id, `work_phone`= @work_phone, `work_phone2`= @work_phone2, `work_address`= @work_address, `created`= @created, `edited`= @edited, `views_count`= @views_count, `closed`= @closed, `show_in_banner`= @show_in_banner, `account_id`= @account_id, `is_publish`= @is_publish, `url`= @url WHERE id=@id"); ;
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
			if(_item.mc_company_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "company_id = @company_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "company_id", Value = _item.company_id });
			}
			if(_item.mc_city_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "city_id = @city_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "city_id", Value = _item.city_id });
			}
			if(_item.mc_contact_person)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "contact_person = @contact_person";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "contact_person", Value = _item.contact_person != null ? (object)_item.contact_person : DBNull.Value });
			}
			if(_item.mc_contact_phone)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "contact_phone = @contact_phone";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "contact_phone", Value = _item.contact_phone != null ? (object)_item.contact_phone : DBNull.Value });
			}
			if(_item.mc_contact_phone2)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "contact_phone2 = @contact_phone2";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "contact_phone2", Value = _item.contact_phone2 != null ? (object)_item.contact_phone2 : DBNull.Value });
			}
			if(_item.mc_compensation1)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "compensation1 = @compensation1";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "compensation1", Value = _item.compensation1 });
			}
			if(_item.mc_compensation2)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "compensation2 = @compensation2";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "compensation2", Value = _item.compensation2 });
			}
			if(_item.mc_age1)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "age1 = @age1";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "age1", Value = _item.age1 });
			}
			if(_item.mc_age2)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "age2 = @age2";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "age2", Value = _item.age2 });
			}
			if(_item.mc_sex)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "sex = @sex";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "sex", Value = _item.sex });
			}
			if(_item.mc_description)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "description = @description";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "description", Value = _item.description != null ? (object)_item.description : DBNull.Value });
			}
			if(_item.mc_responsibility)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "responsibility = @responsibility";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "responsibility", Value = _item.responsibility != null ? (object)_item.responsibility : DBNull.Value });
			}
			if(_item.mc_requirements)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "requirements = @requirements";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "requirements", Value = _item.requirements != null ? (object)_item.requirements : DBNull.Value });
			}
			if(_item.mc_terms)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "terms = @terms";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "terms", Value = _item.terms != null ? (object)_item.terms : DBNull.Value });
			}
			if(_item.mc_work_region_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "work_region_id = @work_region_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_region_id", Value = _item.work_region_id });
			}
			if(_item.mc_work_city_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "work_city_id = @work_city_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_city_id", Value = _item.work_city_id });
			}
			if(_item.mc_work_phone)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "work_phone = @work_phone";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_phone", Value = _item.work_phone != null ? (object)_item.work_phone : DBNull.Value });
			}
			if(_item.mc_work_phone2)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "work_phone2 = @work_phone2";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_phone2", Value = _item.work_phone2 != null ? (object)_item.work_phone2 : DBNull.Value });
			}
			if(_item.mc_work_address)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "work_address = @work_address";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "work_address", Value = _item.work_address != null ? (object)_item.work_address : DBNull.Value });
			}
			if(_item.mc_created)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "created = @created";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "created", Value = _item.created });
			}
			if(_item.mc_edited)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "edited = @edited";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "edited", Value = _item.edited });
			}
			if(_item.mc_views_count)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "views_count = @views_count";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "views_count", Value = _item.views_count });
			}
			if(_item.mc_closed)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "closed = @closed";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "closed", Value = _item.closed });
			}
			if(_item.mc_show_in_banner)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "show_in_banner = @show_in_banner";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "show_in_banner", Value = _item.show_in_banner });
			}
			if(_item.mc_account_id)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "account_id = @account_id";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "account_id", Value = _item.account_id });
			}
			if(_item.mc_is_publish)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "is_publish = @is_publish";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "is_publish", Value = _item.is_publish });
			}
			if(_item.mc_url)
			{
				changed =  true;
				cmdText += (cmdText.Length > 0 ? ", " : "") + "url = @url";
				cmd.Parameters.Add( new MySqlParameter() { ParameterName = "url", Value = _item.url != null ? (object)_item.url : DBNull.Value });
			}
			if(changed)
			{
				cmd.CommandText =  "UPDATE vacancies SET " + cmdText + " WHERE id=@id";
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				_item.LoadAggregations(Meridian.Default);
			}
			return _item;
		}
		public proto.vacancies Delete(MySqlConnection _connection, proto.vacancies _item)
		{
			var cmd = new MySqlCommand("DELETE FROM vacancies WHERE id=@id"); ;
			cmd.Parameters.Add( new MySqlParameter() { ParameterName = "id", Value = _item.id });
			cmd.Connection = _connection;
			cmd.ExecuteScalar();
			return _item;
		}
		public proto.vacancies Insert(proto.vacancies _item)
		{
			MeridianMonitor.Default.MySqlActionForeground((conn) => Insert(conn, _item));;
			return _item;
		}
		public proto.vacancies Persist(proto.vacancies _item)
		{
			if(_item.id <= 0)
			{
				_item = Insert(_item);
			}
			_item = Update(_item);
			return _item;
		}
		public proto.vacancies Delete(proto.vacancies _item)
		{
			_item.DeleteCompositions(Meridian.Default);
			_item.DeleteAggregations();
			m_Items.Remove(_item.id);
			MeridianMonitor.Default.MySqlActionBackground((conn) => Delete(conn, _item));;
			return _item;
		}
		public proto.vacancies Update(proto.vacancies _item)
		{
			MeridianMonitor.Default.MySqlActionBackground((conn) => Update(conn, _item));;
			return _item;
		}
		public IList<proto.vacancies> All()
		{
			return m_Items.Values;
		}
		public proto.vacancies Get(long _id)
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `company_id`, `city_id`, `contact_person`, `contact_phone`, `contact_phone2`, `compensation1`, `compensation2`, `age1`, `age2`, `sex`, `description`, `responsibility`, `requirements`, `terms`, `work_region_id`, `work_city_id`, `work_phone`, `work_phone2`, `work_address`, `created`, `edited`, `views_count`, `closed`, `show_in_banner`, `account_id`, `is_publish`, `url` FROM vacancies WHERE id = " + _id.ToString());
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
			var cmd = new MySqlCommand("SELECT `id`, `title`, `company_id`, `city_id`, `contact_person`, `contact_phone`, `contact_phone2`, `compensation1`, `compensation2`, `age1`, `age2`, `sex`, `description`, `responsibility`, `requirements`, `terms`, `work_region_id`, `work_city_id`, `work_phone`, `work_phone2`, `work_address`, `created`, `edited`, `views_count`, `closed`, `show_in_banner`, `account_id`, `is_publish`, `url` FROM vacancies WHERE id = " + _id.ToString());
			cmd.Connection = _connection;
			using(var reader = cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					var item = new proto.vacancies();
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