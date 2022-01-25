﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop2022.Areas.Admin.Models;
using OnlineShop2022.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop2022.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UserModel> _userManager;    
        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<UserModel> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var VMlist = new List<UserRolesViewModel>();

            foreach (var user in users)
            {
                var currentVM = new UserRolesViewModel()
                {
                    User = user,
                    Roles = new List<string>(await _userManager.GetRolesAsync(user))
                };

                VMlist.Add(currentVM);
            }

            return View(VMlist);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var roles = await _userManager.GetRolesAsync(user);
            
            await _userManager.RemoveFromRolesAsync(user, roles);

            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Manage(string id)
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var viewModels = new List<ManageUserRolesViewModel>();

            foreach (var role in _roleManager.Roles)
            {
                var vm = new ManageUserRolesViewModel();
                vm.User = user;
                vm.Role = role;
                vm.IsInRole = await _userManager.IsInRoleAsync(user, role.Name);

                viewModels.Add(vm);
            }

            return View(viewModels);
        }

    }
}
