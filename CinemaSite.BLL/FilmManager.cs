using CinemaSite.DAL.EntityFramework;
using CinemaSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.BLL
{
    public class FilmManager
    {
        Repository<Film> repo = new Repository<Film>();
        public bool Insert(Film film)
        {
            var isInsert = repo.Insert(film);

            if (isInsert > 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public IEnumerable<Film> List()
        {
            return repo.List(x=>x.State == true);
        }

        public Film Find(Guid Id)
        {
            return repo.Find(x => x.Id == Id && x.State == true);
        }

        public List<Film> GetFilmsWithCategoryId(Guid Id)
        {
            return repo.List(x => x.CategoryId == Id && x.State == true);
        }
    }
}
