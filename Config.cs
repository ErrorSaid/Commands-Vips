using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Vips
{
    public class Config : IConfig
    {
        [Description("is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
    }
}