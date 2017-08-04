using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD2.Data.Models
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
