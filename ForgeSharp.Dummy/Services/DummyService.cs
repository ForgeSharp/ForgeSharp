using ForgeSharp.Logging;
using ForgeSharp.Services;

namespace ForgeSharp.Dummy.Services
{
    public class DummyService : Service
    {
        public override string Name => "dummy";

        public override string Description => "A dummy service for testing";

        public override string Author => "CloudRex <cloudrex@outlook.com>";

        public override string Version => "1.0.0";

        public override void Start()
        {
            Logger.Verbose("DummyService started");
        }
    }
}
