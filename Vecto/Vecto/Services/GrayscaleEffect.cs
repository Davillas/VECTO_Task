using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vecto.Core;

namespace Vecto.Services
{
    public class GrayscaleEffect : IImageEffect
    {
        public string Name => "Grayscale";
        public void ApplyEffect(Image image, string? parameter = null)
        {
            image.AddEffect($"{Name} is set to {parameter}");
        }
    }
}
