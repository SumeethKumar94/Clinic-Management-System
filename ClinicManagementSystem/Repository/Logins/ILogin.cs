using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.Logins
{
   public interface ILogin
    {
        //login using username and password
        Task<LoginView> LoginUser(string username,string password);

        //add user login
        Task<int> AddLogin(Login logint);

        //update user login
        Task UpdateLogin(Login login);
    }
}
