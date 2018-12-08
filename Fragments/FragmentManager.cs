using ForgeSharp.Core;
using System;
using System.Collections.Generic;

namespace ForgeSharp.Fragments
{
    public abstract class FragmentManager<T> where T : IFragment
    {
        protected Dictionary<string, T> fragments = new Dictionary<string, T>();

        public int Count => fragments.Count;

        // TODO: Verify type is typeof(Command)?
        // TODO: Returning boolean + throwing
        public bool Register(T fragment)
        {
            // TODO: Regex-check names
            if (fragment.Meta.Name == null)
            {
                throw new InvalidMetaException("Fragment must have a valid meta");
            }

            // TODO: May override already existing fragments
            this.fragments.Add(fragment.Meta.Name.Trim().ToLower(), fragment);

            return false;
        }

        public bool RegisterByType(Type type)
        {
            T fragment = this.CreateInstance(type);

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

        public virtual int RegisterMultiple(params T[] fragments)
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

        public virtual T CreateInstance(Type type)
        {
            return (T)Activator.CreateInstance(type);
        }

        public virtual bool IsRegistered(string name)
        {
            return this.fragments.ContainsKey(name);
        }
    }
}
