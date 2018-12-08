using ForgeSharp.Fragments;
using ForgeSharp.Logging;
using ForgeSharp.Services;

namespace ForgeSharp.Dummy.Services
{
    public class DummyService : Service
    {
        public override Meta Meta => new Meta
        {
            Name = "dummy",
            Description = "A dummy service for testing"
        };

        public override void Start()
        {
            Logger.Verbose("DummyService started");
        }
    }
}
