using CinemaSite.DAL.EntityFramework;
using CinemaSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.BLL
{
    public class CategoryManager
    {
        Repository<Category> categoryRepository = new Repository<Category>();

        public List<Category> GetCategories()
        {
            var categories = categoryRepository.List(x => x.State == true);

            return categories;
        }
    }
}
