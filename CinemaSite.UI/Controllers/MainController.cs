using CinemaSite.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CinemaSite.UI.Controllers
{
    public class MainController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            Client();
            ViewBag.Films = GetFilms();
            ViewBag.Categories = GetCategories();

            return View();
        }

        public ActionResult Films(Guid Id)
        {
            Client();
            ViewBag.Films = GetFilmsWithCategoryId(Id);
            ViewBag.Categories = GetCategories();

            return View();
        }

        public ActionResult Film(Guid Id)
        {
            Client();
            ViewBag.Film = GetFilm(Id);

            return View();
        }

        public ActionResult AddFilm()
        {
            ViewBag.Categories = GetCategories();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddFilm(Film film, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images"), pic);
                file.SaveAs(path);

                film.ImageUrl = file.FileName;
            }

            Client();

            var response = await client.PostAsJsonAsync("film/addfilm", film);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Başarıyla Eklendi.";
            }
            else
            {
                ViewBag.Message = "Başarısız.";
            }

            return RedirectToAction("Index");
        }

        public void Client()
        {
            client.BaseAddress = new Uri("http://localhost:44387/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add
            (new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<Category> GetCategories()
        {
            var response = client.GetAsync("category/getcategories").Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Film> GetFilmsWithCategoryId(Guid Id)
        {
            var response = client.GetAsync($"category/getfilmswithcategoryid/{Id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<Film>>().Result;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Film> GetFilms()
        {
            var response = client.GetAsync("film/getfilms").Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<Film>>().Result;
            }
            else
            {
                return null;
            }
        }

        public Film GetFilm(Guid Id)
        {
            var response = client.GetAsync($"film/getfilm/{Id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Film>().Result;
            }
            else
            {
                return null;
            }
        }
    }
}