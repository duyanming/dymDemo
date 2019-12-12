using Anno.EngineData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anno.Plugs.YYTestService
{
    using Anno.EventBus;
    public class MyFirstModule: BaseModule
    {
        public MyFirstModule() {
        }

        public ActionResult MyT() {
            var xx = RequestString("XX");
            Console.WriteLine($"来自客户端的消息：{xx}");
            EventBus.Instance.PublishAsync(new Events.FirstMessageEvent()
            {
                Message = xx
            }); 
            return new ActionResult(true,new { Msg= " I from Anno.Plugs.YYTestService MyFirstModule!" },null, xx);
        }
    }
}
