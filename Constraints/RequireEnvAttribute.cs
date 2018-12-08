using ForgeSharp.Core;
using System;

namespace ForgeSharp.Constraints
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RequireEnvAttribute : Attribute
    {
        public readonly ChatEnvironment environment;

        public RequireEnvAttribute(ChatEnvironment environment)
        {
            this.environment = environment;
        }
    }
}
