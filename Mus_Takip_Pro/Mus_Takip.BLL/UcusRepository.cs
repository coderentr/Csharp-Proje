using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mus_Takip.DAL;

namespace Mus_Takip.BLL
{
    public class UcusRepository : IRepository<Ucuslar>
    {
        MusDBEntities ent =new MusDBEntities();
        Ucuslar guncellenecek;
        public void delete(int itemID)
        {
            ent.Ucuslar.Remove(ent.Ucuslar.Find(itemID));
        }

        public void insert(Ucuslar item)
        {
            ent.Ucuslar.Add(item);
            ent.SaveChanges();
        }

        public List<Ucuslar> SelectAll()
        {
            return ent.Ucuslar.ToList();
        }

        public Ucuslar SelectByID(int item)
        {
            return ent.Ucuslar.Find(item);
        }

        public void Update(Ucuslar item)
        {
            guncellenecek = ent.Ucuslar.Find(item.Ucus_No);
            ent.Entry(guncellenecek).CurrentValues.SetValues(item);
            ent.SaveChanges();
        }
    }
}
