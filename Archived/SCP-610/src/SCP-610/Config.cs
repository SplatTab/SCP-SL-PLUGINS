using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using UnityEngine;

namespace SCP_610
{
    public class Config : IConfig
    {
        [Description("Whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;
    }
}
