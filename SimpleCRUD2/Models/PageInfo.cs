using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD2.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages  
        {
            get { return (int)Math.Ceiling((decimal)this.TotalItems / this.PageSize); }
        }

        public int PageCountPerPage
        {
            get { return this.TotalPages <= 5 ? this.TotalPages : 5; }
        }
    }
}