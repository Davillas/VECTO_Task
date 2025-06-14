﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vecto.Core
{
    public interface IImageEffect
    {
        string Name { get; }

        void ApplyEffect(Image imageFile, string? parameter = null);
    }
}
