using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleCRUD2.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "The name must be at least 2 characters and no longer than 15")]
        public string Name { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The surname must be no longer than 25 characters")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Пароль не может быть короче 6 символов или длиннее 30")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}