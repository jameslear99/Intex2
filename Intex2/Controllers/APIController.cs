using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Intex2.Models;

namespace Intex2.Controllers
{
    [Route("/score")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private InferenceSession _session;
        public APIController(InferenceSession session)
        {
            _session = session;
        }

        [HttpPost]
        public ActionResult Score(MummyData data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            { 
                NamedOnnxValue.CreateFromTensor("input_data_type" , data.AsTensor())
            });

            Tensor<float> score = result.First().AsTensor<float>();
            var prediction = new Prediction { PredictedValue = (int)(score.First() * 100000) };
            result.Dispose();
            return Ok(prediction);
        }
    }
}
