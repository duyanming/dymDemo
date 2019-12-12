using System;
using System.Collections.Generic;
using System.Text;
using Anno.EngineData;

namespace Anno.Plugs.SamsundotService
{
    public class SamsundotModule : BaseModule
    {
        public SamsundotModule()
        {

        }
        [Filter.AuthFilter]
        public ActionResult Samsundot()
        {
            var xx = RequestString("XX");
            Console.WriteLine($"来自客户端的消息：{xx}");
            return new ActionResult(true, new { Msg = " I from Anno.Plugs.SamsundotService MyFirstModule!" }, null, xx);
        }
        public ActionResult SameMsg([FromBody] InputDto input, InputDto inputP,string router,string Age)
        {
            return new ActionResult(true,
                new
                {
                    RequestBody = this.Input,
                    Paramsinput = input,
                    ParamsinputP = inputP,
                    Msg = " I from Anno.Plugs.SamsundotService SamsundotModule!"
                }
                );
        }
    }
    public class InputDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
