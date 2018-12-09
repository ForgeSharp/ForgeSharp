using ForgeSharp.Core;
using System.Collections.Generic;

namespace ForgeSharp.Services
{
    public class ServiceManager : RunningFragmentManager<GenericService>
    {
        // TODO: Better name
        public delegate void ActionAllCallback(GenericService service, int current, int left);

        protected readonly Bot bot;

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

        // TODO: Simplify/merge this using delegates
        public int StartAll(ActionAllCallback callback = null)
        {
            int started = 0;

            foreach (KeyValuePair<string, GenericService> entry in this.fragments)
            {
                if (this.Start(entry.Key))
                {
                    callback?.Invoke(entry.Value, started, this.fragments.Count - started);
                    started++;
                }
            }

            return started;
        }

        public bool Stop(string name)
        {
            if (!this.fragments.ContainsKey(name))
            {
                return false;
            }

            this.fragments[name].Stop();

            return true;
        }

        // TODO: Simplify/merge this using delegates
        public int StopAll(ActionAllCallback callback = null)
        {
            int stopped = 0;

            foreach (KeyValuePair<string, GenericService> entry in this.fragments)
            {
                if (this.Stop(entry.Key))
                {
                    callback?.Invoke(entry.Value, stopped, this.fragments.Count - stopped);
                    stopped++;
                }
            }

            return stopped;
        }
    }
}
