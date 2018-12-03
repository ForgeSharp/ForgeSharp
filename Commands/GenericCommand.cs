using System;
using ForgeSharp.Fragments;

namespace ForgeSharp.Commands
{
    public abstract class GenericCommand : IPackage, IDisposable
    {
        public abstract string Name { get; }

        public virtual string Description { get; } = "No description provided.";

        public virtual string Author { get; } = "Anonymous";

        public virtual string Version { get; } = "1.0.0";

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