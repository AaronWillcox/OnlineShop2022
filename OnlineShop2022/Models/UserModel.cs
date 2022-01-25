using Microsoft.AspNetCore.Identity;

namespace OnlineShop2022.Models
{
    public class UserModel : IdentityUser
    {
        public string Firstname { get; set;}

        public string Surname { get; set; }
    }
}
