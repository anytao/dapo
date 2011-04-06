using System;
using System.Threading;

namespace ActorLite
{
    internal class Dispatcher
    {
        private static Dispatcher s_instance = new Dispatcher();

        public static Dispatcher Instance
        {
            get
            {
                return s_instance;
            }
        }

        public void ReadyToExecute(IActor actor)
        {
            if (actor.Existed) return;

            int status = Interlocked.CompareExchange(
                ref actor.Context.m_status,
                ActorContext.EXECUTING,
                ActorContext.WAITING);

            if (status == ActorContext.WAITING)
            {
                ThreadPool.QueueUserWorkItem(this.Execute, actor);
            }
        }

        private void Execute(object o)
        {
            IActor actor = (IActor)o;
            actor.Execute();

            if (actor.Existed)
            {
                Thread.VolatileWrite(
                    ref actor.Context.m_status,
                    ActorContext.EXITED);
            }
            else
            {
                Thread.VolatileWrite(
                    ref actor.Context.m_status,
                    ActorContext.WAITING);

                if (actor.MessageCount > 0)
                {
                    this.ReadyToExecute(actor);
                }
            }
        }
    }
}
