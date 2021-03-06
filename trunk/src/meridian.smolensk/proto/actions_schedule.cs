﻿/* Automatically generated codefile, Meridian
 * Generated by magic, please do not interfere
 * Please sleep well and do not smoke. Love, Sam */

using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
	[MetadataType(typeof(actions_schedule_meta))]	public partial class actions_schedule : admin.db.IDatabaseEntity
	{
		public actions_schedule()
		{
		}
		private long m_id = 0;
		internal bool mc_id { get; private set; }
		private long m_action_place_id = 0;
		internal bool mc_action_place_id { get; private set; }
		private DateTime m_datetime = DateTime.MinValue;
		internal bool mc_datetime { get; private set; }
		public void LoadFromReader(MySqlDataReader _reader)
		{
			m_id = _reader["id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("id") : 0;
			mc_id = false;
			m_action_place_id = _reader["action_place_id"].GetType() != typeof(System.DBNull) ? _reader.GetInt64("action_place_id") : 0;
			mc_action_place_id = false;
			m_datetime = _reader["datetime"].GetType() != typeof(System.DBNull) ? _reader.GetDateTime("datetime") : DateTime.MinValue;
			mc_datetime = false;
		}
		public void LoadAggregations(Meridian _meridian)
		{
			if((action_place_id > 0) && (_meridian.actions_placesStore.Exists(action_place_id)))
			{
				this.ap_schedule_actions_places = _meridian.actions_placesStore.Get(action_place_id);;
				this.ap_schedule_actions_places.AddSchedule(this);
			}
		}
		public void DeleteAggregations()
		{
			if(this.ap_schedule_actions_places != null)
			{
				this.ap_schedule_actions_places.RemoveSchedule(this);
			}
		}
		public void LoadCompositions(Meridian _meridian)
		{
			string[] keyIds = null;
		}
		public void SaveCompositions(Meridian _meridian)
		{
		}
		public void DeleteCompositions(Meridian _meridian)
		{
			string[] keyIds = null;
		}
		public string ProtoName
		{
			get { return "actions_schedule"; }
		}
		/* metafile template 
		internal class actions_schedule_meta
		{
			public long id { get; set; }
			public long action_place_id { get; set; }
			public DateTime datetime { get; set; }
		}
		 metafile template */
		public long id
		{
			get
			{
				return m_id;
			}
			set
			{
				if(m_id != value)
				{
					m_id = value != null ? value : 0;
					mc_id = true;
					// call update worker thread;
				}
			}
		}
		public long action_place_id
		{
			get
			{
				return m_action_place_id;
			}
			set
			{
				if(m_action_place_id != value)
				{
					m_action_place_id = value != null ? value : 0;
					mc_action_place_id = true;
					// call update worker thread;
				}
			}
		}
		public DateTime datetime
		{
			get
			{
				return m_datetime;
			}
			set
			{
				if(m_datetime != value)
				{
					m_datetime = value != null ? value : DateTime.MinValue;
					if(m_datetime.Year < 1800) value = DateTime.MinValue;
					mc_datetime = true;
					// call update worker thread;
				}
			}
		}
		private actions_places ap_schedule_actions_places
		{
			get; set; 
		}
		public actions_places GetScheduleActions_place()
		{
			return ap_schedule_actions_places ;
		}
	}
}
