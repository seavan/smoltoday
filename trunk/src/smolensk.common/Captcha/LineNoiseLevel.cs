using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smolensk.common.Captcha
{
    /// <summary>
    /// Степень кривизны шумовых линий в изображении
    /// </summary>
    public enum LineNoiseLevel
    {
        /// <summary>
        /// Нет
        /// </summary>
        None,
        /// <summary>
        /// Малое
        /// </summary>
        Low,
        /// <summary>
        /// Среднее
        /// </summary>
        Medium,
        /// <summary>
        /// Высокое
        /// </summary>
        High,
        /// <summary>
        /// Экстримальное
        /// </summary>
        Extreme
    }
}
