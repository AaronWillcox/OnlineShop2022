using OnlineShop2022.Models;
using System.Collections.Generic;

namespace OnlineShop2022.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        public UserModel User { get; set; }

        public List<string> Roles { get; set; }
    }
}
