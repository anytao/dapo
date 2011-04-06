using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azur.Dapo.MQ
{
    /// <summary>
    /// A cache manager for AtMq
    /// </summary>
    public class AtMqCache
    {
        public static AtMqCache Instance
        {
            get
            {
                if (instance == null)
                {

                    lock (sync)
                    {

                        if (instance == null)
                        {
                            instance = new AtMqCache();
                        }
                    }
                }

                return instance;
            }
        }


        static AtMqCache()
        {
            // TODO: Complete member initialization
            
        }

        public AtMqCache()
        {
            cache = GetCacheStrategy();
        }

        private ICacheStrategy GetCacheStrategy()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get CacheStrategy by CacheConfig, 
        /// CacheStrategy will consume CacheProvider with different Strategy.
        /// </summary>
        private ICacheStrategy cache = null;

        private static AtMqCache instance = null;

        private static readonly object sync = new object();
    }
}
