using Intex2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Models.ViewModels
{
    public class MummyViewModel
    {
        public IQueryable<Burialmain> Mummies { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
