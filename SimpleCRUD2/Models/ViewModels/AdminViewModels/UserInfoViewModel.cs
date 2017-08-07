using System.Collections.Generic;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Models.ViewModels.AdminViewModels
{
    public class UserInfoViewModel
    {
        public UserModel UserModel { get; set; }

        public ICollection<Role> UserRoles { get; set; }

        public string RoleName { get; set; }
    }
}