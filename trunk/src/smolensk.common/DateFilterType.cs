using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace smolensk.common
{
    public enum DateFilterType
    {
        [Description("Сегодня")]
        Now,
        [Description("Завтра")]
        Tomorrow,
        [Description("Выходные")]
        Weekend
    }

    public enum ScheduleFilterType
    {
        /// <summary>
        /// Сегодня
        /// </summary>
        [Description("Сегодня")]
        Today,
        /// <summary>
        /// На три дня
        /// </summary>
        [Description("На три дня")]
        In3Days,
        /// <summary>
        /// На 7 дней
        /// </summary>
        [Description("На 7 дней")]
        InWeek,
        /// <summary>
        /// На 14 дней
        /// </summary>
        [Description("На 14 дней")]
        In2Weeks
    }
}
