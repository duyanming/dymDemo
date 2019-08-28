using System;
using System.Collections.Generic;
using System.Text;
using dym.EngineData;

namespace dym.Plugs.SamsundotService
{
    public class SamsundotModule : BaseModule
    {
        public SamsundotModule()
        {

        }
        public ActionResult Samsundot()
        {
            var xx = RequestString("XX");
            Console.WriteLine($"来自客户端的消息：{xx}");
            return new ActionResult(true, new { Msg = " I from dym.Plugs.SamsundotService MyFirstModule!" }, null, xx);
        }
    }
}
