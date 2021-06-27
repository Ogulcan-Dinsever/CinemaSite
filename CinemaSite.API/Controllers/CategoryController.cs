using CinemaSite.BLL;
using CinemaSite.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CinemaSite.API.Controllers
{
    public class CategoryController : ApiController
    {
        CategoryManager categoryManager = new CategoryManager();
        FilmManager filmManager = new FilmManager();
        public List<Category> GetCategories()
        {
            var categories = categoryManager.GetCategories();

            return categories;
        }

        public List<Film> GetFilmsWithCategoryId(Guid Id)
        {
            var categories = filmManager.GetFilmsWithCategoryId(Id);

            return categories;
        }
    }
}
