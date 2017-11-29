using Filmler.DAL;
using Filmler.DTO.YonetmenDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmler.BLL.Repository
{
    public class YonetmenRepository
    {
        FilmlerDBEntities db = DBTool.DBInstance;
        public List<YonetmenlerForListDTO> selectAllList()
        {
            return db.Yönetmenler.Select(i => new YonetmenlerForListDTO {YonetmenId=i.YonetmenId, YonetmenAdiSoyadi = i.YonetmenAdi+" "+i.YonetmenSoyadi }).ToList();

        }
    }
}
