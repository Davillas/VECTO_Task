using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vecto.Core;
using Vecto.Services;

namespace Vecto.Controllers
{
    public static class PluginController
    {
        public static List<IImageEffect> GetAvailablePlugins()
        {
            // In a real application, this method would dynamically load plugins.
            // Here we return a static list for demonstration purposes.
            return new List<IImageEffect>
            {
                new SaturationEffect(),
                new GrayscaleEffect(),
                new GaussianBlurEffect(),
                new ResizeEffect()
            };
        }
    }
}
