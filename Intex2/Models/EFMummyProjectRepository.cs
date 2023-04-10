using Intex2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Models
{
    public class EFMummyProjectRepository : IMummyProjectRepository
    {
        private Intex2Context context { get; set; }
        public EFMummyProjectRepository(Intex2Context temp) => context = temp;
        public IQueryable<Burialmain> Mummies => context.Burialmain ;

    }
}
