using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_Takip.BLL
{
    public interface  IRepository<T>
    {
        void insert(T item);
        void Update(T item);
        void delete(int itemID);
        List<T> SelectAll();
        T SelectByID(int item);
    }
}
