using System;
using System.Collections.Generic;
using System.Text;

namespace Anno.Plugs.SamsundotService.EventHandler
{
    using Anno.Log;
    using Anno.EventBus;
    using Events;

    class FirstMessageEventHandler : IEventHandler<FirstMessageEvent>
    {
        public void Handler(FirstMessageEvent entity)
        {
            Log.Info(new { Plugs= "Samsundot",Entity=entity },typeof(FirstMessageEventHandler));
        }
    }
}
