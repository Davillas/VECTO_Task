using Vecto.Controllers;
using Vecto.Core;

namespace Vecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ~~~~~~~~~~Simulation of plugin loading and effect application~~~~~~~~~~~~~~


            var plugins = PluginController.GetAvailablePlugins();
            var imageProcessor = new ImageProcessor(plugins);

            var image1 = new Image("Image_1","example1.jpg");
            var image2 = new Image("Image_2","example2.jpg");
            var image3 = new Image("Image_3","example3.jpg");


            imageProcessor.ApplyEffects(image1, new List<EffectEntity>
            {
                new EffectEntity { EffectName = "Saturation", Parameter = "56" },
                new EffectEntity { EffectName = "GaussianBlur", Parameter = "3" },

            });

            imageProcessor.ApplyEffects(image2, new List<EffectEntity>
            {
                new EffectEntity { EffectName = "Resize", Parameter = "5" },

            });

            imageProcessor.ApplyEffects(image3, new List<EffectEntity>
            {
                new EffectEntity { EffectName = "Grayscale", Parameter = "1.0" },
                new EffectEntity { EffectName = "Resize", Parameter = "3" },
                new EffectEntity { EffectName = "GaussianBlur", Parameter = "3" },

            });

            PrintImage(image1);
            PrintImage(image2);
            PrintImage(image3);
        }

        private static void PrintImage(Image image)
        {
            Console.WriteLine($"Image Name: {image.Name}");
            Console.WriteLine($"Image Path: {image.FilePath}");
            Console.WriteLine("Applied Effects:");
            foreach (var effect in image.AppliedEffects)
            {
                Console.WriteLine($"- {effect}");
            }
        }
    }
}
