using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smolensk.common
{
    public enum SmolenskRoles
    {
        /// <summary>
        /// Зарегистрированный пользователь
        /// </summary>
        User = 1,

        /// <summary>
        /// Корректор
        /// </summary>
        Corrector = 2,

        /// <summary>
        /// Редактор
        /// </summary>
        Editor = 3,

        /// <summary>
        /// Модератор
        /// </summary>
        Moderator = 4,

        /// <summary>
        /// Администратор
        /// </summary>
        Admin = 5,
    }
}
