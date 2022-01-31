using Exiled.API.Features;

namespace ScaleLmao
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;

        public override void OnEnabled()
        {
            Singleton = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            base.OnDisabled();
        }
    }
}