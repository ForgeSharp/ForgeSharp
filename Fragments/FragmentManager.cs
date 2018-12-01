using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgeSharp.Fragments
{
    public abstract class FragmentManager<FragmentType> where FragmentType : IFragment
    {
        protected Dictionary<string, FragmentType> fragments = new Dictionary<string, FragmentType>();

        // TODO: Verify type is typeof(Command)?
        // TODO: Returning boolean + throwing
        public bool Register(FragmentType fragment)
        {
            // TODO: May override already existing fragments
            this.fragments.Add(fragment.Name, fragment);

            return false;
        }

        public bool RegisterByType(Type type)
        {
            FragmentType fragment = this.CreateInstance(type);

            return this.Register(fragment);
        }

        public virtual int RegisterMultipleByType(params Type[] types)
        {
            int registered = 0;

            for (int i = 0; i < types.Length; i++)
            {
                if (this.RegisterByType(types[i]))
                {
                    registered++;
                }
            }

            return registered;
        }

        public virtual int RegisterMultiple(params FragmentType[] fragments)
        {
            int registered = 0;

            for (int i = 0; i < fragments.Length; i++)
            {
                if (this.Register(fragments[i]))
                {
                    registered++;
                }
            }

            return registered;
        }

        public virtual FragmentType CreateInstance(Type type)
        {
            return (FragmentType)Activator.CreateInstance(type);
        }

        public virtual bool IsRegistered(string name)
        {
            return this.fragments.ContainsKey(name);
        }
    }
}
