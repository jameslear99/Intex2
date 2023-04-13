using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Data
{

        public class BurialData
        {
            public string Sex { get; set; }
            public string HeadDirection { get; set; }
            public float Depth { get; set; }
            public string AdultSubadult { get; set; }
            public string Preservation { get; set; }
            public string Goods { get; set; }
            public string HairColor { get; set; }
            public float Length { get; set; }
            public string AgeAtDeath { get; set; }
            public string ClusterNumber { get; set; }
        }

    
}