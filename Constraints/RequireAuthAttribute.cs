using ForgeSharp.Core;
using System;

namespace ForgeSharp.Constraints
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RequireAuthAttribute : Attribute
    {
        public readonly AuthLevel level;

        public RequireAuthAttribute(AuthLevel level)
        {
            this.level = level;
        }
    }
}
