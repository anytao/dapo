using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azur.Dapo.MQ.CacheProvider;

namespace Azur.Dapo.MQ.CacheStrategy
{
    public class EasyCacheStrategy : CacheStrategyBase<EasyCache>, ICacheStrategy
    {
        public override EasyCache Provider
        {
            get
            {
                if (this.provider != null)
                {
                    this.provider = new EasyCache();
                }

                return this.provider;
            }
        }

        private EasyCache provider;

        #region ICacheStrategy Members

        public void Add(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            throw new NotImplementedException();
        }

        public int Timeout
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
