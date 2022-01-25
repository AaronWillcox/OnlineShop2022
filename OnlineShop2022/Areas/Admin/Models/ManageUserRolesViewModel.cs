using Microsoft.AspNetCore.Identity;
using OnlineShop2022.Models;

namespace OnlineShop2022.Areas.Admin.Models
{
    public class ManageUserRolesViewModel
    {
        public UserModel User { get; set; }

        public IdentityRole  Role { get; set; }

        public bool IsInRole { get; set; }
    }
}
