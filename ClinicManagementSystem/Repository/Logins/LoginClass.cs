using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.Logins
{
    public class LoginClass:ILogin
    {
        private readonly ClinicManagementSystemDBContext _context;
        public LoginClass(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }
        
        public async Task<LoginView> LoginUser(string username, string password)
        {
            if (_context != null)
            {

                return await(from login in _context.Login
                             join staff in _context.Staff on login.StaffId equals staff.StaffId
                             where login.LoginId == username && login.Password == password
                             select new LoginView
                             {
                             Username=staff.FirstName,
                             StaffId=(int)login.StaffId,
                             LoginId=login.LoginId
                             }
                              ).FirstOrDefaultAsync();
            }
            return null;
        }
    }
}
