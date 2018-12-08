using ForgeSharp.Core;
using ForgeSharp.Fragments;

namespace ForgeSharp.Services
{
    public abstract class GenericService : IFragment
    {
        public abstract Meta Meta { get; }

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
