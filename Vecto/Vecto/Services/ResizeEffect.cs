using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vecto.Core;

namespace Vecto.Services
{
    public class ResizeEffect : IImageEffect
    {
        public string Name => "Resize";
        public void ApplyEffect(Image image, string? parameter = null)
        {
            image.AddEffect($"Image resized to {parameter}px");
        }
    }
}
