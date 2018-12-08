using ForgeSharp.Fragments;
using System;

namespace ForgeSharp.Commands
{
    public abstract class GenericCommand : IFragment, IDisposable
    {
        public abstract Meta Meta { get; }

        public abstract void Run(Context context);

        public virtual bool MayRun(Context context)
        {
            return true;
        }

        public virtual void Dispose()
        {
            return;
        }
    }
}