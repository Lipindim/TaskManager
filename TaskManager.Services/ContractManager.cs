using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services.Contract;

namespace TaskManager.Services
{
    public static class ContractManager
    {
        public static IUserContract GetUserContract()
        {
            return ChannelFactory<IUserContract>.CreateChannel(new NetTcpBinding() { MaxBufferSize = 64000000, MaxReceivedMessageSize = 64000000 }, new EndpointAddress("net.tcp://localhost:9000/IUserContract"));
        }

        public static ITaskContract GetTaskContract()
        {
            return ChannelFactory<ITaskContract>.CreateChannel(new NetTcpBinding() { MaxBufferSize = 64000000, MaxReceivedMessageSize = 64000000 }, new EndpointAddress("net.tcp://localhost:9000/ITaskContract"));
        }
    }
}
