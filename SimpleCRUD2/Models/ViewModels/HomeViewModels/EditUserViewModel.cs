using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleCRUD2.Models.ViewModels.HomeViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
        }

        public EditUserViewModel(UserModel userModel)
        {
            this.UserId = userModel.UserId;
            this.Name = userModel.Name;
            this.Surname = userModel.Surname;
            this.Location = userModel.Location;
            this.Birthday = userModel.Birthday;
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