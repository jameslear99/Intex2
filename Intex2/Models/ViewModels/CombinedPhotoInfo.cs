using Intex2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Models.ViewModels
{
    public class CombinedPhotoInfo
    {
        public IEnumerable<Burialmain> Mummies { get; set; }
        public IEnumerable<Textile> Textiles { get; set; }
        public IEnumerable<BurialmainTextile> BridgeTable { get; set; }
        public IEnumerable<Photodata> Photodata { get; set; }
        public IEnumerable<PhotodataTextile> PhotoBridge { get; set; }
        public Dictionary<int, List<string>> FilenamesByBurialMainId { get; set; }

        public CombinedPhotoInfo(Intex2Context context)
        {
            Mummies = context.Burialmain;
            Textiles = context.Textile;
            BridgeTable = context.BurialmainTextile;
            Photodata = context.Photodata;
            PhotoBridge = context.PhotodataTextile;

            // Join the Burialmain, Textile, Photodata, and PhotodataTextile tables
            var joinedData = from mummy in Mummies
                             join bridge in BridgeTable on mummy.Id equals bridge.MainBurialmainid
                             join textile in Textiles on bridge.MainTextileid equals textile.Id
                             join photoBridge in PhotoBridge on textile.Id equals photoBridge.MainTextileid
                             join photoData in Photodata on photoBridge.MainPhotodataid equals photoData.Id
                             select new { mummy.Id, photoData.Filename };

            // Group the filenames by burialmain id
            FilenamesByBurialMainId = joinedData
                .GroupBy(d => (int)d.Id, d => d.Filename)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
