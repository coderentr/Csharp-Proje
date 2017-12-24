using Kütüphane.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.BLL
{
   public class dbTools
    {
        public static DbContext _dbInstance;
        public static DbContext DbInstrance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new KutuphaneEntities();
                }
                return _dbInstance;
            }
        }
    }
}
