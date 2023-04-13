using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Intex2.Data;
using Intex2.Helpers;
using System.Linq;

namespace Intex2
{
    [Route("api/[controller]")]
    [ApiController]
    public class InferenceController : ControllerBase
    {
        private readonly InferenceSession _session;

        public InferenceController(InferenceSession session)
        {
            _session = session;
        }

        [HttpPost]
        public IActionResult Score([FromBody] BurialData input)
        {
            var inputTensor = BurialDataPreprocessor.PreprocessInput(input);
            var inputOnnxValue = NamedOnnxValue.CreateFromTensor("input_data_type", inputTensor); // Replace "input_layer_name" with the actual name of the input layer in your ONNX model.
            var result = _session.Run(new[] { inputOnnxValue });
            var predictedLabel = GetPredictedLabel(result.First().AsTensor<float>());
            var prediction = new Prediction { Wrapping = predictedLabel };
            return Ok(new { predicted_wrapping = predictedLabel });
        }


        public static string GetPredictedLabel(Tensor<float> outputTensor)
        {
            // Define the label mapping
            var labelMapping = new Dictionary<int, string>
            {
                { 0, "W" },
                { 1, "H" },
                { 2, "B" },
                { 3, "U" }
            };

            // Find the class with the highest probability
            var classIndex = outputTensor.ArgMax();

            // Map the class index back to the corresponding label
            return labelMapping[classIndex];
        }
    }
}
