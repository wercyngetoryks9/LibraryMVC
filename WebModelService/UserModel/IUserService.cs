using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModelService.UserModel.Contracts.ViewModels;
using WebModelService.UserModel.Contracts.DTOs;
using DataService;

namespace WebModelService.UserModel
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);
        UserViewModelEdit GetUserEdit(int id); 
        IList<UserViewModel> GetUsers();
        IList<UserViewModelBorrowed> GetUserDetailsHistory(int id);
        IList<UserViewModelBorrowed> GetUserDetailsActual(int id);
        void AddUser(UserViewModelCreate user);
        void EditUser(UserViewModelEdit user);
        void DeleteUser(int id);
        bool EmailExist(int userId, string email);
    }
}
