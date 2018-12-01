using System;

namespace ForgeSharp.Fragments
{
    public class FragmentIdentifierAttribute : Attribute
    {
        public readonly string Name;

        public FragmentIdentifierAttribute(string name)
        {
            this.Name = name;
        }
    }
}
