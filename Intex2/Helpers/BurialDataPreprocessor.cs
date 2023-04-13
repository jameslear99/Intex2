using Microsoft.ML;
using Microsoft.ML.OnnxRuntime.Tensors;
using Intex2.Data;
using System.Collections.Generic;
using Microsoft.ML.Data;
using System.Linq;

namespace Intex2.Helpers
{
    public static class BurialDataPreprocessor
    {
        public static Tensor<float> PreprocessInput(BurialData input)
        {
            var mlContext = new MLContext();

            var rawData = new List<BurialData> { input };
            var dataView = mlContext.Data.LoadFromEnumerable(rawData);

            // Define the one-hot encoding transformations for categorical features
            var preprocessingPipeline = mlContext.Transforms.Categorical.OneHotEncoding("Sex")
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("HeadDirection"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("AdultSubadult"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("Preservation"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("Goods"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("HairColor"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("AgeAtDeath"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("ClusterNumber"));

            // Fit and transform the data
            var transformedData = preprocessingPipeline.Fit(dataView).Transform(dataView);

            // Convert the transformed data to a tensor
            var features = transformedData.GetColumn<float[]>("Features").ToArray();
            var flattenedFeatures = features[0].ToArray(); // Flatten the float[][] to a float[].
            var tensor = new DenseTensor<float>(flattenedFeatures, new[] { 1, flattenedFeatures.Length });

            return tensor;
        }

    }
}
