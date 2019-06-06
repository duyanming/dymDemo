using dym.EngineData;
using System;
using System.Collections.Generic;
using System.Text;

namespace dym.Plugs.YYTestService
{
    public class MyFirstModule: BaseModule
    {
        public MyFirstModule() {
        }

        public ActionResult MyT() {
            return new ActionResult(true,new { Msg= " I from dym.Plugs.YYTestService MyFirstModule!" },null,null);
        }
    }
}
