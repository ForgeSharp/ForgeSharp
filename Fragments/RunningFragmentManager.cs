using ForgeSharp.Fragments;
using System;
using System.Linq;

namespace ForgeSharp.Services
{
    public abstract class RunningFragmentManager<T> : FragmentManager<T> where T : IFragment
    {
        private readonly string[] running = new string[] { };

        public bool IsRunning(string name)
        {
            return this.running.Contains(name);
        }
    }
}
