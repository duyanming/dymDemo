using System;
using System.Collections.Generic;
using System.Text;

namespace dym.Plugs.SamsundotService.EventHandler
{
    using dym.EventBus;
    using Events;

    class FirstMessageEventHandler : IEventHandler<FirstMessageEvent>
    {
        public void Handler(FirstMessageEvent entity)
        {
            Log.Log.Info(new { Plugs= "Samsundot",Entity=entity },typeof(FirstMessageEventHandler));
        }
    }
}
