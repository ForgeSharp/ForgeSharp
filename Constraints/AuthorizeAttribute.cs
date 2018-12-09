using ForgeSharp.Core;
using System;

namespace ForgeSharp.Constraints
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class AuthorizeAttribute : Attribute
    {
        public readonly AuthLevel level;

        public AuthorizeAttribute(AuthLevel level)
        {
            this.level = level;
        }
    }
}
