using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Data
{
    public static class TensorExtensions
    {
        public static int ArgMax(this Tensor<float> tensor)
        {
            int maxIndex = 0;
            float maxValue = tensor.GetValue(0);
            for (int i = 1; i < tensor.Length; i++)
            {
                float currentValue = tensor.GetValue(i);
                if (currentValue > maxValue)
                {
                    maxValue = currentValue;
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
    }

}
