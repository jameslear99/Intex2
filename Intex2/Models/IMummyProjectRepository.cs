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
        IEnumerable<Burialmain> GetAll();
        Burialmain GetById(int id);
        void AddRecord(Burialmain record);
        void UpdateRecord(Burialmain record);
        void DeleteRecord(Burialmain record);
    }
}
