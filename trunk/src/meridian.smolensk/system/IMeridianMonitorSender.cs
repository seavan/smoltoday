using System;
using MySql.Data.MySqlClient;

namespace meridian.smolensk.system
{
    public interface IMeridianMonitorSender
    {
        void MySqlActionBackground(Action<MySqlConnection> _action);
        void MySqlActionForeground(Action<MySqlConnection> _action);
    }
}