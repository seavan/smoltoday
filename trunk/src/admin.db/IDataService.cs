using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;

namespace admin.db
{
    public interface IDataService<T>
        where T : class, IDatabaseEntity, new()
    {
        /// <summary>
        /// Записать изменения в базу
        /// </summary>
        void Commit();

        /// <summary>
        /// Получить все объекты (интерфейс к запросам)
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Получить элемент по первичному ключу
        /// </summary>
        /// <param name="id">ключ</param>
        /// <returns></returns>
        T GetById(long id);

        /// <summary>
        /// Вставить объект и закоммитить изменения
        /// </summary>
        /// <param name="item"></param>
        void Insert(T item);

        /// <summary>
        /// Удалить элемент
        /// </summary>
        /// <param name="item">Удаляемый элемент (объект). Должен присутствовать в БД</param>
        void Delete(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T CreateItem();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void AbortItem(T item);

        /// <summary>
        /// Отменить все изменения (добавления, изменения, удаления)
        /// </summary>
        void Discard();

        void Update(T item);


    }
}