﻿using dym.EngineData;
using dym.Rpc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace YY.Server
{
    public class BusinessImpl : BrokerService.Iface
    {
        public string broker(Dictionary<string, string> input)
        {
            ActionResult actionResult = null;
            try
            {
                actionResult = Engine.Transmit(input);
            }
            catch (Exception ex)
            { //记录异常日志
                actionResult = new ActionResult
                {
                    Msg = ex.InnerException.Message
                };
            }
            return JsonConvert.SerializeObject(actionResult);
        }
    }
}
