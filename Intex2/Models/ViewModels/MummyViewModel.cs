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
        public IQueryable<Textile> Textiles { get; set; }
        public IQueryable<BurialmainTextile> BridgeTable { get; set; }
        public IQueryable<Photodata> Photodata { get; set; }
        public IQueryable<PhotodataTextile> PhotoBridge { get; set; }
        public PageInfo PageInfo { get; set; }

       /* public MummyViewModel(Intex2Context context)
        {
            Mummies = context.Burialmain;
            Textiles = context.Textile;
            BridgeTable = context.BurialmainTextile;
            Photodata = context.Photodata;
            PhotoBridge = context.PhotodataTextile;

            // Join the Burialmain and Textile tables using the BurialmainTextile bridge table
            var joinedData = from mummy in Mummies
                             join bridge in BridgeTable on mummy.Id equals bridge.MainBurialmainid
                             join textile in Textiles on bridge.MainTextileid equals textile.Id
                             select new { mummy, textile };

            // Set the joined data as the Mummies property
            Mummies = joinedData.Select(j => j.mummy);
        }*/
    }
}
