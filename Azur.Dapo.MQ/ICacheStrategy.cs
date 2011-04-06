using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azur.Dapo.MQ
{
    public interface ICacheStrategy
    {
        void Add(string key, object value);

        void Remove(string key);

        object Get(string key);

        int Timeout { get; set; }
    }
}
