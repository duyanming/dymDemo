using System;
using Anno.EventBus;

namespace Events
{
    public class FirstMessageEvent:EventData
    {
        public string Message { get; set; }
    }
}
