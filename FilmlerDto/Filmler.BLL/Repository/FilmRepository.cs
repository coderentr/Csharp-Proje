using Filmler.DAL;
using Filmler.DTO.FilmDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmler.BLL.Repository
{
    public class FilmRepository
    {
        FilmlerDBEntities db = DBTool.DBInstance;
        public List<FilmlerForListDTO> selectByfilmId(int id)
        {
            return db.Filmlers.Where(i => i.FilmId == id).Select(f => new FilmlerForListDTO
            { FilmAdi = f.FilmAdi}).ToList();
        }

    }
}
