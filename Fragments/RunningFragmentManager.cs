using ForgeSharp.Fragments;
using System;
using System.Linq;

namespace ForgeSharp.Services
{
    public abstract class RunningFragmentManager<FragmentType> : FragmentManager<FragmentType> where FragmentType : IFragment
    {
        private readonly string[] running = new string[] { };

        public bool IsRunning(string name)
        {
            return this.running.Contains(name);
        }
    }
}
