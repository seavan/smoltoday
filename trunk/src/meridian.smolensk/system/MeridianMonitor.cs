using System;
using System.Text.RegularExpressions;
using System.Threading;
using MySql.Data.MySqlClient;
using meridian.core;
using System.Collections.Generic;

namespace meridian.smolensk.system
{
    public partial class MeridianMonitor : IMeridianMonitorSender
    {
        public void Init(string _connection, string _sphinxHost, int _sphinxPort, string _cachePath, string _logPath)
        {
            m_Connection = _connection;
            SphinxHost = _sphinxHost;
            SphinxPort = _sphinxPort;
        }

        private string m_Connection;

        public string SphinxHost
        {
            get;
            set;
        }

        public int SphinxPort
        {
            get;
            set;
        }

        public void KeepAlive()
        {
            if (!IsSenderThreadRunning())
            {
                //StartSenderThread();
            }

            if (!IsReceiverThreadRunning())
            {
                //StartReceiverThread();
            }
        }

        public class meridian_update
        {
            public long id { get; set; }
            public long proto_id { get; set; }
            public string instance { get; set; }
            public int action { get; set; }
            public string proto { get; set; }
        }

        public void Receive(MySqlConnection _conn)
        {
            var cmd = new MySqlCommand("SELECT * FROM meridian_updates");
            cmd.Connection = _conn;

            var toDel = new List<long>();
            var toUpd = new List<meridian_update>();

            long lastProtoId = -1;
            var lastAction = -1;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        var protoid = (long) reader["id"];
                        var action = (int) reader["action"];

                        if(protoid == lastProtoId && lastAction == action)
                        {
                            continue;
                        }

                        lastProtoId = protoid;
                        lastAction = action;

                        toUpd.Add( new meridian_update() {
                        id = protoid,
                        proto = reader["proto"].ToString(),
                        proto_id = (long)reader["proto_id"],
                        action = action,
                        instance = reader["instance"] != null ? reader["instance"].ToString() : "" });

                    }
                    catch (Exception _e)
                    {
                        Tracer.I.Error("#update gather exception \r\n!!!!!!\r\n{0}\r\n{1}", _e.Message, _e.StackTrace);
                    }
                }
            }
            
            foreach (var i in toUpd)
            {
                if (i.instance.Contains("meridian"))
                {
                    toDel.Add(i.id);
                    continue;
                }
                try
                {
                    Meridian.Default.PassUpdate(_conn, i.proto, i.action, i.proto_id);
                }
                catch (Exception _e)
                {
                    Tracer.I.Error("#update execute exception \r\n!!!!!!\r\n{0}\r\n{1}", _e.Message, _e.StackTrace);
                }
                toDel.Add(i.id);
            }

            foreach (var id in toDel)
            {
                try
                {
                    var cmdDel = new MySqlCommand("DELETE FROM meridian_updates WHERE id = " + id.ToString());
                    cmdDel.Connection = _conn;
                    cmdDel.ExecuteNonQuery();
                }
                catch (Exception _e)
                {
                    Tracer.I.Error("#update gather delete exception \r\n!!!!!!\r\n{0}\r\n{1}", _e.Message, _e.StackTrace);
                }
            }
            
            Thread.Sleep(4000);

        }

        // todo: batching
        public void MySqlActionBackground(Action<MySqlConnection> _action)
        {
            if (m_SenderThreadWorker == null)
            {
                Tracer.I.Error("No thread sender is running");
                StartSenderThread();
            }
            m_SenderThreadWorker.AddAction(_action);
        }

        // todo: batching
        public void MySqlActionForeground(Action<MySqlConnection> _action)
        {
            using (var conn = new MySqlConnection(m_Connection))
            {
                conn.Open();
                _action(conn);
            }
        }

        public bool IsSenderThreadRunning()
        {
            return (m_SenderThreadWorker != null) && (m_SenderThreadWorker.IsAlive);
        }

        public void StartSenderThread()
        {
            if (IsSenderThreadRunning())
            {
                return;
            }

            if (m_SenderThreadWorker == null)
            {
                m_SenderThreadWorker = new SenderThreadWorker(m_Connection);
            }
         
            m_SenderThreadWorker.Start();
        }

        public bool IsReceiverThreadRunning()
        {
            return (m_ReceiverThreadWorker != null) && (m_ReceiverThreadWorker.IsAlive);
        }

        public void StartReceiverThread()
        {
            if (IsReceiverThreadRunning())
            {
                return;
            }

            if (m_ReceiverThreadWorker == null)
            {
                m_ReceiverThreadWorker = new ReceiverThreadWorker(m_Connection, Receive);
            }

            m_ReceiverThreadWorker.Start();
        }

        public static MeridianMonitor Default
        {
            get
            {
                return m_MeridianMonitor;
            }
        }

        public string EscapeForSphinx(string _s)
        {
            _s = Regex.Replace(_s, @"\W+", " ");
            //_s = HttpUtility.HtmlEncode(_s);
            return _s;
        }

      

        private static MeridianMonitor m_MeridianMonitor = new MeridianMonitor();

        private SenderThreadWorker m_SenderThreadWorker;
        private ReceiverThreadWorker m_ReceiverThreadWorker;
    }
}