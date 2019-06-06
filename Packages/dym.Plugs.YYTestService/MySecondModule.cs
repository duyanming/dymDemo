using dym.EngineData;
using System;
using System.Collections.Generic;
using System.Text;

namespace dym.Plugs.YYTestService
{
    public class MySecondModule : BaseModule
    {
        public MySecondModule()
        {
        }
        public ActionResult MyT()
        {
            var xx = RequestString("XX");
            Console.WriteLine($"来自客户端的消息：{xx}");
            return new ActionResult(true, new { Msg = " I from dym.Plugs.YYTestService MySecondModule!" }, null, xx);
        }
    }
}
