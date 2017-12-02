using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mus_Takip.DAL;

namespace Mus_Takip.BLL
{
   
    public class MusRepository : IRepository<Musteriler>
    {
        MusDBEntities ent = new MusDBEntities();
        public void delete(int itemID)
        {
            ent.Musteriler.Remove(ent.Musteriler.Find(itemID));
            ent.SaveChanges();
        }

        public void insert(Musteriler item)
        {
            ent.Musteriler.Add(item);
            ent.SaveChanges();
        }

        public List<Musteriler> SelectAll()
        {
            return ent.Musteriler.ToList();
        }

        public Musteriler SelectByID(int item)
        {
            return ent.Musteriler.Find(item);
        }

        public void Update(Musteriler item)
        {
            Musteriler guncellenecek = ent.Musteriler.Find(item.Musteri_No);
            ent.Entry(guncellenecek).CurrentValues.SetValues(item);
            ent.SaveChanges();
        }
        public List<Musteriler> arama(string item)
        {
            return ent.Musteriler.Where(g => g.Tel_No.Contains(item)).ToList();
        }
    }
}
