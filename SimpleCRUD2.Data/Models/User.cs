using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD2.Data.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
    }
}