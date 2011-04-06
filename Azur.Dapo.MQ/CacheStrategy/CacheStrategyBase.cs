using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azur.Dapo.MQ.CacheStrategy
{
    public abstract class CacheStrategyBase<TProvider>
        where TProvider : ICacheProvider
    {
        private CacheStrategyConfig config = null;

        public abstract TProvider Provider { get; }
    }
}
