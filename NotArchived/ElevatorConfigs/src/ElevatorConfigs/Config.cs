using Exiled.API.Interfaces;
using System.ComponentModel;

namespace ElevatorConfigs
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled on this server.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Seconds it takes for the elevator to arrive")]
        public float WaitTimer { get; set; } = 5;
    }
}