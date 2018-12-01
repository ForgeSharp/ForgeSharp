using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgeSharp.Fragments
{
    public abstract class FragmentManager<FragmentType> where FragmentType : IFragment
    {
        protected Dictionary<string, Type> fragments;

        public virtual Type GetType(string name)
        {
            return this.fragments[name];
        }

        // TODO: Verify type is typeof(Command)?
        // TODO: Returning boolean + throwing
        public bool Register(Type type)
        {
            FragmentIdentifierAttribute identifierAttribute = type.GetCustomAttributes(typeof(FragmentIdentifierAttribute), true).FirstOrDefault() as FragmentIdentifierAttribute;

            if (identifierAttribute != null)
            {
                this.fragments.Add(identifierAttribute.Name, type);

                return true;
            }
            else
            {
                throw new Exception($"Fragment class '{type.Name}' is missing required FragmentIdentifier attribute");
            }

            return false;
        }

        public virtual FragmentType CreateInstance(string name)
        {
            return this.ActivateInstance(this.GetType(name));
        }

        public virtual FragmentType ActivateInstance(Type type)
        {
            // TODO: Must ensure type to be instanceof Command or GenericCommand
            return (FragmentType)Activator.CreateInstance(type);
        }

        public virtual bool IsRegistered(string name)
        {
            return this.fragments.ContainsKey(name);
        }

        public virtual int RegisterMultiple(params Type[] fragments)
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
    }
}
