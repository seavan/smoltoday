using System;
using System.Collections.Generic;
using System.Threading;
using MySql.Data.MySqlClient;
using meridian.core;

namespace meridian.smolensk.system
{
    public class SenderThreadWorker : ThreadWorker
    {
        public SenderThreadWorker(string _connection)
        {
            m_Connection = _connection;
            IsBackground = true;
        }

        private string m_Connection;

        public override void DoJob()
        {
            base.DoJob();
            var cnt = m_Queue.Count;
            for(int i = 0; i < cnt; ++i)
            {
                using (var conn = new MySqlConnection(m_Connection))
                {
                    conn.Open();
                    var action = m_Queue.Peek();
                    
                    try
                    {
                        action.Invoke(conn);
                    }
                    catch (Exception _e)
                    {
                        Tracer.I.Error(_e.Message);
                    }

                    m_Queue.Dequeue();
                }
            }
            Thread.Sleep(100);
        }

        public void AddAction(Action<MySqlConnection> _action)
        {
            m_Queue.Enqueue(_action);
        }

        private Queue<Action<MySqlConnection>> m_Queue = new Queue<Action<MySqlConnection>>();
    }
}