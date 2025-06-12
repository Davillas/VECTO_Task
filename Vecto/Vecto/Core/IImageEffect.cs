using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vecto.Core
{
    internal interface IImageEffect
    {
        string Name { get; }

        void ApplyEffect(ImageFile imageFile, string parameter = null);
    }
}
