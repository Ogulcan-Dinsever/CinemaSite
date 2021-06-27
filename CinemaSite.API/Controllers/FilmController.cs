using CinemaSite.BLL;
using CinemaSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaSite.API.Controllers
{
    public class FilmController : ApiController
    {
        FilmManager filmManager = new FilmManager();
        public IHttpActionResult AddFilm(Film film)
        {
            film.Id = Guid.NewGuid();
            film.CreatedDate = DateTime.Now;
            film.State = true;
            var isInsert = filmManager.Insert(film);

            if (!isInsert)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        public IEnumerable<Film> GetFilms()
        {
            return filmManager.List();
        }

        public Film GetFilm(Guid Id)
        {
            return filmManager.Find(Id);
        }
    }
}
