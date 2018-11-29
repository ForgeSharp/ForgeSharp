using System;

namespace ForgeSharp.Fragments
{
    public interface IFragment
    {
        string Name { get; }
    }

    public interface IPackage : IFragment
    {
        string Description { get; }
        string Author { get; }
        string Version { get; }
    }
}