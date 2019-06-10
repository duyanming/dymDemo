using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dym.Rpc;

namespace YY.AppCenter.Accept
{
    public class BusinessImpl : BrokerCenter.Iface
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool add_broker(Dictionary<string, string> input)
        {
            ThriftConfig tc = ThriftConfig.CreateInstance();
            return tc.Add(input);
        }
        /// <summary>
        /// 获取微服务地址
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public List<Micro> GetMicro(string channel)
        {
            return Distribute.GetMicro(channel);
        }
    }
}
