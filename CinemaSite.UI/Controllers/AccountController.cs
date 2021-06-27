using CinemaSite.Entities;
using CinemaSite.Entities.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CinemaSite.UI.Controllers
{
    public class AccountController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            Client();

            var response = client.PostAsJsonAsync("login", model).Result;

            if (response.IsSuccessStatusCode)
            {
               Session["User"] = response.Content.ReadAsAsync<User>().Result;
            }
            else
            {
                ViewBag.Message = "Başarısız.";
            }

            return Redirect("/Main/Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<ActionResult> Register (RegisterViewModel model)
        {
            Client();

            var response = await client.PostAsJsonAsync("register", model);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Başarıyla Eklendi.";
            }
            else
            {
                ViewBag.Message = "Başarısız.";
            }

            return RedirectToAction("Login");
        }

        public void Client()
        {
            client.BaseAddress = new Uri("http://localhost:44387/api/account/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add
            (new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}