using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Models
{
    public class MummyData
    {
        public float sex {get;set;}
        public float headdirection { get; set; }
        public float adultsubadult { get; set; }
        public float preservation { get; set; }
        public float goods { get; set; }
        public float haircolor { get; set; }
        public float ageatdeath { get; set; }
        public float depth { get; set; }
        public float length { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                sex, headdirection, adultsubadult, preservation, goods, haircolor, ageatdeath, depth, length
            };

            int[] dimensions = new int[] { 1, 9 };
            return new DenseTensor<float>(data, dimensions);
        }

    }
}
