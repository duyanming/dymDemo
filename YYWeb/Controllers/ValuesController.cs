using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anno.Rpc.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YYWeb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public void Get()

        {
            Api();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post()
        {
            Api();
        }

        private Task Api()
        {
            Response.ContentType = "Content-Type: application/javascript; charset=utf-8";
            Dictionary<string, string> input = new Dictionary<string, string>();
            #region 接收表单参数
            try
            {
                if (Request.Method == "POST")
                {
                    foreach (string k in Request.Form.Keys)
                    {
                        input.Add(k, Request.Form[k]);
                    }
                }
            }
            finally
            {
                foreach (string k in Request.Query.Keys)
                {
                    if (!input.ContainsKey(k))
                    {
                        input.Add(k, Request.Query[k]);
                    }
                }
            }
            #endregion
            #region 处理
            var rlt = Connector.BrokerDns(input);
            #endregion
            return Response.WriteAsync(rlt);
        }
    }
}
