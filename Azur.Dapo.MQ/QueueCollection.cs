using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using System.IO;
using System.Collections;

namespace Azur.Dapo.MQ
{
    public class QueueCollection
    {
        public QueueCollection(string queueFolder)
        {
            DirectoryInfo di = new DirectoryInfo(queueFolder);

            if (!di.Exists)
            {
                di = Directory.CreateDirectory(queueFolder);
            }

            FileInfo fi = new FileInfo(queueFolder);

            if (!di.Exists)
            {
                
            }
        }

        /// <summary>
        /// Size of queue
        /// </summary>
        public long Size { get; set; }

        public long TotalItems { get; set; }

        public long TotalExpireration { get; set; }

        public long CurrentAge { get; set; }

        public long TotalDiscarded { get; set; }

        public int QueueLength { get; set; }

        private long bytes = 0;
        private bool isClosed = false;
        private bool isPaused = false;



        private Queue<MQItem> queue = new Queue<MQItem>();



        private IDictionary<string, AtMq<MQItem>> queues = new Dictionary<string, AtMq<MQItem>>();
        private IDictionary<string, HashSet<string>> fanout_queues = new Dictionary<string, HashSet<string>>();
        private bool isShuttingDown = false;

        private Counter totalAdded = new Counter();
        private Counter queueHits = new Counter();
        private Counter queueMisses = new Counter();




        private string queueFolder;

        private Logger logger = LogManager.GetCurrentClassLogger();
        //private File path = File.Create(
    }
}
