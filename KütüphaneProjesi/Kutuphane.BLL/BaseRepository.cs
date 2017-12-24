using Kütüphane.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.BLL
{
   public class BaseRepository<T> where T:class
    {
        DbContext ent = dbTools.DbInstrance;
        public   void Insert(T item)
        {
            ent.Set(typeof(T)).Add(item);
            ent.SaveChanges();
        }
        public void Delete(object itemID)
        {
            ent.Set(typeof(T)).Remove(ent.Set(typeof(T)).Find(itemID));
            ent.SaveChanges();
        }
        public List<T> SelectAll()
        {
            return ent.Set(typeof(T)).Cast<T>().ToList();
        }
        public void Update(T item)
        {
            PropertyInfo pInfo = null;

            foreach (var property in item.GetType().GetProperties())
            {
                if (property.Name.Contains("id"))
                {
                    pInfo = property;
                    break;
                }
            }
            var güncellenecek = ent.Set(typeof(T)).Find(pInfo.GetValue(item));
            ent.Entry(güncellenecek).CurrentValues.SetValues(item);
            ent.SaveChanges();
        }
        public T SelectByID(object itemId)
        {
            return (T)ent.Set(typeof(T)).Find(itemId);
        }
    }
}
