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
        Task<LoginView> LoginUser(string username,string password);
    }
}
