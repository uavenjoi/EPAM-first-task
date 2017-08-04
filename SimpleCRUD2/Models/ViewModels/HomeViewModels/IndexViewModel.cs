using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD2.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<UserModel> Users { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}