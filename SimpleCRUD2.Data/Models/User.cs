using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD2.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
    }
}