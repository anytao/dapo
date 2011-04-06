using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace Azur.Dapo.MQ
{
    // Kestrel

    public class AtMqManager
    {
        public AtMqManager()
        {
 
        }

        public int Open(AtMqConfig config)
        {
            return 0;
        }

        public int Close()
        {
            return 0;
        }




        #region Variables

        private readonly int DEFAULTPORT = 21212;

        private Logger logger = LogManager.GetCurrentClassLogger();
        private QueueCollection queues = null;

        private IDictionary<string, int> status = new Dictionary<string, int>();
        private int startTime = DateTime.Now.Millisecond;

        

        private ICacheStrategy cache;

        #endregion

    }
}
