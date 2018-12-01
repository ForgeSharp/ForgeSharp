using System;
using System.Collections.Generic;
using System.Text;

namespace ForgeSharp.Fragments
{
    public interface IPackage : IFragment
    {
        string Description { get; }
        string Author { get; }
        string Version { get; }
    }
}
