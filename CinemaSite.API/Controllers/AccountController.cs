using CinemaSite.BLL;
using CinemaSite.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CinemaSite.API.Controllers
{
    public class AccountController : ApiController
    {
        UserManager userManager = new UserManager();
        public IHttpActionResult Register(RegisterViewModel viewModel)
        {
            bool isInsert = userManager.Insert(viewModel);

            if (!isInsert)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        public IHttpActionResult Login(LoginViewModel viewModel)
        {
            var isLogin = userManager.Find(viewModel);

            if (isLogin)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
