using System;
using dym.EventBus;

namespace Events
{
    public class FirstMessageEvent:EventData
    {
        public string Message { get; set; }
    }
}
