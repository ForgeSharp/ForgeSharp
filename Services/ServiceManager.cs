using ForgeSharp.Core;
using ForgeSharp.Fragments;

namespace ForgeSharp.Services
{
    public class ServiceManager : FragmentManager<GenericService>
    {
        private readonly Bot bot;

        public ServiceManager(Bot bot)
        {
            this.bot = bot;
        }

        public bool Start(string name)
        {
            if (!this.fragments.ContainsKey(name))
            {
                return false;
            }

            GenericService service = this.fragments[name];

            if (!service.MayStart())
            {
                return false;
            }

            service.Start();

            return true;
        }
    }
}
