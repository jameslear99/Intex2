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
        public string SelectedDepth { get; set; }
        public string SelectedSex { get; set; }
        public string SelectedHeadDir { get; set; }
        public string SelectedAgeAtDeath { get; set; }
        public string SelectedHairColor { get; set; }
        public string SelectedWrapping { get; set; }
        public long LastId { get; set; }
        public CombinedPhotoInfo CombinedPhotoInfo { get; set; }

    }
}
