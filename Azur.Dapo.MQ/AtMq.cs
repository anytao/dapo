/*
 * 2011, Anytao.com, http://anytao.net/project/dapomq
 * 
 * Dapo.MQ, a .net based distributed publish/subscribe messaging system.
 * Support to queue the item in different distributed caching container: Redis, MemCached, EasyCache
 * 
 * Licensed under the Apache License, V2.0, http://www.apache.org/licenses/LICENSE-2.0
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Messaging;
using NLog;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Azur.Dapo.MQ.Channel;
using System.IO;

namespace Azur.Dapo.MQ
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class AtMq<TItem> : MarshalByRefObject, IMQueue<TItem> where TItem : MQItem
    {
        #region Properties

        public int Port { get; set; }
        public string Address { get; set; }
        public string Authorization { get; set; }

        public AtMq(IChannel channel, string address, int port)
        {
            this.channel = channel;
            this.Address = address;
            this.Port = port;

            this.Init();
        }

        private void Init()
        {
            if (this.channel == null)
            {
                channel = ChannelFactory.Create();

                ChannelServices.RegisterChannel(channel, false);
            }
        }



        #endregion

        #region IMQueue<TItem> Members

        public void Send(string key, TItem item)
        {
            throw new NotImplementedException();
        }

        public void Send(TItem item)
        {
            throw new NotImplementedException();
        }

        public TItem Get()
        {
            throw new NotImplementedException();
        }

        public IList<TItem> Gets()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        private void Log(string info)
        {

        }

        private void Connect()
        {
            if (channel == null)
            {
                channel = DoCnnect();
            }
        }

        private IChannel DoCnnect()
        {
            if (channel == null )
            {
                return ChannelFactory.Create();
            }

            return null;
        }

        private void Disconnect()
        {
            ChannelServices.UnregisterChannel(this.channel);
        }

        private void Send(string message)
        {
            lock (sync)
            {
                // Do connected
                this.channel = DoCnnect();

                try
                {
                    
                }
                catch (IOException ex)
                {
                    Disconnect();
                    throw ex;
                }
            }
        }

        #endregion

        #region Variables

        Logger logger = LogManager.GetCurrentClassLogger();

        IChannel channel;

        private readonly object sync = new object();

        #endregion

        #region IMQueue<TItem> Members

        public void Send(Action<TItem> action, TItem item)
        {
            if (action != null)
            {
                action(item);
            }

        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
