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

        #region add login
        public async Task<int> AddLogin(Login logint)
        {
            if (_context != null)
            {

                await _context.Login.AddAsync(logint);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
        #endregion

        #region login using username and password
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
                             LoginId=login.LoginId,
                             RoleId=(int)staff.RoleId,
                             }
                              ).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        #region update login
        public async Task UpdateLogin(Login login)
        {
            if (_context != null)
            {
                _context.Entry(login).State = EntityState.Modified;
                _context.Login.Update(login);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
