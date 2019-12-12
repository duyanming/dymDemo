using System;
using System.Collections.Generic;
using System.Text;
using Anno.EngineData;
using Anno.EngineData.Filters;

namespace Anno.Plugs.SamsundotService.Filter
{
   public class AuthFilter:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(BaseModule context)
        {
            if (!context.Authorized&&context.RequestContainsKey("XX")&&context.RequestString("XX").Contains("Anno"))
            {
                context.Authorized = true;
            }
        }
    }
}
