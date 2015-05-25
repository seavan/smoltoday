﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smolensk.common.Captcha
{
    /// <summary>
    /// Степень искривления шрифта сгенерированного текста
    /// </summary>
    public enum FontWarpFactor
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
