using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vecto.Core;
using Vecto.Miscellaneous;
using Vecto.Services;

namespace Vecto.Controllers
{
    public static class PluginController
    {
        public static List<IImageEffect> GetAvailablePlugins(string configFilePath)
        {
            var plugins = new List<IImageEffect>();

            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException("Configuration file not found.", configFilePath);
            }

            string json = File.ReadAllText(configFilePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var config = JsonSerializer.Deserialize<PluginConfig>(json, options);

            foreach (var pluginName in config.Plugins)
            {
                Type type = Type.GetType(pluginName, throwOnError: false);

                if (type == null)
                {
                    type = Assembly.GetExecutingAssembly()
                        .GetType($"Vecto.Services.{pluginName}");
                }

                if (type != null && typeof(IImageEffect).IsAssignableFrom(type))
                {
                    IImageEffect pluginInstance = (IImageEffect)Activator.CreateInstance(type);
                    if (pluginInstance != null)
                    {
                        plugins.Add(pluginInstance);
                    }
                }
                else
                {
                    Console.WriteLine($"Plugin {pluginName} was not found.");
                }

            }

            return plugins;

        }
    }
}
