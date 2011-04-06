using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Azur.Dapo.MQ.Channel
{
    public class ChannelFactory
    {
        public static IChannel Create()
        {
            return new TcpChannel();
        }
    }
}
