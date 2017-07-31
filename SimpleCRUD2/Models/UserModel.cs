using System;
using System.ComponentModel.DataAnnotations;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }

        public UserModel(User user)
        {
            this.UserId = user.UserId;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Location = user.Location;
            this.Birthday = user.Birthday;
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "The name must be at least 2 characters and no longer than 15")]
        public string Name { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The surname must be no longer than 25 characters")]
        public string Surname { get; set; }

        [StringLength(30, ErrorMessage = "The name of location must be no longer than 30 characters")]
        public string Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
    }
}