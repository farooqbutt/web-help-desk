using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHelpDeskApp.Data;
using WebHelpDeskApp.Models;

namespace WebHelpDeskApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var managers = await(from user in _context.ApplicationUsers
                              join userRole in _context.UserRoles
                              on user.Id equals userRole.UserId
                              join role in _context.Roles
                              on userRole.RoleId equals role.Id
                              where role.Name == "Manager"
                              select user)
                                 .ToListAsync();
            var employees = await (from user in _context.ApplicationUsers
                                  join userRole in _context.UserRoles
                                  on user.Id equals userRole.UserId
                                  join role in _context.Roles
                                  on userRole.RoleId equals role.Id
                                  where role.Name == "Employee"
                                  select user)
                                 .ToListAsync();
            var tuple = new Tuple<List<ApplicationUser>, List<ApplicationUser>>(managers, employees);
            return View(tuple);
        }
    }
}
