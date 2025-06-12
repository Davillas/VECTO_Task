using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vecto.Core
{
    public class Image
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public List<string> AppliedEffects { get; }

        public Image(string name, string filePath)
        {
            Name = name;
            FilePath = filePath;
            AppliedEffects = new List<string>();
        }

        public void AddEffect(string effectName)
        {
            if (!AppliedEffects.Contains(effectName))
            {
                AppliedEffects.Add(effectName);
            }
        }


    }
}
