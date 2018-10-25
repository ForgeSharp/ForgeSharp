using System;
using DNet.Core;
using DNet.Fragments;
using DNet.Structures;

namespace DNet.Commands
{
    public abstract class GenericCommand : IPackage, IDisposable
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string Author { get; }
        public abstract string Version { get; }

        protected readonly Bot Bot;
        protected readonly Message Message;
        protected readonly Message Msg;

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

    public abstract class Command : GenericCommand
    {
        //
    }

    public class CommandName : Attribute
    {
        public readonly string Name;

        public CommandName(string name)
        {
            this.Name = name;
        }
    }
}