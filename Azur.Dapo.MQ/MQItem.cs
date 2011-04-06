using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Azur.Dapo.MQ
{
    [Serializable]
    public class MQItem
    {
        public void Pack()
        {
            MemoryStream stream = new MemoryStream();

            using (BinaryWriter writer = new BinaryWriter(stream))
            {

                
            }

            byte[] bytes = stream.ToArray();
        
        }


        public void UnPack()
        { }


        public Guid Message_id { get; set; }

        public byte Priority { get; set; }

        public DateTime Expiration { get; set; }

        public DateTime Timestamp { get; set; }


    }
}
