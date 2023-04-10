using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumMummy { get; set; }

        public int MummyPerPage { get; set; }

        public int CurrentPage { get; set; }

        //dynamically populate this property with the total number of pages you need
        public int TotalPages => (int)Math.Ceiling((double)TotalNumMummy / MummyPerPage);
    }
}
