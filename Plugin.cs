using System;
using Exiled.API.Features;

namespace Vips
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "Vips";
        public override string Author { get; } = "ErrorSaid";
        public override string Prefix { get; } = "Vip";
        public override Version Version { get; } = new Version(0, 0, 1);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

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
