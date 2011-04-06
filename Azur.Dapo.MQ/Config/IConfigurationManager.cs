using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azur.Dapo.MQ.Config
{
    public interface IConfigurationManager
    {
        string Version { get; }

        IEnumerable<IAtMqConfiguration> MQ { get; set; }
        IEnumerable<ICacheProviderConfiguration> CacheProvider { get; set; }
    }
}
