/*
 * 2011, Anytao.com, http://anytao.net/project/dapomq
 * 
 * Dapo.MQ, a .net based distributed publish/subscribe messaging system.
 * 
 * Licensed under the Apache License, V2.0, http://www.apache.org/licenses/LICENSE-2.0
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azur.Dapo.MQ
{

    public interface IMQueue<TItem> where TItem : MQItem
    {
        void Send(string key, TItem item);
        void Send(TItem item);

        void Send(Action<TItem> action, TItem item);

        TItem Get();
        
        /// <summary>
        /// Get all queue items
        /// </summary>
        /// <returns></returns>
        IList<TItem> Gets();

        /// <summary>
        /// Get the queue item count
        /// </summary>
        int Count { get; }



        //TItem Dequeue();
        //void Enqueue(TItem item);

        //TItem Get(string key);
        //void Add(string key, TItem item);
    }
}
