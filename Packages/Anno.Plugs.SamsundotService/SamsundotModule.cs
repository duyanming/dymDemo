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
    }
}
