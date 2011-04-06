using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Azur.Dapo.MQ
{
    public class Counter
    {
        private static long value = 0;

        public long Get()
        {
            return value;
        }

        public void Set(long n)
        {
            value = n;
        }

        public void Increase()
        {
            Interlocked.Increment(ref value);
        }

        public void Increase(long n)
        {
            Interlocked.Add(ref value, n);
        }

        public void Decrease()
        {
            Interlocked.Decrement(ref value);
        }

        public void Decrease(long n)
        {
            Interlocked.Add(ref value, -n);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
