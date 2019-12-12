using System;
using System.Collections.Generic;
using System.Text;

namespace Anno.Plugs.YYTestService.EventHandler
{
    using Anno.EventBus;
    using Events;

    class FirstMessageEventHandler : IEventHandler<FirstMessageEvent>
    {
        public void Handler(FirstMessageEvent entity)
        {
            Log.Log.Info(new { Plugs = "YYTest", Entity = entity }, typeof(FirstMessageEventHandler));
        }
    }
    /// <summary>
    /// 异常消费演示，测试 消费失败通知
    /// </summary>
    class FirstMessageExceptionEventHandler : IEventHandler<FirstMessageEvent>
    {
        public void Handler(FirstMessageEvent entity)
        {
            Log.Log.Info(new { Plugs = "YYTest",Handle= "FirstMessageExceptionEventHandler", Entity = entity }, typeof(FirstMessageEventHandler));
            throw new Exception("异常消费演示，测试 消费失败通知 From FirstMessageExceptionEventHandler!");
        }
    }
}
