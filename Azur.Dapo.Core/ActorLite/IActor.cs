using System;
using System.Collections.Generic;

namespace ActorLite
{
    internal interface IActor
    {
        void Execute();

        bool Existed { get; }

        int MessageCount { get; }

        ActorContext Context { get; }
    }
}
