using Intex2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Intex2.Models
{
    public class EFMummyProjectRepository : IMummyProjectRepository
    {
        private Intex2Context context { get; set; }
        public EFMummyProjectRepository(Intex2Context temp) => context = temp;
        public IQueryable<Burialmain> Mummies => context.Burialmain;
        public IQueryable<Textile> Textiles => context.Textile;
        public IEnumerable<Burialmain> GetAll()
        {
            return context.Burialmain.ToList();
        }
        public Burialmain GetById(int id)
        {
            return context.Burialmain.Find(id);
        }
        public void AddRecord(Burialmain record)
        {
            context.Burialmain.Add(record);
            context.SaveChanges();
        }
        public void UpdateRecord(Burialmain record)
        {
            context.Entry(record).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteRecord(Burialmain record)
        {
            context.Burialmain.Remove(record);
            context.SaveChanges();
        }

        public IEnumerable<Textile> GetAllTextile()
        {
            return context.Textile.ToList();
        }
        public Textile GetTextileById(int id)
        {
            return context.Textile.Find(id);
        }
        public void AddRecord(Textile record)
        {
            context.Textile.Add(record);
            context.SaveChanges();
        }
        public void UpdateRecord(Textile record)
        {
            context.Entry(record).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteRecord(Textile record)
        {
            context.Textile.Remove(record);
            context.SaveChanges();
        }

        public void AddRecord(AddEntry entry)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}