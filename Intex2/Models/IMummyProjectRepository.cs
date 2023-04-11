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
        IQueryable<Textile> Textiles { get; }
        IQueryable<BurialmainTextile> BridgeTable { get; }
        IEnumerable<Textile> GetAllTextile();
        Textile GetTextileById(int id);
        void AddRecord(Textile record);
        void UpdateRecord(Textile record);
        void DeleteRecord(Textile record);
        
      
    }
}