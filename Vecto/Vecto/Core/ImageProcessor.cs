using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vecto.Core
{
    internal class ImageProcessor
    {
        private readonly Dictionary<string ,IImageEffect> _availiableEffects;

        public ImageProcessor(IEnumerable<IImageEffect> effects)
        {

            _availiableEffects = new Dictionary<string, IImageEffect>(StringComparer.OrdinalIgnoreCase);

            foreach (var effect in effects)
            {
                if (!_availiableEffects.ContainsKey(effect.Name))
                {
                    _availiableEffects.Add(effect.Name, effect);
                }
            }

        }

        public void ApplyEffects(Image image, List<EffectEntity> effects)
        {
            foreach (var effect in effects) {
                if (_availiableEffects.TryGetValue(effect.EffectName, out var imageEffect))
                {
                    imageEffect.ApplyEffect(image, effect.Parameter);
                }
                else
                {
                    throw new ArgumentException($"Effect '{effect.EffectName}' is not available.");
                }
            }
        }
    }
}
