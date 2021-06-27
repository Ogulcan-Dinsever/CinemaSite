using CinemaSite.DAL.EntityFramework;
using CinemaSite.Entities;
using CinemaSite.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.BLL
{
    public class UserManager
    {
        Repository<User> repositoryUser = new Repository<User>();

        public bool Insert(RegisterViewModel viewModel)
        {
            if (viewModel.Password != viewModel.PasswordConfirm)
            {
                return false;
            }

            User registerUser = repositoryUser.Find(x => x.Email == viewModel.Email);

            if (registerUser != null)
            {
                return false;
            }


            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Email = viewModel.Email,
                Password = viewModel.Password,
                CreatedDate = DateTime.Now,
                State = true,
                IsAdmin = false
            };

            int isInsert = repositoryUser.Insert(user);

            if (isInsert > 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public User Find(LoginViewModel viewModel)
        {
            User user = repositoryUser.Find(x => x.Email == viewModel.Email && x.State == true);

            if (user == null)
            {
                return null;
            }

            if (user.Password != viewModel.Password)
            {
                return null;
            }

            return user;
        }
    }
}
