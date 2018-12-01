using System;
using ForgeSharp.Fragments;

namespace ForgeSharp.Commands
{
    public abstract class GenericCommand : IPackage, IDisposable
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract string Author { get; }

        public abstract string Version { get; }

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