using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Intex2.Data;
using System.Web;

namespace Intex2.Controllers
{
    [ApiController]
    [Route("/score")]
    public class APIController : ControllerBase
    {
        private InferenceSession _session;

        public APIController(InferenceSession session)
        {
            _session = session;
        }

        [HttpPost]
        public ActionResult Score([FromBody] MummyData data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
            Tensor<string> score = result.First().AsTensor<string>();
            var prediction = new Prediction { PredictedValue = score.First()};
            var output = MyApi.GenerateOutput(data.sex_, data.headdirection_, data.adultsubadult_, data.preservation_, data.goods_, data.haircolor_, data.ageatdeath_, data.depth, data.length);
            result.Dispose();
            return Json(new {output });
        }


    }
}
