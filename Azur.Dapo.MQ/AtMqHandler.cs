using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActorLite;

namespace Azur.Dapo.MQ
{
    public class AtMqHandler : Actor<MQItem>
    {
        protected override void Receive(MQItem message)
        {
        }
    }
}
