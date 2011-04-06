using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Azur.Dapo.MQ.Exception
{
    public class BrokenQueueItemException : IOException
    {
        public BrokenQueueItemException(long lastPosition, System.Exception ex)
        {
 
        }
    }
}
