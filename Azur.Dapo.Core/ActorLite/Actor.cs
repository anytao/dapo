using System;
using System.Collections.Generic;

namespace ActorLite
{
    public abstract class Actor<T> : IActor
    {
        protected abstract void Receive(T message);

        protected Actor()
        {
            this.m_context = new ActorContext(this);
        }

        private ActorContext m_context = null;
        ActorContext IActor.Context
        {
            get
            {
                return this.m_context;
            }
        }

        bool IActor.Existed
        {
            get
            {
                return this.m_exited;
            }
        }

        int IActor.MessageCount
        {
            get
            {
                return this.m_messageQueue.Count;
            }
        }

        void IActor.Execute()
        {
            T message;
            lock (this.m_messageQueue)
            {
                message = this.m_messageQueue.Dequeue();
            }

            this.Receive(message);
        }

        private bool m_exited = false;
        private Queue<T> m_messageQueue = new Queue<T>();

        protected void Exit()
        {
            this.m_exited = true;
        }

        public void Post(T message)
        {
            if (this.m_exited) return;

            lock (this.m_messageQueue)
            {
                this.m_messageQueue.Enqueue(message);
            }

            Dispatcher.Instance.ReadyToExecute(this);
        }
    }
}
