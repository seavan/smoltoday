using System;
using System.Threading;
using MySql.Data.MySqlClient;

namespace meridian.smolensk.system
{
    public class ReceiverThreadWorker : ThreadWorker
    {
        public ReceiverThreadWorker(string _connection, Action<MySqlConnection> _action)
        {
            m_Action = _action;
            m_Connection = _connection;
            IsBackground = true;
        }

        private Action<MySqlConnection> m_Action;
        private string m_Connection;

        public override void DoJob()
        {
            base.DoJob();
            using (var conn = new MySqlConnection(m_Connection))
            {
                conn.Open();
                m_Action(conn);
                conn.Close();
            }
            Thread.Sleep(100);
        }
    }
}