using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Data
{
    public class MummyData
    {
        public float depth { get; set; }
        public float length { get; set; }
        public float sex_ { get; set; }
        public float ageatdeath_ { get; set; }
        public float adultsubadult_ { get; set; }
        public float headdirection_ { get; set; }
        public float haircolor_ { get; set; }
        public float preservation_ { get; set; }
        public float goods_ { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            depth, length, sex_, ageatdeath_, adultsubadult_, headdirection_, haircolor_, preservation_, goods_
            };
            int[] dimensions = new int[] { 1, 9 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
