using Intex2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Models
{
    public interface IMummyProjectRepository
    {
        IQueryable<Burialmain> Mummies { get; }
    }
}
