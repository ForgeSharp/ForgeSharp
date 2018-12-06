using ForgeSharp.Core;
using ForgeSharp.Fragments;

namespace ForgeSharp.Services
{
    public abstract class GenericService : IPackage
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract string Author { get; }

        public abstract string Version { get; }

        private Bot Bot { get; }

        public GenericService()
        {
            this.Bot = null;
        }

        public GenericService(Bot bot)
        {
            this.Bot = bot;
        }

        public abstract void Start();

        public virtual void Stop()
        {
            //
        }

        public virtual bool MayStart()
        {
            return true;
        }
    }
}
