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
            return new ActionResult(true, new { Msg = " I from dym.Plugs.YYTestService MySecondModule!" }, null, null);
        }
    }
}
